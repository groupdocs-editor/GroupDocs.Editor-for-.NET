using GroupDocs.Editor.MVC.AppDomainGenerator;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace GroupDocs.Editor.MVC
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Fix required to use several GroupDocs products in one project.
            // Set GroupDocs products assemblies names           
            string editorAssemblyName = "GroupDocs.Editor.dll";           
            // set GroupDocs.Editor license
            DomainGenerator editorDomainGenerator = new DomainGenerator(editorAssemblyName, "GroupDocs.Editor.License");
            editorDomainGenerator.SetEditorLicense();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }       
    }     
}