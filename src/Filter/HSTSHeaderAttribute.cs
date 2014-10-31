using System.Net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Cacti.Mvc.Security
{
    public class HstsHeaderAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            switch (actionContext.Request.RequestUri.Scheme)
            {
                case "https":
                    actionContext.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000 "); // 12 months
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
