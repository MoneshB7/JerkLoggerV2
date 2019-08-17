using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace JLogger.CrossPlatform.Models
{
    public partial class JerkdbContext : DbContext
    {
        public JerkdbContext()
        {
        }

        public JerkdbContext(DbContextOptions<JerkdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jlog> Jlog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json");
                var config = builder.Build();
                var connectionString = config.GetConnectionString("JLogDatabase");

                optionsBuilder.UseSqlServer("Data Source =(localdb)\\ProjectsV13;Initial Catalog=Jerkdb;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Jlog>(entity =>
            {
                entity.HasKey(e => e.Date);

                entity.ToTable("JLog");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNo).ValueGeneratedOnAdd();
            });
        }
    }
}
