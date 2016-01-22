﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MvcTest.Web.App_Start;

namespace MvcTest.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperWebConfiguration.Configure();
        }
    }
}