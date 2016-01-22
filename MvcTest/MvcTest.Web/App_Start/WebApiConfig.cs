using System.Web.Http;

namespace MvcTest.Web
{

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { controller = "People", id = RouteParameter.Optional }
                );
        }
    }

}