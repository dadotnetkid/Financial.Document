using System.Web;

namespace FDTS.Helpers
{
    public class ControllerHelper
    {
        // private RouteData routeData;

        public ControllerHelper()
        {

        }
        public static bool IsControllerName(params string[] ControllerName)
        {
            var httpContext = new HttpContextWrapper(HttpContext.Current);
            var routeData = System.Web.Routing.RouteTable.Routes.GetRouteData(httpContext);
            foreach (var i in ControllerName)
            {
                if (routeData != null && routeData.Values["Controller"].ToString().ToLower() == i.ToLower())
                {
                    return true;

                }

            }
            return false;
        }
        public static bool IsActionName(params string[] ActionName)
        {
            var httpContext = new HttpContextWrapper(HttpContext.Current);
            var routeData = HttpContext.Current.Request.RequestContext.RouteData.Values["action"]?.ToString().ToLower();
            foreach (var i in ActionName)
            {
                if (routeData == i)
                {
                    return true;
                }

            }
            return false;
        }
        public static bool IsMenuBarActive(string ActionName, string ControllerName)
        {
            var httpContext = new HttpContextWrapper(HttpContext.Current);
            var actionName = HttpContext.Current.Request.RequestContext.RouteData.Values["action"]?.ToString().ToLower();
            var controllerName = System.Web.Routing.RouteTable.Routes.GetRouteData(httpContext).Values["Controller"].ToString().ToLower();
            if (actionName == ActionName.ToLower() && controllerName == ControllerName.ToLower())
            {
                return true;
            }

            return false;
        }
    }
}
