using MPeyghoom.Configuration.MemoryCash;
using MPeyghoom.EndPoints.Auth;
using MPeyghoom.Hubs;
using MPeyghoom.Services.AuthService;
using MPeyghoom.Services.CashService;

namespace MPeyghoom.Configuration;



public static class Configuration
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        
        builder.Services.AddSignalR();
        builder.Services.AddCors();
        builder.Services.AddSingleton<MyMemoryCache>();
        builder.Services.AddSingleton<ICashService, CashService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
    }
 
    
    public static void RegisterMiddlewares(this WebApplication app)
    {
        app.MapHub<ChatHub>("/chatHub");
        app.UseCors(option =>
        {
            
            option.WithOrigins("http://localhost:3000");
            option.AllowAnyHeader();
            option.AllowAnyMethod();
            option.SetIsOriginAllowed((host) => true); // Allow any origin for development
            option.AllowCredentials();
        });
        
        app.RegisterAuthEndPoints();
    }
}
