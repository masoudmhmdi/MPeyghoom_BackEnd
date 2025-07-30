using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MPeyghoom.Configuration;
using MPeyghoom.Contracts.Auth.GetVerificationCode;
using MPeyghoom.Hubs;
using MPeyghoom.Services.AuthService;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);
        builder.RegisterAllPeyghoomServices();

        var app = builder.Build();
        
        app.AddAllPeyghoomMiddlewares();
 
        app.Run();

    }
    
}    