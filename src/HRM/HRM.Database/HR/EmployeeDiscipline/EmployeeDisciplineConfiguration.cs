using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeDisciplineConfiguration : IEntityTypeConfiguration<EmployeeDiscipline>
    {
        public void Configure(EntityTypeBuilder<EmployeeDiscipline> builder)
        {
            builder.ToTable(nameof(EmployeeDiscipline), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee)
                   .WithMany(e => e.EmployeeDisciplines)
                   .HasForeignKey(m => m.EmployeeId)
                   .HasConstraintName("FK_EmployeeDiscipline_EmployeeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.DisciplineId).IsRequired();
            builder.HasOne(m => m.Discipline)
                   .WithMany(d => d.EmployeeDisciplines)
                   .HasForeignKey(m => m.DisciplineId)
                   .HasConstraintName("FK_EmployeeDiscipline_DisciplineId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Date).IsRequired();

            builder.Property(m => m.Comment).HasMaxLength(250).IsRequired();

            builder.Property(m => m.ProposerId).IsRequired();
            builder.HasOne(m => m.Proposer)
                   .WithMany(e => e.EmployeeDisciplineProposers)
                   .HasForeignKey(m => m.ProposerId)
                   .HasConstraintName("FK_EmployeeDiscipline_ProposerId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.ProposeDate).IsRequired();

            builder.Property(m => m.ApprovedStatus).IsRequired();

            builder.Property(m => m.ApprovedBy);
            builder.HasOne(m => m.Approver)
                   .WithMany(e => e.EmployeeDisciplineApproveds)
                   .HasForeignKey(m => m.ApprovedBy)
                   .HasConstraintName("FK_EmployeeDiscipline_ApprovedBy")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.ApprovedDate);

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
