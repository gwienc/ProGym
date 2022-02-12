using Microsoft.AspNet.Identity.EntityFramework;
using ProGym.Models;
using System.Data.Entity;

namespace ProGym.DAL
{
    public class StoreContext : IdentityDbContext<ApplicationUser>
    {
        public StoreContext() :base("StoreContext")
        {

        }

        static StoreContext()
        {
            Database.SetInitializer<StoreContext>(new StoreInitializer());
        }

        public static StoreContext Create()
        {
            return new StoreContext();
        }

        public  DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public  DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public  DbSet<TypeOfTicket> TypeOfTickets { get; set; }
        public  DbSet<Ticket> Tickets { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}