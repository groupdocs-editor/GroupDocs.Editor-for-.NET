using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using TinyMce.MvcSample.Models;

namespace TinyMce.MvcSample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            var licensePath = ConfigurationManager.AppSettings["licensePath"];
            var samplesFolder = ConfigurationManager.AppSettings["samplesFolder"];
            var storagePath = ConfigurationManager.AppSettings["storagePath"];

            InitData initData = new InitData(licensePath, samplesFolder, storagePath);

            initData.SetStoragePath(Server.MapPath(initData.StorageSubpath));
            this.Session.Add("initData", initData);
        }
    }
}
