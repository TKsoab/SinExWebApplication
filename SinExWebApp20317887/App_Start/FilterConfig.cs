using System.Web;
using System.Web.Mvc;

namespace SinExWebApp20317887
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
