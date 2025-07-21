using System.Diagnostics.CodeAnalysis;

namespace MPeyghoom.EndPoints.Auth;

public static class AuthEndPoints
{
    public static void RegisterAuthEndPoints(this IEndpointRouteBuilder routes)
   {
       var auth = routes.MapGroup("/auth");
       auth.MapGet("/test", () =>
       {
           return "Hello World";
       });

   }
    
}