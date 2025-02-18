﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace stpApp.BusinessLogic
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Guest> Guests { get; set; } = null!;
        public virtual DbSet<Pixel> Pixels { get; set; } = null!;
        public virtual DbSet<UserAcc> UserAccs { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(entity =>
            {
                entity.ToTable("Guest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ipAddress");

                entity.Property(e => e.LastPlace)
                    .HasColumnType("datetime")
                    .HasColumnName("lastPlace");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(sysdatetime())");
            });

            modelBuilder.Entity<Pixel>(entity =>
            {
                entity.ToTable("Pixel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("updatedBy");
            });

            modelBuilder.Entity<UserAcc>(entity =>
            {
                entity.ToTable("UserAcc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.LastPlace)
                    .HasColumnType("datetime")
                    .HasColumnName("lastPlace");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });
            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.Property(e => e.messageContents)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(sysdatetime())");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}
