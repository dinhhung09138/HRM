using HRM.Domain.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRM.Database.Assets
{
    public class AssetContractPaymentConfiguration : IEntityTypeConfiguration<AssetContractPayment>
    {
        public void Configure(EntityTypeBuilder<AssetContractPayment> builder)
        {
            builder.ToTable(nameof(AssetContractPayment), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.AssetContractId).IsRequired();
            builder.HasOne(m => m.AssetContract)
                   .WithMany(e => e.AssetContractPayments)
                   .HasForeignKey(m => m.AssetContractId)
                   .HasConstraintName("FK_AssetContractPayment_AssetContractId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Payment).IsRequired();

            builder.Property(m => m.PaymentDate).IsRequired();

            builder.Property(m => m.Notes).HasMaxLength(500).IsRequired();

            builder.Property(m => m.CreateBy).IsRequired();

            builder.Property(m => m.CreateDate).IsRequired();

            builder.Property(m => m.UpdateBy);

            builder.Property(m => m.UpdateDate);

            builder.Property(m => m.Deleted).IsRequired();

            builder.Property(m => m.RowVersion).IsRowVersion();
        }
    }
}
