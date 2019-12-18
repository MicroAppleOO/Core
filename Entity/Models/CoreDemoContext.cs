using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entity.Models
{
    public partial class CoreDemoContext : DbContext
    {
        public CoreDemoContext()
        {
        }

        public CoreDemoContext(DbContextOptions<CoreDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<PersonInfor> PersonInfor { get; set; }

 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.LogUid);

                entity.Property(e => e.LogUid)
                    .HasColumnName("Log_Uid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.LogContextType).HasColumnName("Log_ContextType");

                entity.Property(e => e.LogHost).HasColumnName("Log_Host");

                entity.Property(e => e.LogMethod).HasColumnName("Log_Method");

                entity.Property(e => e.LogName).HasColumnName("Log_Name");

                entity.Property(e => e.LogParameter).HasColumnName("Log_Parameter");

                entity.Property(e => e.LogPath).HasColumnName("Log_Path");

                entity.Property(e => e.LogScheme).HasColumnName("Log_Scheme");

                entity.Property(e => e.LogStatus).HasColumnName("Log_Status");
                entity.Property(e => e.Log_Info).HasColumnName("Log_Info");

                entity.Property(e => e.LogTime)
                    .HasColumnName("Log_Time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<PersonInfor>(entity =>
            {
                entity.ToTable("personInfor");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
