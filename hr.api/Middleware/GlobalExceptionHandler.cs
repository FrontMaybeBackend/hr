using Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace hr.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problemDetails = exception switch
        {
            ValidationException validationException => CreateValidationProblemDetails(validationException),
            ExistsException existsException => CreateExistsExceptionProblemDetails(existsException),
            NotFoundException notFoundException => CreateNotFoundExceptionProblemDetails(notFoundException),
            _ => null
        };

        if (problemDetails == null) return false;

        httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, problemDetails.GetType(), cancellationToken);
        return true;
    }

    private static HttpValidationProblemDetails CreateValidationProblemDetails(ValidationException validationException)
    {
        var errors = validationException.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key.ToLowerInvariant(),
                g => g.Select(e => e.ErrorMessage).ToArray()
            );

        return new HttpValidationProblemDetails(errors)
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Validation error",
            Detail = "One or more validation errors occurred."
        };
    }

    private static ProblemDetails CreateExistsExceptionProblemDetails(ExistsException existsException)
    {
        return new ProblemDetails
        {
            Status = StatusCodes.Status409Conflict,
            Title = "User with this email already exists",
            Detail = existsException.Message
        };
    }

    private static ProblemDetails CreateNotFoundExceptionProblemDetails(NotFoundException notFoundException)
    {
        return new ProblemDetails
        {
            Status = StatusCodes.Status404NotFound,
            Title = "Resource not found",
            Detail = notFoundException.Message
        };
    }
}