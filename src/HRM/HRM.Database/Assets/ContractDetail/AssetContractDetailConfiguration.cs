using HRM.Domain.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.Assets
{
    public class AssetContractDetailConfiguration : IEntityTypeConfiguration<AssetContractDetail>
    {
        public void Configure(EntityTypeBuilder<AssetContractDetail> builder)
        {
            builder.ToTable(nameof(AssetContractDetail), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.AssetContractId).IsRequired();
            builder.HasOne(m => m.AssetContract)
                   .WithMany(e => e.AssetContractDetails)
                   .HasForeignKey(m => m.AssetContractId)
                   .HasConstraintName("FK_AssetContractDetail_AssetContractId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.AssetTypeId).IsRequired();
            builder.HasOne(m => m.AssetType)
                   .WithMany(e => e.AssetContractDetails)
                   .HasForeignKey(m => m.AssetTypeId)
                   .HasConstraintName("FK_AssetContractDetail_AssetTypeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Price).IsRequired();

            builder.Property(m => m.Quantity).IsRequired();

            builder.Property(m => m.Vat).IsRequired();

            builder.Property(m => m.Total).IsRequired();

            builder.Property(m => m.Notes).HasMaxLength(500);
        }
    }
}
