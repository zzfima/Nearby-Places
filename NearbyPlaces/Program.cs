using Microsoft.EntityFrameworkCore;
using NearbyPlaces.Data;
using NearbyPlaces.Redis;

public partial class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddSingleton<RedisCrud>();

        builder.Services.AddDbContext<NearbyPlacesDbContext>(options =>
        {
            options.UseSqlite(
                builder.Configuration.GetConnectionString("NearbyPlacesDb"));
        });

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var redis = scope.ServiceProvider.GetRequiredService<RedisCrud>();
            await redis.Connect();
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
}