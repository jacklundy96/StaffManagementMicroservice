using Microsoft.EntityFrameworkCore;
using StaffManagementMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagementMicroservice.DB
{
    public class StaffPermContext : DbContext
    {
        public StaffPermContext(DbContextOptions<StaffPermContext> options) : base(options)
        {
        }

        public DbSet<Models.StaffPermissions> StaffPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffPermissions>().ToTable("StaffPermissions");
        }
    }
}

