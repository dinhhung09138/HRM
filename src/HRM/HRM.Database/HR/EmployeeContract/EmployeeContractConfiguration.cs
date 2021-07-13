using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeContractConfiguration : IEntityTypeConfiguration<EmployeeContract>
    {
        public void Configure(EntityTypeBuilder<EmployeeContract> builder)
        {
            builder.ToTable(nameof(EmployeeContract), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee).WithMany()
                   .HasForeignKey(m => m.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.EmployeeProcessId).IsRequired();
            builder.HasOne(m => m.EmployeeProcess).WithMany()
                   .HasForeignKey(m => m.EmployeeProcessId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.ContractTypeId).IsRequired();
            builder.HasOne(m => m.ContractType).WithMany()
                   .HasForeignKey(m => m.ContractTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.FromDate).IsRequired();

            builder.Property(m => m.ToDate);

            builder.Property(m => m.Comment).HasMaxLength(255).IsRequired();

            builder.Property(m => m.GrossSalary).IsRequired();

            builder.Property(m => m.NetSalary).IsRequired();

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
