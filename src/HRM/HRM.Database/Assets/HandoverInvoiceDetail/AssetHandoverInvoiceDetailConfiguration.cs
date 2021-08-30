using HRM.Domain.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRM.Database.Assets
{
    public class AssetHandoverInvoiceDetailConfiguration : IEntityTypeConfiguration<AssetHandoverInvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<AssetHandoverInvoiceDetail> builder)
        {
            builder.ToTable(nameof(AssetHandoverInvoiceDetail), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.HandoverInvoiceId).IsRequired();
            builder.HasOne(m => m.HandoverInvoice)
                   .WithMany(e => e.AssetHandoverInvoiceDetails)
                   .HasForeignKey(m => m.HandoverInvoiceId)
                   .HasConstraintName("FK_AssetHandoverInvoiceDetail_HandoverInvoiceId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.AssetId).IsRequired();
            builder.HasOne(m => m.Asset)
                   .WithMany(e => e.AssetHandoverInvoiceDetails)
                   .HasForeignKey(m => m.AssetId)
                   .HasConstraintName("FK_AssetHandoverInvoiceDetail_AssetId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Notes).HasMaxLength(500);
        }
    }
}
