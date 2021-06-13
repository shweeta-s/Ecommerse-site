using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using POC.Entities;
namespace POC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Item>().HasKey( x => new { x.cart_id,x.product_id});
            
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Users> Users { get; set; }       
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Categories> Categories { get; set; }  
        public DbSet<Product> Product { get; set; }
        public DbSet<Item> Item { get; set; }

    }   
}
