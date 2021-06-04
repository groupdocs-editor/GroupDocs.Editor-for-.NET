using System;
using System.Web;
using System.Web.Routing;
using System.Web.Http;
using GroupDocs.Editor.WebForms.AppDomainGenerator;

namespace GroupDocs.Editor.WebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Fix required to use several GroupDocs products in one project.
            // Set GroupDocs products assemblies names           
            string editorAssemblyName = "GroupDocs.Editor.dll";           
            // set GroupDocs.Editor license
            DomainGenerator editorDomainGenerator = new DomainGenerator(editorAssemblyName, "GroupDocs.Editor.License");
            editorDomainGenerator.SetEditorLicense();

            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}