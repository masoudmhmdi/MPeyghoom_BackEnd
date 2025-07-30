using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MPeyghoom.Configuration.MemoryCash;
using MPeyghoom.EndPoints.Auth;
using MPeyghoom.Hubs;
using MPeyghoom.Options;
using MPeyghoom.Repositories;
using MPeyghoom.Services;
using MPeyghoom.Services.AuthService;
using MPeyghoom.Services.CashService;

namespace MPeyghoom.Configuration;


public static class Configuration
{
    public static void RegisterAllPeyghoomServices(this WebApplicationBuilder builder)
    {
        
        builder.Services.AddSignalR();
        builder.Services.AddCors();
        builder.Services.AddOpenApi();
        builder.RegisterPeyghoomMongoDb();
        builder.RegisterCustomServices();
        builder.RegisterCash();
        builder.RegisterAuthentication();
        builder.RegisterOptions();
    }

    private static void RegisterPeyghoomMongoDb(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<PeyghoomMongoDbSetting>(
            builder.Configuration.GetSection("PeyghoomMongoDbSetting"));
    }

    private static void RegisterCustomServices(this WebApplicationBuilder builder)
    {
        
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IJwtService, JwtService>();
    }

    private static void RegisterCash(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ICashService, CashService>();
    }

    private static void RegisterAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    // ValidIssuer = Configuration["Jwt:Issuer"],
                    // ValidAudience = Configuration["Jwt:Issuer"],
                    // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
    }

    private static void RegisterOptions(this WebApplicationBuilder builder)
    {
        
    }
    public static void AddAllPeyghoomMiddlewares(this WebApplication app)
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
        if (app.Environment.IsDevelopment())
        {    
             app.MapOpenApi();
        }

        app.UseAuthentication();
        app.RegisterAuthEndPoints();
    }
}
