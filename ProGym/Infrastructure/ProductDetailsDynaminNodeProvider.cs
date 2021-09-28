using MvcSiteMapProvider;
using ProGym.DAL;
using ProGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProGym.Infrastructure
{
    public class ProductDetailsDynaminNodeProvider : DynamicNodeProviderBase
    {
        private StoreContext db = new StoreContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();
            foreach (Product product in db.Products)
            {
                DynamicNode n = new DynamicNode();
                n.Title = product.Name;
                n.Key = "Product_" + product.ProductID;
                n.ParentKey = "Category_" + product.CategoryID;
                n.RouteValues.Add("id", product.ProductID);
                returnValue.Add(n);
            }

            return returnValue;
        }
    }
}