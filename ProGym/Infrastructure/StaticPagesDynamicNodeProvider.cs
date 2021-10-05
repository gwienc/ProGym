using MvcSiteMapProvider;
using ProGym.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProGym.Infrastructure
{
    public class StaticPagesDynamicNodeProvider : DynamicNodeProviderBase
    {
        
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();
            
            DynamicNode v = new DynamicNode();
            v.Title = "O nas";
            v.Key = "Page_" + 1;
            v.RouteValues.Add("viewname", "AboutUs");
            returnValue.Add(v);

            v = new DynamicNode();
            v.Title = "Kontakt";
            v.Key = "Page_" + 2;
            v.RouteValues.Add("viewname", "Contact");
            returnValue.Add(v);

            v = new DynamicNode();
            v.Title = "Zajęcia grupowe";
            v.Key = "Page_" + 3;
            v.RouteValues.Add("viewname", "GroupExercises");
            returnValue.Add(v);

            v = new DynamicNode();
            v.Title = "Zajęcia indywidualne";
            v.Key = "Page_" + 4;
            v.RouteValues.Add("viewname", "IndividualTraining");
            returnValue.Add(v);

            v = new DynamicNode();
            v.Title = "Cennik";
            v.Key = "Page_" + 5;
            v.RouteValues.Add("viewname", "Prices");
            returnValue.Add(v);

            v = new DynamicNode();
            v.Title = "Zajęcia z trenerem personalnym";
            v.Key = "Page_" + 6;
            v.RouteValues.Add("viewname", "TrainingPersonalTrainer");
            returnValue.Add(v);

            v = new DynamicNode();
            v.Title = "Strefa relaksu";
            v.Key = "Page_" + 7;
            v.RouteValues.Add("viewname", "Relaxation");
            returnValue.Add(v);

            return returnValue;
        }
    }
}