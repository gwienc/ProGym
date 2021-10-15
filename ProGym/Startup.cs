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

            //JobStorage.Current = new SqlServerStorage("StoreContext");
            //app.UseHangfireDashboard();
            //app.UseHangfireServer();
        }
    }
}