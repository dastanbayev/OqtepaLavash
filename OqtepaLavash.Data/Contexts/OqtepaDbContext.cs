

using Microsoft.EntityFrameworkCore;
using OqtepaLavash.Domain.Entities.Customers;
using OqtepaLavash.Domain.Entities.Employees;
using OqtepaLavash.Domain.Entities.Orders;

namespace OqtepaLavash.Data.Contexts
{
    public class OqtepaDbContext : DbContext
    {
#pragma warning disable
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String connectionString = "Server=127.0.0.1;Port=5432;Database=OqtepaLavash_net6;Username=postgres;Password=postmiddle;";

            optionsBuilder.UseNpgsql(connectionString);
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
