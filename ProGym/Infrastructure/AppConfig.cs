using System.Configuration;

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