using GroupDocs.Editor.WebForms.Products.Common.Config;
using GroupDocs.Editor.WebForms.Products.Common.Util.Parser;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace GroupDocs.Editor.WebForms.Products.Editor.Config
{
    /// <summary>
    /// EditorConfiguration
    /// </summary>
    public class EditorConfiguration : CommonConfiguration
    {
        [JsonProperty]
        private string filesDirectory = "DocumentSamples/Editor";

        [JsonProperty]
        private string fontsDirectory = "";

        [JsonProperty]
        private string defaultDocument = "";

        [JsonProperty]
        private bool createNewFile = true;

        /// <summary>
        /// Constructor
        /// </summary>
        public EditorConfiguration()
        {
            YamlParser parser = new YamlParser();
            dynamic configuration = parser.GetConfiguration("editor");
            ConfigurationValuesGetter valuesGetter = new ConfigurationValuesGetter(configuration);

            // get Viewer configuration section from the web.config
            filesDirectory = valuesGetter.GetStringPropertyValue("filesDirectory", filesDirectory);
            if (!IsFullPath(filesDirectory))
            {
                filesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filesDirectory);
                if (!Directory.Exists(filesDirectory))
                {
                    Directory.CreateDirectory(filesDirectory);
                }
            }
            fontsDirectory = valuesGetter.GetStringPropertyValue("fontsDirectory", fontsDirectory);
            defaultDocument = valuesGetter.GetStringPropertyValue("defaultDocument", defaultDocument);
            createNewFile = valuesGetter.GetBooleanPropertyValue("createNewFile", createNewFile);
        }

        private static bool IsFullPath(string path)
        {
            return !String.IsNullOrWhiteSpace(path)
                && path.IndexOfAny(System.IO.Path.GetInvalidPathChars().ToArray()) == -1
                && Path.IsPathRooted(path)
                && !Path.GetPathRoot(path).Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
        }

        public void SetFilesDirectory(string filesDirectory)
        {
            this.filesDirectory = filesDirectory;
        }

        public string GetFilesDirectory()
        {
            return filesDirectory;
        }

        public void SetFontsDirectory(string fontsDirectory)
        {
            this.fontsDirectory = fontsDirectory;
        }

        public string GetFontsDirectory()
        {
            return fontsDirectory;
        }

        public void SetDefaultDocument(string defaultDocument)
        {
            this.defaultDocument = defaultDocument;
        }

        public string GetDefaultDocument()
        {
            return defaultDocument;
        }   
        
        public bool GetCreateNewFile()
        {
            return createNewFile;
        }
    }
}