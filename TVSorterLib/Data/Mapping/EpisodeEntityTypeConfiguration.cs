using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TVSorter.Model;

namespace TVSorter.Data.Mapping;

public class EpisodeEntityTypeConfiguration : IEntityTypeConfiguration<Episode>
{
    public void Configure(EntityTypeBuilder<Episode> builder) => builder.HasKey(x => x.TvdbId);
}
