using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace MPeyghoom.Configuration.Result;

public static class ResultExtention
{

    public static IResult ToProblemDetails(this Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException("Can't convert success result to problem");
        }


        var problem = new ProblemDetails()
        {
            Status = (int)ResultExtention.GetStatusCode(result.Error.ErrorType),
            Title = ResultExtention.GetTitle(result.Error.ErrorType),
            Type = ResultExtention.GetType(result.Error.ErrorType),
            Extensions = new Dictionary<string, object?>
            {
                { "error", new[] { result.Error }  },
            }

        };
        
        return Microsoft.AspNetCore.Http.Results.Problem(
            detail: problem.Detail,
            statusCode: problem.Status,
            title: problem.Title,
            type: problem.Type,
            extensions: problem.Extensions
        );
    }




    private static HttpStatusCode GetStatusCode(ErrorType errorType)
    {
        var statusCode = errorType switch
        {
            ErrorType.NotFound => HttpStatusCode.NotFound,
            ErrorType.Unauthorized => HttpStatusCode.Unauthorized,
            ErrorType.Conflict => HttpStatusCode.Conflict,
            ErrorType.Forbidden => HttpStatusCode.Forbidden,
            ErrorType.Validation => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };
        
        return statusCode;
    }
    
    static string GetTitle(ErrorType errorType) =>
        errorType switch
        {
            ErrorType.Validation => "Bad Request",
            ErrorType.NotFound => "Not found",
            ErrorType.Conflict => "Conflict",
            ErrorType.Forbidden => "Forbidden",
            ErrorType.Unauthorized => "Unauthorized",

            _ => "Server failure"
        };
    
    static string GetType(ErrorType statusCode) =>
        statusCode switch
        {
            ErrorType.Validation => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            ErrorType.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            ErrorType.Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
            ErrorType.Forbidden => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
            ErrorType.Unauthorized => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
            _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        };

}