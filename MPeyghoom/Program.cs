using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using MPeyghoom.Hubs;




public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.AddSignalR();
        builder.Services.AddCors();
        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        var app = builder.Build();
        app.MapHub<ChatHub>("/chatHub");
        app.UseCors(option =>
        {
            
            option.WithOrigins("http://localhost:3000");
            option.AllowAnyHeader();
            option.AllowAnyMethod();
            option.SetIsOriginAllowed((host) => true); // Allow any origin for development
            option.AllowCredentials();
        });
        

        app.Run();

    }
    
    
}    
public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}