using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Postal
{
    public static class HtmlExtensions
    {
        public static IHtmlString EmbedImage(this HtmlHelper html, string imagePathOrUrl, string alt, object htmlAttributes)
        {
            if (string.IsNullOrWhiteSpace(imagePathOrUrl)) throw new ArgumentException("Path or URL required", "imagePathOrUrl");

            if (IsFileName(imagePathOrUrl))
            {
                imagePathOrUrl = html.ViewContext.HttpContext.Server.MapPath(imagePathOrUrl);
            }
            var imageEmbedder = (ImageEmbedder)html.ViewData["Postal.ImageEmbedder"];
            var resource = imageEmbedder.ReferenceImage(imagePathOrUrl);

            TagBuilder mailtoAnchor = new TagBuilder("img");
            mailtoAnchor.MergeAttribute("src", "cid:" + resource.ContentId);
            mailtoAnchor.MergeAttribute("alt", alt);
            mailtoAnchor.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(mailtoAnchor.ToString());
        }

        static bool IsFileName(string pathOrUrl)
        {
            return !(pathOrUrl.StartsWith("http:", StringComparison.OrdinalIgnoreCase) || pathOrUrl.StartsWith("https:", StringComparison.OrdinalIgnoreCase));
        }
    }
}