using GroupDocs.Editor.WebForms.Products.Common.Config;
using System;
using System.Web;

namespace GroupDocs.Editor.WebForms
{
    public partial class Editor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalConfiguration globalConfiguration = new GlobalConfiguration();
            string filesPath = globalConfiguration.GetEditorConfiguration().GetFilesDirectory().Replace(AppDomain.CurrentDomain.BaseDirectory, "");
            if (System.Web.HttpContext.Current.Request.Url.AbsolutePath.Contains(filesPath)) {
                throw new HttpException(404, "File not found");
            }
        }
    }
}