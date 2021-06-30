using GroupDocs.Editor.WebForms.Products.Editor.Config;

namespace GroupDocs.Editor.WebForms.Products.Common.Config
{
    /// <summary>
    /// Global configuration
    /// </summary>
    public class GlobalConfiguration
    {
        private readonly ServerConfiguration Server;
        private readonly ApplicationConfiguration Application;
        private readonly CommonConfiguration Common;        
        private readonly EditorConfiguration Editor;

        /// <summary>
        /// Get all configurations
        /// </summary>
        public GlobalConfiguration()
        {            
            Server = new ServerConfiguration();
            Application = new ApplicationConfiguration();         
            Common = new CommonConfiguration();        
            Editor = new EditorConfiguration();
        }       

        public EditorConfiguration GetEditorConfiguration()
        {
            return Editor;
        }

        public ServerConfiguration GetServerConfiguration()
        {
            return Server;
        }

        public ApplicationConfiguration GetApplicationConfiguration()
        {
            return Application;
        }

        public CommonConfiguration GetCommonConfiguration()
        {
            return Common;
        }
    }
}