using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProGym.Infrastructure
{
    public class AppConfig
    {
        private static string _photosFolder = ConfigurationManager.AppSettings["PhotosFolder"];

        public static string PhotosFolder
        {
            get
            {
                return _photosFolder;
            }
        }

    }
}