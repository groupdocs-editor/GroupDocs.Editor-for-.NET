using System.Web.Http;
using System.Web.Http.Cors;

namespace GroupDocs.Editor.MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {           
            // enable CORS
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();              
        }
    }
}
