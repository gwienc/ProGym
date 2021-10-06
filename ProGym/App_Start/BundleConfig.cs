using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ProGym.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundes)
        {
            bundes.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
        }
    }
}