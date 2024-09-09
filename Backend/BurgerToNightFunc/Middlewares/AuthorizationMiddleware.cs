using BurgerToNightAPI.Models;
using BurgerToNightFunc.Attributes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Text;
public class AuthorizationMiddleware : IFunctionsWorkerMiddleware
{
    private readonly string _secretKey;

    public AuthorizationMiddleware(IConfiguration configuration)
    {
        _secretKey = configuration.GetValue<string>("ApiSettings:Secret");
    }

    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        var logger = context.GetLogger<AuthorizationMiddleware>();

        var functionMethod = GetFunctionMethod(context.FunctionDefinition);
        if (functionMethod == null)
        {
            logger.LogError($"Unable to find method for function: {context.FunctionDefinition.Name}");
            await next(context);
            return;
        }

        var authorizeAttribute = functionMethod.GetCustomAttribute<AuthorizeAttribute>();

        if (authorizeAttribute == null)
        {
            await next(context);
            return;
        }

        var httpRequest = await context.GetHttpRequestDataAsync();
        if (httpRequest == null)
        {
            await next(context);
            return;
        }

        if (!httpRequest.Headers.TryGetValues("Authorization", out var authHeaders))
        {
            var unauthorizedResponse = await RespondWithUnauthorized(httpRequest, "Authorization header is missing");
            await WriteResponseAsync(context, unauthorizedResponse);
            return;
        }

        var bearerToken = authHeaders.FirstOrDefault();
        if (string.IsNullOrWhiteSpace(bearerToken) || !bearerToken.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            var unauthorizedResponse = await RespondWithUnauthorized(httpRequest, "Invalid Authorization header format");
            await WriteResponseAsync(context, unauthorizedResponse);
            return;
        }

        var token = bearerToken.Substring("Bearer ".Length).Trim();
        var principal = ValidateToken(token);
        if (principal == null)
        {
            var unauthorizedResponse = await RespondWithUnauthorized(httpRequest, "Invalid or expired token");
            await WriteResponseAsync(context, unauthorizedResponse);
            return;
        }

        var userRoles = principal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
        if (authorizeAttribute.Roles.Any() && !authorizeAttribute.Roles.Any(role => userRoles.Contains(role)))
        {
            var forbiddenResponse = await RespondWithForbidden(httpRequest, "You do not have permission to access this resource");
            await WriteResponseAsync(context, forbiddenResponse);
            return;
        }

        context.Items["User"] = principal;
        await next(context);
    }

    private MethodInfo GetFunctionMethod(FunctionDefinition functionDefinition)
    {
        var assembly = Assembly.LoadFrom(functionDefinition.PathToAssembly);
        if (assembly == null)
        {
            Console.WriteLine("Assembly could not be loaded.");
            return null;
        }

        var parts = functionDefinition.EntryPoint.Split('.');
        if (parts.Length < 2)
        {
            Console.WriteLine("Invalid EntryPoint format.");
            return null;
        }

        var className = string.Join('.', parts.Take(parts.Length - 1));
        var methodName = parts.Last();

        var type = assembly.GetType(className);
        if (type == null)
        {
            Console.WriteLine($"Type not found: {className}");
            return null;
        }

        var method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        if (method == null)
        {
            Console.WriteLine($"Method not found: {methodName} in type {className}");
        }

        return method;
    }

    private ClaimsPrincipal ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        try
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            return principal;
        }
        catch
        {
            return null;
        }
    }

    private async Task<APIResponse> RespondWithUnauthorized(HttpRequestData request, string message)
    {
        return new APIResponse
        {
            StatusCode = HttpStatusCode.Unauthorized,
            IsSuccess = false,
        };
    }

    private async Task<APIResponse> RespondWithForbidden(HttpRequestData request, string message)
    {
        return new APIResponse
        {
            StatusCode = HttpStatusCode.Forbidden,
            IsSuccess = false,
        };
    }

    private async Task WriteResponseAsync(FunctionContext context, APIResponse apiResponse)
    {
        var httpRequest = await context.GetHttpRequestDataAsync();
        var response = httpRequest.CreateResponse(apiResponse.StatusCode);

        await response.WriteAsJsonAsync(apiResponse);

        context.GetInvocationResult().Value = response;
    }

}
