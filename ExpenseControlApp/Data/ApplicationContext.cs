using Microsoft.EntityFrameworkCore;
using ExpenseControlApp.Models;

namespace ExpenseControlApp.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Categories> Categories { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExpensesAppDB;Trusted_Connection=True;");
        }
    }
}
