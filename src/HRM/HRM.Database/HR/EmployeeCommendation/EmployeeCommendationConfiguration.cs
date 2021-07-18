using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeCommendationConfiguration : IEntityTypeConfiguration<EmployeeCommendation>
    {
        public void Configure(EntityTypeBuilder<EmployeeCommendation> builder)
        {
            builder.ToTable(nameof(EmployeeCommendation), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee)
                   .WithMany(e => e.EmployeeCommendations)
                   .HasForeignKey(m => m.EmployeeId)
                   .HasConstraintName("FK_EmployeeCommendation_EmployeeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.CommendationId).IsRequired();
            builder.HasOne(m => m.Commendation)
                   .WithMany(e => e.EmployeeCommendations)
                   .HasForeignKey(m => m.CommendationId)
                   .HasConstraintName("FK_EmployeeCommendation_CommendationId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Date).IsRequired();

            builder.Property(m => m.Comment).HasMaxLength(250).IsRequired();

            builder.Property(m => m.ProposerId).IsRequired();
            builder.HasOne(m => m.Proposer)
                   .WithMany(e => e.EmployeeCommendationProposers)
                   .HasForeignKey(m => m.ProposerId)
                   .HasConstraintName("FK_EmployeeCommendation_ProposerId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.ProposeDate).IsRequired();

            builder.Property(m => m.ApprovedStatus).IsRequired();

            builder.Property(m => m.ApprovedBy);
            builder.HasOne(m => m.Approver)
                   .WithMany(e => e.EmployeeCommendationApproveds)
                   .HasForeignKey(m => m.ApprovedBy)
                   .HasConstraintName("FK_EmployeeCommendation_ApprovedBy")
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
