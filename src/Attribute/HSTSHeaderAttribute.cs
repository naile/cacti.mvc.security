using System;
using System.Net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Cacti.Mvc.Security
{

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class HstsHeaderAttribute : ActionFilterAttribute
    {
        public int MaxAge { get; set; }

        public HstsHeaderAttribute()
        {
            MaxAge = 31536000; // 12 months
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            switch (actionContext.Request.RequestUri.Scheme)
            {
                case "https":
                    actionContext.Response.Headers.Add("Strict-Transport-Security", "max-age= " + MaxAge); 
                    break;
                case "http":
                    var path = "https://" + actionContext.Request.RequestUri.Host + actionContext.Request.RequestUri.PathAndQuery;
                    actionContext.Response.StatusCode = HttpStatusCode.MovedPermanently;
                    actionContext.Response.Headers.Add("Location", path);
                    break;
            }
            
        }
    }
}
