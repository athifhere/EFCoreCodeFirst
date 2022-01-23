using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCRUDTest
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set;}

        public DbSet<Account> Account { get; set;}

        public DbSet<Teams> Team { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-7OCUR3A;Initial Catalog=Project;Integrated Security=True");
            }
        }
    }
}
