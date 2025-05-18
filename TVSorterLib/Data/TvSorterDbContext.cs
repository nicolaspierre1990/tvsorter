using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TVSorter.Model;

namespace TVSorter.Data;

public class TvSorterDbContext : DbContext
{
    private readonly string _dbPath;

    public DbSet<TvShow> TvShows { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Setting> Settings { get; set; }

    public TvSorterDbContext()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\");
        _dbPath = Path.Join(path, "tvsorter.db");

        if (!File.Exists(_dbPath))
        {
            Directory.CreateDirectory(path);
            Database.Migrate();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={_dbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}

public class TvSorterDbContextFactory : IDesignTimeDbContextFactory<TvSorterDbContext>
{
    public TvSorterDbContext CreateDbContext(string[] args) => new();
}
