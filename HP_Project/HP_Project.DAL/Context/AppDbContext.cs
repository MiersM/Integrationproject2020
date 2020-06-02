using HP_Project.DAL.Context;
using HP_Project.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ApolloRow> Apollo { get; set; }
        public DbSet<ClientEmployee> ClientEmployees { get; set; }
        public DbSet<InstallBase> InstallBase { get; set; }
        public DbSet<ProductHierarchy> ProductHierarchy { get; set; }
        public DbSet<RAD> RAD { get; set; }
        public DbSet<RevenueActuals> RevenueActuals { get; set; }
        public DbSet<TerritoryCompany> TerritoryCompany { get; set; }
        public DbSet<Workday> Workday { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Touchpoint> Touchpoints { get; set; }

        public DbSet<Insight> Insights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
