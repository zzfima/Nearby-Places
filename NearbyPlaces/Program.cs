using Microsoft.EntityFrameworkCore;
using NearbyPlaces.Data;
using NearbyPlaces.Redis;

public partial class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        AddServices(builder);

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var redis = scope.ServiceProvider.GetRequiredService<RedisCrud>();
            await redis.Connect(builder.Configuration["Redis:ConnectionString"]);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddSingleton<RedisCrud>();
        builder.Services.AddDbContext<NearbyPlacesDbContext>(options =>
        {
            options.UseSqlite(
                "Data Source=NearbyPlaces.db");
        });
    }
}