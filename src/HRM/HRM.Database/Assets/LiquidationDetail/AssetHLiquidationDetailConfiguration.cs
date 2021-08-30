using HRM.Domain.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.Assets
{
    public class AssetLiquidationDetailConfiguration : IEntityTypeConfiguration<AssetLiquidationDetail>
    {
        public void Configure(EntityTypeBuilder<AssetLiquidationDetail> builder)
        {
            builder.ToTable(nameof(AssetLiquidationDetail), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.AssetLiquidationId).IsRequired();
            builder.HasOne(m => m.AssetLiquidation)
                   .WithMany(e => e.AssetLiquidationDetails)
                   .HasForeignKey(m => m.AssetLiquidationId)
                   .HasConstraintName("FK_AssetLiquidationDetail_AssetLiquidationId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.AssetId).IsRequired();
            builder.HasOne(m => m.Asset)
                   .WithMany(e => e.AssetLiquidationDetails)
                   .HasForeignKey(m => m.AssetId)
                   .HasConstraintName("FK_AssetLiquidationDetail_AssetId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Notes).HasMaxLength(500);
        }
    }
}
