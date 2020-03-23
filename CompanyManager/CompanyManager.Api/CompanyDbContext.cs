using System;
using System.Collections.Generic;
using System.Text;
using CompanyManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Api
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            : base(options) { }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
