using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DBTest.Models;

namespace DBTest.Context
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<CustomerModel> Customers {get; set;}

        public string DbPath { get; }

        public CustomerDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData; // locates the 'local' folder on the platform
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "customers.db");

        }

        // Following configuers EF to create a SQLite database file in the 'special local' file.
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

    }
}
