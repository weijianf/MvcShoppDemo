using System.Web;
using System.Web.Mvc;

namespace NF.WJF.Shopp.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}