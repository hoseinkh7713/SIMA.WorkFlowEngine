using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Persistance.EF.EntityConfiguration.WorkFlowActorConfiguration
{
    public class WorkFlowActorConfiguration : IEntityTypeConfiguration<WorkFlowActor>
    {
        public void Configure(EntityTypeBuilder<WorkFlowActor> entity)
        {

            entity.ToTable("WorkFlowActor", "Project");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActiveStatusId).HasColumnName("ActiveStatusID");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedAt)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

        }
    }
}
