using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiProject.Models
{
    public partial class TestTek4TvContext : DbContext
    {
        public TestTek4TvContext()
        {
        }

        public TestTek4TvContext(DbContextOptions<TestTek4TvContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Prioritized> Prioritizeds { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WorkAndUser> WorkAndUsers { get; set; } = null!;
        public virtual DbSet<Working> Workings { get; set; } = null!;
        public virtual DbSet<WorkingStatus> WorkingStatuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-RIDQL5T7\\SQLEXPRESS;Database=TestTek4Tv;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prioritized>(entity =>
            {
                entity.ToTable("Prioritized");

                entity.Property(e => e.PrioritizedName).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(12);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Passwork).HasMaxLength(500);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<WorkAndUser>(entity =>
            {
                entity.HasKey(e => e.WorkingId);

                entity.ToTable("WorkAndUser");

                entity.Property(e => e.WorkingId).ValueGeneratedNever();

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.WorkingName).HasMaxLength(500);

                entity.HasOne(d => d.Prioritized)
                    .WithMany(p => p.WorkAndUsers)
                    .HasForeignKey(d => d.PrioritizedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkAndUser_Prioritized");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorkAndUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkAndUser_User");

                entity.HasOne(d => d.Working)
                    .WithOne(p => p.WorkAndUser)
                    .HasForeignKey<WorkAndUser>(d => d.WorkingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkAndUser_Working");

                entity.HasOne(d => d.WorkingStatus)
                    .WithMany(p => p.WorkAndUsers)
                    .HasForeignKey(d => d.WorkingStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkAndUser_WorkingStatus");
            });

            modelBuilder.Entity<Working>(entity =>
            {
                entity.ToTable("Working");

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.WorkingName).HasMaxLength(500);
            });

            modelBuilder.Entity<WorkingStatus>(entity =>
            {
                entity.ToTable("WorkingStatus");

                entity.Property(e => e.WorkingStatusName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
