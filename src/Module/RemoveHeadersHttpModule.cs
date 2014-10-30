using System;
using System.Web;

namespace Cacti.Mvc.Security.Module
{
    public class RemoveHeadersHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += OnPreSendRequestHeaders;
        }

        /// <summary>
        /// Remove Server and ASP-version headers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnPreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("Server");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("DWAS-Handler-Name");
        }

        public void Dispose()
        {

        }
    }
}
