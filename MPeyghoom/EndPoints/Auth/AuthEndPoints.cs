using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MPeyghoom.Configuration.Result;
using MPeyghoom.Contracts.Auth.GetVerificationCode;
using MPeyghoom.Services.AuthService;

namespace MPeyghoom.EndPoints.Auth;

public static class AuthEndPoints
{
    public static void RegisterAuthEndPoints(this IEndpointRouteBuilder routes)
   {
       var auth = routes.MapGroup("/auth");
       auth.MapPost("/verification_code", GetVerificationCodeMethod)
           .RequireAuthorization();

   }

    private static IResult GetVerificationCodeMethod([FromBody] GetVerificationCodeRequest request, [FromServices] IAuthService service)
    {
        var tokenResult = service.GetTokenForValidatePhoneNumber(request.PhoneNumber);
        if (tokenResult.IsSuccess)
        {
            return Results.Ok(tokenResult.Value);
        }
        else
        {
            return tokenResult.ToProblemDetails();
        }
    }
}

