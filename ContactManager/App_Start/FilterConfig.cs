using ContactManager.Controllers;
using System.Web.Mvc;

namespace ContactManager
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AiHandleErrorAttribute());
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
