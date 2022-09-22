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

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Prioritized> Prioritizeds { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
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
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.HasMany(d => d.Workings)
                    .WithMany(p => p.Categories)
                    .UsingEntity<Dictionary<string, object>>(
                        "CategoryWork",
                        l => l.HasOne<Working>().WithMany().HasForeignKey("WorkingId").HasConstraintName("FK_CategoryWork_Working"),
                        r => r.HasOne<Category>().WithMany().HasForeignKey("CategoryId").HasConstraintName("FK_CategoryWork_Category"),
                        j =>
                        {
                            j.HasKey("CategoryId", "WorkingId");

                            j.ToTable("CategoryWork");
                        });
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.GenderName).HasMaxLength(50);
            });

            modelBuilder.Entity<Prioritized>(entity =>
            {
                entity.ToTable("Prioritized");

                entity.Property(e => e.PrioritizedName).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName).HasMaxLength(50);

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Roles)
                    .UsingEntity<Dictionary<string, object>>(
                        "RoleUser",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_RoleUser_User"),
                        r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId").HasConstraintName("FK_RoleUser_Role"),
                        j =>
                        {
                            j.HasKey("RoleId", "UserId");

                            j.ToTable("RoleUser");
                        });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(12);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(500);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_User_Gender");

                entity.HasMany(d => d.Workings)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserWork",
                        l => l.HasOne<Working>().WithMany().HasForeignKey("WorkingId").HasConstraintName("FK_UserWork_Working"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_UserWork_User"),
                        j =>
                        {
                            j.HasKey("UserId", "WorkingId");

                            j.ToTable("UserWork");
                        });
            });

            modelBuilder.Entity<Working>(entity =>
            {
                entity.ToTable("Working");

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.UserConfirm).HasMaxLength(50);

                entity.Property(e => e.WorkingName).HasMaxLength(500);

                entity.HasOne(d => d.Prioritized)
                    .WithMany(p => p.Workings)
                    .HasForeignKey(d => d.PrioritizedId)
                    .HasConstraintName("FK_WorkAndUser_Prioritized");

                entity.HasOne(d => d.WorkingStatus)
                    .WithMany(p => p.Workings)
                    .HasForeignKey(d => d.WorkingStatusId)
                    .HasConstraintName("FK_WorkAndUser_WorkingStatus");
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
