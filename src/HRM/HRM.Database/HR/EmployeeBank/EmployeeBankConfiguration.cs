using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeBankConfiguration : IEntityTypeConfiguration<EmployeeBank>
    {
        public void Configure(EntityTypeBuilder<EmployeeBank> builder)
        {
            builder.ToTable(nameof(EmployeeBank), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee)
                   .WithMany(e => e.EmployeeBanks)
                   .HasForeignKey(m => m.EmployeeId)
                   .HasConstraintName("FK_EmployeeBank_EmployeeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.BankId).IsRequired();
            builder.HasOne(m => m.Bank)
                   .WithMany(b => b.EmployeeBanks)
                   .HasForeignKey(m => m.BankId)
                   .HasConstraintName("FK_EmployeeBank_BankId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.BankAddress).HasMaxLength(100).IsRequired();

            builder.Property(m => m.AccountNumber).HasMaxLength(100).IsRequired();

            builder.Property(m => m.AccountOwner).HasMaxLength(100).IsRequired();

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
