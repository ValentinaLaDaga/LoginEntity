using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LoginEntity.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace LoginEntity.Models.Services.Infrastructure
{
    public partial class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Iscritto> Iscritto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=Data/Utenti.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Iscritto>(entity =>
            {
                entity.ToTable("iscritto");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.Nazione)
                    .IsRequired()
                    .HasColumnName("nazione")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("VARCHAR(45)");

                //entity.HasKey(iscritto => iscritto.Id);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
