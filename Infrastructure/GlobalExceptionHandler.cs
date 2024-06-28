using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace Infrastructure
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            _logger.LogError(context.Exception, $"Exception occurred: {context.Exception.Message}");

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An unexpected error occurred!",
                Detail = context.Exception.Message,
                Type = "https://tools.ietf.org/html/rfc7807"
            };

            context.Result = new InternalServerErrorResult(problemDetails);
            return Task.CompletedTask;
        }
    }

    public class InternalServerErrorResult : IActionResult
    {
        private readonly ProblemDetails _problemDetails;

        public InternalServerErrorResult(ProblemDetails problemDetails)
        {
            _problemDetails = problemDetails;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_problemDetails)
            {
                StatusCode = _problemDetails.Status
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
