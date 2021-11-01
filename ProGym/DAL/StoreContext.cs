using Microsoft.AspNet.Identity.EntityFramework;
using ProGym.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<TypeOfTicket> TypeOfTickets { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}