using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class ProjectDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }
       public DbSet<Model> Models { get; set; }

        public ProjectDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            Add-Migration InitialCreate -Context ProjectDbContext -OutputDir Migrations/Pg
            $env:ASPNETCORE_ENVIRONMENT='Staging'
            Update-Database -context ProjectDbContext
             */
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MssqlConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Entity Framework Fluent mapping
            #region Brands
            modelBuilder.Entity<Brand>(a =>
            {
                a.ToTable("Brands").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name").HasMaxLength(100);
                a.HasMany(p => p.Models);
            });
            Brand[] brandEntitySeeds = { new(1, "Ford"), new(2, "Tesla") };
            modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);
            #endregion
            #region Models
            modelBuilder.Entity<Model>(a =>
            {
                a.ToTable("Models").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.BrandId).HasColumnName("BrandId");
                a.Property(p => p.Name).HasColumnName("Name").HasMaxLength(100);
                a.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
                a.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
                a.HasOne(p => p.Brand);
            });
            Model[] modelsEntityModels = { new(1, 1, "Ranger", decimal.Parse("1568"), "") };
            modelBuilder.Entity<Model>().HasData(modelsEntityModels);
            #endregion
        }
    }
}

