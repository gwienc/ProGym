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

        //add virtual to unit tests
        public  DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //add virtual to unit tests
        public  DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        //add  to unit testss
        public  DbSet<TypeOfTicket> TypeOfTickets { get; set; }
        //add to unit tests
        public  DbSet<Ticket> Tickets { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<ApplicationUser>().HasRequired<Ticket>(t => t.Tickets).WithRequiredPrincipal(d => d.User);
        //}
    }
}