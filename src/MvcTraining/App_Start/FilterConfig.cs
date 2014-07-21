using System.Web;
using System.Web.Mvc;
using MvcTraining.Attributes;

namespace MvcTraining
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ValidationAntiForgeryTokenFilter());
        }
    }
}
