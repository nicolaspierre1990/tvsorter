using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TVSorter.Model;

namespace TVSorter.Data;

public class TvSorterDbContext : DbContext
{
    public DbSet<TvShow> TvShows { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Setting> Settings { get; set; }

    public TvSorterDbContext(DbContextOptions options) : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}

public class TvSorterDbContextFactory : IDesignTimeDbContextFactory<TvSorterDbContext>
{
    public TvSorterDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TvSorterDbContext>();
        optionsBuilder.UseSqlite("Data Source=tvsorter.db");

        return new TvSorterDbContext(optionsBuilder.Options);
    }
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
    public void Configure(EntityTypeBuilder<Episode> builder)
    {
        builder.HasKey(x => x.TvdbId);
    }
}
