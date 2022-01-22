using System.Web;
using System.Web.Mvc;

namespace CrudOperationWith_WebApi_In_Structure
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
