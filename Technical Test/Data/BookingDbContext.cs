﻿using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Technical_Test.Models;
using static NuGet.Packaging.PackagingConstants;

namespace Technical_Test.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ManagerLogistics> Managers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Project> Project { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // entitas unique
            modelBuilder.Entity<User>()
                      .HasIndex(u => new
                      {
                          u.UserID,
                          u.Email,
                      }).IsUnique();

            modelBuilder.Entity<Company>()
                     .HasIndex(u => new
                     {
                         u.CompanyID,
                         u.CompanyEmail,
                     }).IsUnique();

            modelBuilder.Entity<ManagerLogistics>()
                       .HasIndex(u => new
                       {
                           u.ManagerID,
                           u.ManagerEmail,
                       }).IsUnique();

            modelBuilder.Entity<Vendor>()
                       .HasIndex(u => new
                       {
                           u.VendorID
                       }).IsUnique();


            modelBuilder.Entity<Project>()
                        .HasIndex(u => new
                        {
                            u.ProjectID
                        }).IsUnique();

            //Untuk Foto
            modelBuilder.Entity<Company>()
            .Property(p => p.CompanyPhoto)
            .HasColumnType("varbinary(255)"); // Use varbinary for MySQL

            // Create Relation
            // Company - User (One to One)
            modelBuilder.Entity<User>()
                .HasOne(user => user.Company)
                .WithOne(company => company.User)
                .HasForeignKey<User>(user => user.CompanyID)
                .IsRequired(false); // User bisa tidak memiliki CompanyID

            // User - ManagerLogistics
            modelBuilder.Entity<User>()
                .HasOne(user => user.ManagerLogistics)
                .WithOne(manager => manager.User)
                .HasForeignKey<ManagerLogistics>(manager => manager.ManagerID)
                .IsRequired(false); // User bisa tidak memiliki ManagerID

            // User - Vendor (One to One)
            modelBuilder.Entity<Vendor>()
                .HasOne(vendor => vendor.User)
                .WithOne(user => user.Vendor)
                .HasForeignKey<User>(user => user.UserID);

            // Vendor - Project (One To Many)
            modelBuilder.Entity<Project>()
                .HasOne(project => project.Vendor)
                .WithMany(vendor => vendor.Projects)
                .HasForeignKey(project => project.VendorID);
        
        }

    }
}
