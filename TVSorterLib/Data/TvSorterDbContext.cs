using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

public class Setting
{
    public string SettingName { get; set; }
    public string SettingValue { get; set; }
}

public class SettingEntityTypeConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.ToTable(nameof(Setting));
        builder.HasKey(x => x.SettingName);
    }
}

public class TvShowEntityTypeConfiguration : IEntityTypeConfiguration<TvShow>
{
    public void Configure(EntityTypeBuilder<TvShow> builder)
    {
        builder.HasKey(x => x.TvdbId);

        builder.HasMany(x => x.Episodes)
            .WithOne(x => x.Show)
            .HasForeignKey(x => x.ShowId);
    }
}

public class EpisodeEntityTypeConfiguration : IEntityTypeConfiguration<Episode>
{
    public void Configure(EntityTypeBuilder<Episode> builder) => builder.HasKey(x => x.TvdbId);
}
