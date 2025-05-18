using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TVSorter.Model;

namespace TVSorter.Data.Mapping;

public class SettingEntityTypeConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.ToTable(nameof(Setting));
        builder.HasKey(x => x.SettingName);
    }
}
