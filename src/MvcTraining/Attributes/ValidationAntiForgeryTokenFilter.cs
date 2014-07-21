using System.Linq;
using System.Web.Mvc;

namespace MvcTraining.Attributes
{
    public class ValidationAntiForgeryTokenFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (GetHttpMethod(filterContext) == "get")
            {
                return;
            }
            if (!ShouldValidate(filterContext))
            {
                return;
            }
            var filterAttribute = new ValidateAntiForgeryTokenAttribute();
            filterAttribute.OnAuthorization(filterContext);
        }

        private static string GetHttpMethod(AuthorizationContext filterContext)
        {
            return filterContext.RequestContext
                .HttpContext.Request
                .GetHttpMethodOverride().ToLowerInvariant();
        }

        private bool ShouldValidate(AuthorizationContext filterContext)
        {
            return !filterContext.ActionDescriptor
                .GetCustomAttributes(typeof (DoNotValidateAntiForgeryToken), true).Any();
        }
    }
}