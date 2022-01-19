using System.Web;
using System.Web.Mvc;

namespace FOR_LATEST_ONE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
