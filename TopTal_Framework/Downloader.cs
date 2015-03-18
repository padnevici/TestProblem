using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace TopTal_Framework
{
    public class Downloader : WebClient
    {
        public CookieContainer CookieContainer { get; set; }

        public Downloader()
            : base()
        {
            CookieContainer = new CookieContainer();
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);

            HttpWebRequest webRequest = request as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.CookieContainer = CookieContainer;
            }

            return request;
        }
    }
}
