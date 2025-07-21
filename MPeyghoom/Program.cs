using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using MPeyghoom.Configuration;
using MPeyghoom.Hubs;




public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);
        builder.RegisterServices();

        var app = builder.Build();
        
        app.RegisterMiddlewares();

        
        app.Run();

    }
    
    
}    