using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Net.Http;

namespace Cacti.Mvc.Security
{
    public class SkipCSRFCheckAttribute : Attribute
    { }

    /// <summary>
    /// Require AntiForgeryToken on POST request.
    /// </summary>
    public class AntiForgeryTokenFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (IsHttpPostRequest(filterContext) && !SkipCsrfCheck(filterContext))
            {
                AntiForgery.Validate();
            }
        }

        private static bool IsHttpPostRequest(ControllerContext filterContext)
        {
            return filterContext.RequestContext.HttpContext.Request.HttpMethod == HttpMethod.Post.ToString();
        }

        private static bool SkipCsrfCheck(AuthorizationContext filterContext)
        {
            return filterContext.ActionDescriptor.GetCustomAttributes(typeof(SkipCSRFCheckAttribute), false).Any();
        }
    }
}
