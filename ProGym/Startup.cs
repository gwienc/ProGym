using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Owin;
using ProGym.DAL;
using ProGym.Infrastructure;
using System;
using System.Linq;

namespace ProGym
{
    public partial class Startup
    {
        StoreContext db = new StoreContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var options = new DashboardOptions
            {
                Authorization = new[]
                {
                    new AuthorizationFilter {Roles = "Admin" }

                }
            };

            JobStorage.Current = new SqlServerStorage("StoreContext");
            app.UseHangfireDashboard("/hangfire", options);
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate(() => CheckActiveTickets(), "0 0 */1 ? * *");
        }

        public void CheckActiveTickets()
        {
            var tickets = db.Tickets.ToList();

            foreach (var ticket in tickets)
            {
                if (ticket.ExpirationDate < DateTime.Now && ticket.IsActive == true)
                {
                    ticket.IsActive = false;

                    db.SaveChanges();

                    IMailService mailService = new HangFirePostalMailService();
                    mailService.TicketInactiveInformationEmail(ticket);
                }
            }
        }
    }
}