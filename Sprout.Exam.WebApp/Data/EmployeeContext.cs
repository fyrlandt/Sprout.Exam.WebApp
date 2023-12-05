using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Sprout.Exam.WebApp.Data
{
    public class EmployeeContext : IdentityDbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<RegularEmployee>();
            modelBuilder.Entity<ContractualEmployee>();

            modelBuilder.Entity<Employee>().HasDiscriminator(x => x.EmployeeTypeId)
                .HasValue<RegularEmployee>((int)EmployeeType.Regular)
                .HasValue<ContractualEmployee>((int)EmployeeType.Contractual);

            base.OnModelCreating(modelBuilder);
        }
    }
}
