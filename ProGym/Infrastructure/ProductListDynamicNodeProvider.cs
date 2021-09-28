using MvcSiteMapProvider;
using ProGym.DAL;
using ProGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProGym.Infrastructure
{
    public class ProductListDynamicNodeProvider : DynamicNodeProviderBase
    {
        private StoreContext db = new StoreContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();
            foreach (Category category in db.Categories)
            {
                DynamicNode n = new DynamicNode();
                n.Title = category.CategoryName;
                n.Key = "Category_" + category.CategoryID;
                n.RouteValues.Add("categoryname", category.CategoryName);
                returnValue.Add(n);
            }

            return returnValue;
        }
    }
}