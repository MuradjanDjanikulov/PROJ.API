﻿using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //           modelBuilder.Entity<Employee>().Property(e => e.Email).HasDefaultValueSql("'test@mail.com'");

            //           modelBuilder.Entity<Address>().HasData(new Address(999, "Navoiy street", "UZB", "TASH"));

            //Add-Migration and Update-Databse
        }
    }
}
