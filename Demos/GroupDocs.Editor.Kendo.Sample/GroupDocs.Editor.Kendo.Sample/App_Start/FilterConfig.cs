using System.Web;
using System.Web.Mvc;

namespace GroupDocs.Editor.Kendo.Sample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
