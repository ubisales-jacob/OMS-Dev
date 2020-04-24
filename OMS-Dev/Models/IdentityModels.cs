﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OMS_Dev.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OMS_Dev.Models
{
    // ASP.Net Identity 'Users' Table, add custom user fields here e.g. public string FirstName { get; set; }
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    // The Entity Framework Core DbContext class represents a session with a database and provides an API for communicating with the database

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // Rename ASP.NET Identity tables from their default naming conventions
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        }

        // Get access to the DbContext, e.g. var db = ApplicationDbContext.Create();
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // employees table
        public DbSet<Employee> Employees { get; set; }

        // businesses table
        public DbSet<Business> Businesses { get; set; }

        // industries table
        public DbSet<Industry> Industries { get; set; }
    }
}