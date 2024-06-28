using System;
using System.Net;
using System.Threading.Tasks;
using BurgerToNight.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError; // Default status code

        // Handle specific exceptions if needed
        // Example: For UnauthorizedAccessException
        // if (exception is UnauthorizedAccessException)
        // {
        //     statusCode = HttpStatusCode.Unauthorized;
        // }

        var response = new APIResponse
        {
            IsSuccess = false,
            ErrorMessages = new List<string> { exception?.Message ?? "Internal Server Error" },
            StatusCode = statusCode
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}
