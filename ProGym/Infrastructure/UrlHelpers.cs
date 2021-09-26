using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProGym.Infrastructure
{
    public static class UrlHelpers
    {
        public static string ProductPhotoPath(this UrlHelper helper, string productFileName )
        {
            var productPhotoFolder = AppConfig.PhotosFolder;
            var path = Path.Combine(productPhotoFolder, productFileName);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
    }
}