using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ProGym.Infrastructure
{
    public class HelpersHangfire
    {

        // metoda wysyłająca żądanie webowe pod wskazany w argumencie adres URL - Hangfire nie obsługuje helpera EmbedImage używanego do załączania zdjęć w mailach i to jest tego obejście,
        //hangfire najpierw wywołuje tę metodę, która wywołuję inną metodę wskazaną w argumencie, w której z kolei znajduje się właściwy kod z wysłaniem emaila
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