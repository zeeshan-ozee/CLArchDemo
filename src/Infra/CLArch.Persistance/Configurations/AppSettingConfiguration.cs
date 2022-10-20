using CLArch.Domain.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLArch.Persistance.Configurations;

public class AppSettingConfiguration : IEntityTypeConfiguration<AppSetting>
{
    public void Configure(EntityTypeBuilder<AppSetting> builder)
    {
        builder.ToTable("AppSetting");

        builder.Property(nameof(AppSetting.ReferenceKey)).HasMaxLength(100).IsRequired();

        builder.Property(nameof(AppSetting.Value)).HasMaxLength(500);
    }
}
