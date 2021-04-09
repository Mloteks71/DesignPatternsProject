using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZTPProject
{
    public class ZTPContext : DbContext
    {
    public DbSet<StanGry> StanGry { get; set; }
        public DbSet<Wyniki> Wyniki { get; set; }

        public ZTPContext(DbContextOptions<ZTPContext> options) : base(options)
        {
            Database.EnsureCreated();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<StanGry>();
            modelBuilder.Entity<Wyniki>();
            base.OnModelCreating(modelBuilder);
        }

    }
}

