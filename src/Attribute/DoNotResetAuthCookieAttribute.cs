using System.Web.Mvc;
using System.Web.Security;

namespace Cacti.Mvc.Security
{
    ///<summary>
    /// Prevent the auth cookie from being reset for this action, allows you to
    /// have requests that do not reset the sliding login timeout.
    /// </summary>
    public class DoNotResetAuthCookieAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;
            response.Cookies.Remove(FormsAuthentication.FormsCookieName);
        }
    }
}
