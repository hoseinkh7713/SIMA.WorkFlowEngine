using Microsoft.EntityFrameworkCore;
using SIMA.WorkFlowEngine.Domain.Models;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Entities;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Entites;
using SIMA.WorkFlowEngine.Persistance.EF.EntityConfiguration.WorkFlowActorConfiguration;
using SIMA.WorkFlowEngine.Persistance.EF.EntityConfiguration.WorkFlowConfiguration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Persistance.EF.Persistence
{
    public class WorkFlowContext : DbContext
    {
        public WorkFlowContext(DbContextOptions<WorkFlowContext> options) : base(options)
        {

        }
        public virtual DbSet<Domain.Models.WorkFlow.Entities.Action> Actions { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<ProjectGroup> ProjectGroups { get; set; }

        public virtual DbSet<ProjectMember> ProjectMembers { get; set; }

        public virtual DbSet<RejectionReason> RejectionReasons { get; set; }

        public virtual DbSet<State> States { get; set; }

        public virtual DbSet<Step> Steps { get; set; }

        public virtual DbSet<WorkFlow> WorkFlows { get; set; }

        public virtual DbSet<WorkFlowActor> WorkFlowActors { get; set; }

        public virtual DbSet<WorkFlowActorGroup> WorkFlowActorGroups { get; set; }

        public virtual DbSet<WorkFlowActorRole> WorkFlowActorRoles { get; set; }

        public virtual DbSet<WorkFlowActorStep> WorkFlowActorSteps { get; set; }

        public virtual DbSet<WorkFlowActorUser> WorkFlowActorUsers { get; set; }

        public virtual DbSet<WorkFlowHistory> WorkFlowHistories { get; set; }

        public virtual DbSet<WorkFlowType> WorkFlowTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("server=.;Initial Catalog=SIMA;Integrated Security=true;Trusted_Connection=true;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkFlowActorConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkFlowConfiguration).Assembly);

            modelBuilder.Entity<Domain.Models.WorkFlow.Entities.Action>(entity =>
            {
                entity.ToTable("Action", "Project");

                entity.Property(e => e.Id).HasColumnName("ID");
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

                entity.HasOne(d => d.WorkFlowNavigation).WithMany(p => p.Actions)
                    .HasForeignKey(d => d.WorkFlow)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Action_WorkFlow");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project", "Project");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ActiveStatusId).HasColumnName("ActiveStatusID");
                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DomainId).HasColumnName("DomainID");
                entity.Property(e => e.ModifiedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectGroup>(entity =>
            {
                entity.ToTable("ProjectGroup", "Project");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ActiveStatusId).HasColumnName("ActiveStatusID");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.GroupId).HasColumnName("GroupID");
                entity.Property(e => e.ModifiedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            });

            modelBuilder.Entity<ProjectMember>(entity =>
            {
                entity.ToTable("ProjectMember", "Project");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ActiveStatusId).HasColumnName("ActiveStatusID");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.IsAdminProject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.IsManager)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.ModifiedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Project).WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectMember_Project");
            });

            modelBuilder.Entity<RejectionReason>(entity =>
            {
                entity.ToTable("RejectionReason", "Project");

                entity.HasIndex(e => e.Code, "index_code").IsUnique();

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
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.HasOne(d => d.Step).WithMany(p => p.RejectionReasons)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RejectionReason_Step");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State", "Project");

                entity.HasIndex(e => e.Code, "index_code").IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ActiveStatusId).HasColumnName("ActiveStatusID");
                entity.Property(e => e.Code).HasMaxLength(50);
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Name).HasMaxLength(200);
                entity.Property(e => e.WorkFlowId).HasColumnName("WorkFlowID");

                entity.HasOne(d => d.WorkFlow).WithMany(p => p.States)
                    .HasForeignKey(d => d.WorkFlowId)
                    .HasConstraintName("FK_State_WorkFlow");
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.ToTable("Step", "Project");

                entity.HasIndex(e => e.Code, "index_code").IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ActiveStatusId).HasColumnName("ActiveStatusID");
                entity.Property(e => e.Code).HasMaxLength(50);
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(4000);
                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.IsAttachmentRequired)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.IsLastStep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.IsSetReciverRequired)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.MainEntityId).HasColumnName("MainEntityID");
                entity.Property(e => e.ModifiedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Name).HasMaxLength(200);
                entity.Property(e => e.StateId).HasColumnName("StateID");
                entity.Property(e => e.WorkFlowId).HasColumnName("WorkFlowID");

                entity.HasOne(d => d.State).WithMany(p => p.Steps)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Step_State");

                entity.HasOne(d => d.WorkFlow).WithMany(p => p.Steps)
                    .HasForeignKey(d => d.WorkFlowId)
                    .HasConstraintName("FK_Step_WorkFlow");
            });

            modelBuilder.Entity<WorkFlow>(entity =>
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
            });

           

            modelBuilder.Entity<WorkFlowActorGroup>(entity =>
            {
                entity.ToTable("WorkFlowActorGroup", "Project");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ActiveStatusId).HasColumnName("ActiveStatusID");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.GroupId).HasColumnName("GroupID");
                entity.Property(e => e.ModifiedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.WorkFlowActorId).HasColumnName("WorkFlowActorID");

                entity.HasOne(d => d.WorkFlowActor).WithMany(p => p.WorkFlowActorGroups)
                    .HasForeignKey(d => d.WorkFlowActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkFlowActorGroup_WorkFlowActorUser");
            });

            modelBuilder.Entity<WorkFlowActorRole>(entity =>
            {
                entity.ToTable("WorkFlowActorRole", "Project");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ActiveStatusId).HasColumnName("ActiveStatusID");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.RoleId).HasColumnName("RoleID");
                entity.Property(e => e.WorkFlowActorId).HasColumnName("WorkFlowActorID");

                entity.HasOne(d => d.WorkFlowActor).WithMany(p => p.WorkFlowActorRoles)
                    .HasForeignKey(d => d.WorkFlowActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkFlowActorRole_WorkFlowActor");
            });

            modelBuilder.Entity<WorkFlowActorStep>(entity =>
            {
                entity.ToTable("WorkFlowActorStep", "Project");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ActiveStatusId).HasColumnName("ActiveStatusID");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.StepId).HasColumnName("StepID");
                entity.Property(e => e.WorkFlowActorId).HasColumnName("WorkFlowActorID");

                entity.HasOne(d => d.Step).WithMany(p => p.WorkFlowActorSteps)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkFlowActorStep_Step");

                entity.HasOne(d => d.WorkFlowActor).WithMany(p => p.WorkFlowActorSteps)
                    .HasForeignKey(d => d.WorkFlowActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkFlowActorStep_WorkFlowActor");
            });

            modelBuilder.Entity<WorkFlowActorUser>(entity =>
            {
                entity.ToTable("WorkFlowActorUser", "Project");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ActiveStatusId).HasColumnName("ActiveStatusID");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.Property(e => e.WorkFlowActorId).HasColumnName("WorkFlowActorID");

                entity.HasOne(d => d.WorkFlowActor).WithMany(p => p.WorkFlowActorUsers)
                    .HasForeignKey(d => d.WorkFlowActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkFlowActorUser_WorkFlowActor");
            });

            modelBuilder.Entity<WorkFlowHistory>(entity =>
            {
                entity.ToTable("WorkFlowHistory", "Project");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ActiveStatusId).HasColumnName("ActiveStatusID");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(4000);
                entity.Property(e => e.DomainId).HasColumnName("DomainID");
                entity.Property(e => e.EndPointStateId).HasColumnName("EndPointStateID");
                entity.Property(e => e.EndPointStepId).HasColumnName("EndPointStepID");
                entity.Property(e => e.EndPointUserId).HasColumnName("EndPointUserID");
                entity.Property(e => e.EndWorkFlowActorId).HasColumnName("EndWorkFlowActorID");
                entity.Property(e => e.IsAttachmentRequired)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.IsLastStep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.IsSetReceiverRequired)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.MainEntityId).HasColumnName("MainEntityID");
                entity.Property(e => e.MainEntityRecordId).HasColumnName("MainEntityRecordID");
                entity.Property(e => e.ModifiedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.RejectionReasonId).HasColumnName("RejectionReasonID");
                entity.Property(e => e.StartPointUserId).HasColumnName("StartPointUserID");
                entity.Property(e => e.StatId).HasColumnName("StatID");
                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.HasOne(d => d.EndPointState).WithMany(p => p.WorkFlowHistoryEndPointStates)
                    .HasForeignKey(d => d.EndPointStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkFlowHistory_State_endpoint");

                entity.HasOne(d => d.EndPointStep).WithMany(p => p.WorkFlowHistoryEndPointSteps)
                    .HasForeignKey(d => d.EndPointStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkFlowHistory_Step_endpoint");

                entity.HasOne(d => d.EndWorkFlowActor).WithMany(p => p.WorkFlowHistories)
                    .HasForeignKey(d => d.EndWorkFlowActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkFlowHistory_WorkFlowActorUser_endpoint");

                entity.HasOne(d => d.RejectionReason).WithMany(p => p.WorkFlowHistories)
                    .HasForeignKey(d => d.RejectionReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkFlowHistory_RejectionReason");

                entity.HasOne(d => d.Stat).WithMany(p => p.WorkFlowHistoryStats)
                    .HasForeignKey(d => d.StatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkFlowHistory_State");

                entity.HasOne(d => d.StatNavigation).WithMany(p => p.WorkFlowHistoryStatNavigations)
                    .HasForeignKey(d => d.StatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkFlowHistory_Step");
            });

            modelBuilder.Entity<WorkFlowType>(entity =>
            {
                entity.ToTable("WorkFlowType", "Project");

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ID");
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
            });

        }
    }
}
