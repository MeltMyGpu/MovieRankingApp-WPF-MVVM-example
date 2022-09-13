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
        public DbSet<Customer> Customers {get; set;}

        public string DbPath { get; }

        public CustomerDbContext()
        {
            Database.EnsureCreated();
            var FileName = "DbTestDatabse.db";
            var DbPath = Path.Combine(Environment.CurrentDirectory, @"\", FileName); // Gets the applications current directory location
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //DbPath = System.IO.Path.Join(path, "customers.db");f

        }

        // Following configuers EF to create a SQLite database file in the 'special local' file.
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
        

    }
}
