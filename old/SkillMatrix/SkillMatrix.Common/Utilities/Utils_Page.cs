using System;
using System.Net;
using System.Web;

namespace SkillMatrix.Common
{
    public partial class Utilities
    {
        public static bool TenantExist(HttpContext ctx)
        {
            var request = ctx.Request;
            var tenant = GetSubDomain(request.Url);
            return !string.IsNullOrEmpty(tenant);
        }

        public static string GetCurrentTenant(HttpRequestBase request)
        {
            //var request = ctx.Request;
            var tenant = string.Empty;
            //var hostWeb = request.Url.Host.Split(':')[0];

            //var index = hostWeb.IndexOf(".", StringComparison.Ordinal);
            //if (index < 0) return tenant;
            //var subdomain = hostWeb.Substring(0, index);
            var subdomain = GetSubDomain(request.Url);
            if (subdomain!= null)
            {
            tenant  = subdomain;

            }
            return tenant.ToUpper();

        }

        public static string GetSubDomain(Uri url)
        {
            if (url.HostNameType == UriHostNameType.Dns)
            {
                string host = url.Host;
                if (host.StartsWith("www.")) return null;
                if (host.Split('.').Length > 2)
                {
                    int lastIndex = host.LastIndexOf(".");
                    int index = host.LastIndexOf(".", lastIndex - 1);
                    return host.Substring(0, index);
                }
            }

            return null;
        }

        /// <summary>
        /// Downloads a web page and returns the HTML as a string
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static HttpWebResponse DownloadWebPage(string url)
        {
            var ub = new UriBuilder(url);
            var request = (HttpWebRequest)WebRequest.Create(ub.Uri);
            request.Proxy = null;
            return (HttpWebResponse)request.GetResponse();
        }
    }
}
