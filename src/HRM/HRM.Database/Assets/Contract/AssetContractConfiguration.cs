using HRM.Domain.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRM.Database.Assets
{
    public class AssetContractConfiguration : IEntityTypeConfiguration<AssetContract>
    {
        public void Configure(EntityTypeBuilder<AssetContract> builder)
        {
            builder.ToTable(nameof(AssetContract), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.Code).HasColumnType("varchar").HasMaxLength(20).IsRequired();

            builder.Property(m => m.VendorId).IsRequired();
            builder.HasOne(m => m.Vendor)
                   .WithMany(e => e.AssetContracts)
                   .HasForeignKey(m => m.VendorId)
                   .HasConstraintName("FK_AssetContract_VendorId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.SignDate);

            builder.Property(m => m.LiquidationDate);

            builder.Property(m => m.TotalCost).IsRequired();

            builder.Property(m => m.Payment).IsRequired();

            builder.Property(m => m.ResidualValue).IsRequired();

            builder.Property(m => m.Notes).HasMaxLength(500);

            builder.Property(m => m.IsActive).IsRequired();

            builder.Property(m => m.CreateBy).IsRequired();

            builder.Property(m => m.CreateDate).IsRequired();

            builder.Property(m => m.UpdateBy);

            builder.Property(m => m.UpdateDate);

            builder.Property(m => m.Deleted).IsRequired();

            builder.Property(m => m.RowVersion).IsRowVersion();
        }
    }
}
