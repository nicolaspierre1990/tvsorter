using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TVSorter.Model;

namespace TVSorter.Data.Mapping;

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
