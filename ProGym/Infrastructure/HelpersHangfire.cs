using System.Net;

namespace ProGym.Infrastructure
{
    public class HelpersHangfire
    {
        public static void CallUrl(string serviceUrl)
        {
            var req = HttpWebRequest.Create(serviceUrl);
            req.GetResponseAsync();
        }

        public static void CallUrl2(string serviceUrl)
        {            
            const string path = "https://localhost:44381/";
            var req = HttpWebRequest.Create(path + serviceUrl);
            req.GetResponseAsync();
        }
    }
}