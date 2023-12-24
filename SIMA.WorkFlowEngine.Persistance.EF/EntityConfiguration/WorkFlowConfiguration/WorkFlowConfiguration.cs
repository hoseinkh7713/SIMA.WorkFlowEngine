using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Entities;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Persistance.EF.EntityConfiguration.WorkFlowConfiguration
{
    public class WorkFlowConfiguration : IEntityTypeConfiguration<WorkFlow>
    {
        public void Configure(EntityTypeBuilder<WorkFlow> entity)
        {

            entity.ToTable("WorkFlow", "Project");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActiveStatusId).HasColumnName("ActiveStatusID");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasComment("")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.ManagerRoleId).HasColumnName("ManagerRoleID");
            entity.Property(e => e.ModifiedAt)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.WorkFlows)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkFlow_Project");
        }
    }
}
