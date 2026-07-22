using Microsoft.EntityFrameworkCore;
using NearbyPlaces.Models;

namespace NearbyPlaces.Data;

public class NearbyPlacesDbContext : DbContext
{
    public NearbyPlacesDbContext(DbContextOptions<NearbyPlacesDbContext> options) : base(options)
    {
    }

    public DbSet<Place> Places => Set<Place>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Place>()
            .Property(x => x.Type)
            .HasConversion<string>();

        base.OnModelCreating(modelBuilder);
    }
}