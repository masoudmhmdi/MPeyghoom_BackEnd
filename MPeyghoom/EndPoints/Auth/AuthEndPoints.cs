using System.Diagnostics.CodeAnalysis;
using MPeyghoom.Services.AuthService;

namespace MPeyghoom.EndPoints.Auth;

public static class AuthEndPoints
{
    public static void RegisterAuthEndPoints(this IEndpointRouteBuilder routes)
   {
       var auth = routes.MapGroup("/auth");
       auth.MapGet("/verification_code", (IAuthService service) =>
       {
           service.GetVerificationCode(12345);
           return "Hello World";
       });

   }
    
}