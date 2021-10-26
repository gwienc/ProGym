using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProGym
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //app.UseHangfire(config =>
            //{
            //    config.UseAuthorizationFilters(new AuthorizationFilter
            //    {
            //        Roles = "Admin"

            //    });

            //    config.UseSqlServerStorage("StoreContext");
            //    config.UseServer();
            //});

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
        }
    }
}