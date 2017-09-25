//ExStart:ConvertDocumentToHTMLDOMClass
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupDocs.Editor;
using GroupDocs.Editor.HtmlCss.Resources.Fonts;
using GroupDocs.Editor.HtmlCss.Resources.Images.Raster;
using GroupDocs.Editor.HtmlCss.Resources.Images.Vector;
using GroupDocs.Editor.HtmlCss.Resources.Textual;

namespace GroupDocs.Editor.Examples.CSharp
{
    /// <summary>
    /// Here are code samples to show how to convert document from source format to its HTML representation that can be edited in any WYSIWYG editor.
    /// </summary>
    class ConvertDocumentToHTMLDOM
    {
        //ExStart:GetHTMLContents
        /// <summary>
        /// Get HTML document content.
        /// </summary>
        public static void GetHTMLContents()
        {
            // Obtain document stream
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
            {
                // Obtain HTML document content
                string bodyContent = htmlDoc.GetContent();
                Console.WriteLine(bodyContent);
            }

            // close stream object to release file for other methods.
            sourceStream.Close();
        }
        //ExEnd:GetHTMLContents

        //ExStart:GetHTMLContentsWithExternalResources
        /// <summary>
        /// Get HTML document content with external resource prefix.
        /// </summary>
        public static void GetHTMLContentsWithExternalResources()
        {
            // Obtain document stream
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
            {
                string externalResourcePrefix = "GetResource?htmlDocumentFolderName=" + Common.sourceResourcesFolder + "&resourceFilename=Picture 3.png";

                // Obtain HTML document content   
                string bodyContent = htmlDoc.GetContent(externalResourcePrefix);
                Console.WriteLine(bodyContent);
            }

            // close stream object to release file for other methods.
            sourceStream.Close();
        }
        //ExEnd:GetHTMLContentsWithExternalResources

        //ExStart:GetHTMLContentsWithEmbeddedResources
        /// <summary>
        /// Get HTML document with embedded resources.
        /// </summary>
        public static void GetHTMLContentsWithEmbeddedResources()
        {
            // Obtain document stream
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
            {
                //  Obtain HTML document with embedded resources
                string cssContent = htmlDoc.GetEmbeddedHtml();

                Console.WriteLine(cssContent);
            }

            // close stream object to release file for other methods.
            sourceStream.Close();
        }
        //ExEnd:GetHTMLContentsWithEmbeddedResources

        //ExStart:GetHTMLBodyTagContents
        /// <summary>
        /// Get HTML document BODY tag content.
        /// </summary>
        public static void GetHTMLBodyTagContents()
        {
            // Obtain document stream
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
            {
                //  Obtain HTML document body content
                string bodyContent = htmlDoc.GetBodyContent();

                Console.WriteLine(bodyContent);
            }

            // close stream object to release file for other methods.
            sourceStream.Close();
        }
        //ExEnd:GetHTMLBodyTagContents

        //ExStart:GetHTMLBodyTagContentsWithExternalResources
        /// <summary>
        /// Get HTML document BODY tag content with external resource prefix.
        /// </summary>
        public static void GetHTMLBodyTagContentsWithExternalResources()
        {
            // Obtain document stream
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
            {
                string externalResourcePrefix = "GetResource?htmlDocumentFolderName=" + Common.sourceResourcesFolder + "&resourceFilename=Picture 3.png";
                //  Obtain HTML document body content   
                string bodyContent = htmlDoc.GetBodyContent(externalResourcePrefix);

                Console.WriteLine(bodyContent);
            }

            // close stream object to release file for other methods.
            sourceStream.Close();
        }
        //ExEnd:GetHTMLBodyTagContentsWithExternalResources

        //ExStart:GetHTMLExternalCSSContents
        /// <summary>
        /// Get HTML document external CSS content.
        /// </summary>
        public static void GetHTMLExternalCSSContents()
        {
            // Obtain document stream
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
            {
                //  Obtain CSS content
                string cssContent = htmlDoc.GetCssContent();

                Console.WriteLine(cssContent);
            }

            // close stream object to release file for other methods.
            sourceStream.Close();
        }
        //ExEnd:GetHTMLExternalCSSContents

        //ExStart:GetHTMLExternalCSSContentsWithExternalResources
        /// <summary>
        /// Get HTML document external CSS content with external resource prefix.
        /// </summary>
        public static void GetHTMLExternalCSSContentsWithExternalResources()
        {
            // Obtain document stream
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
            {
                string externalResourcePrefix = "GetResource?htmlDocumentFolderName=" + Common.sourceResourcesFolder + "&resourceFilename=Picture 3.png";
                //  Obtain CSS content
                string cssContent = htmlDoc.GetCssContent(externalResourcePrefix);

                Console.WriteLine(cssContent);
            }

            // close stream object to release file for other methods.
            sourceStream.Close();
        }
        //ExEnd:GetHTMLExternalCSSContentsWithExternalResources

        //ExStart:SaveHTMLDocument
        /// <summary>
        /// Save HTML document.
        /// </summary>
        public static void SaveHTMLDocument()
        {
            // Obtain document stream
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
            {
                htmlDoc.Save(Path.Combine(Common.resultPath, Common.resultFile));
            }

            // close stream object to release file for other methods.
            sourceStream.Close();
        }
        //ExEnd:SaveHTMLDocument

        //ExStart:SaveHTMLDocumentWithResourcesFolder
        /// <summary>
        /// Save HTML document specifying resource folder name.
        /// </summary>
        public static void SaveHTMLDocumentWithResourcesFolder()
        {
            // Obtain document stream
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
            {
                // saving output html file.
                htmlDoc.Save(Path.Combine(Common.resultPath, Common.resultFile), Path.Combine(Common.resultPath, Common.resultResourcesFolder));
            }

            // close stream object to release file for other methods.
            sourceStream.Close();
        }
        //ExEnd:SaveHTMLDocumentWithResourcesFolder

        //ExStart:TraverseHTMLResourcesAndCSS
        /// <summary>
        /// Traverse HTML document and save resources by specifying resource folder name.
        /// </summary>
        public static void TraverseHTMLResourcesAndCSS()
        {
            // Obtain document stream
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
            {
                foreach (FontResourceBase fontResource in htmlDoc.FontResources)
                {
                    Console.WriteLine(fontResource.FilenameWithExtension);
                    Console.WriteLine(fontResource.Name);
                    Console.WriteLine(fontResource.ByteContent);
                    Console.WriteLine(fontResource.TextContent);

                    string pathToResource = string.Format(Path.Combine(Common.resultPath, Common.resultResourcesFolder) + "\\{0}", fontResource.FilenameWithExtension);
                    fontResource.Save(pathToResource);
                }

                foreach (RasterImageResourceBase imageResource in htmlDoc.ImageResources)
                {
                    Console.WriteLine(imageResource.FilenameWithExtension);
                    Console.WriteLine(imageResource.ByteContent);
                    Console.WriteLine(imageResource.Name);
                    Console.WriteLine(imageResource.TextContent);
                    Console.WriteLine(imageResource.LinearDimensions.Height);
                    Console.WriteLine(imageResource.LinearDimensions.Width);
                    Console.WriteLine(imageResource.LinearDimensions.IsSquare);

                    string pathToResource = string.Format(Path.Combine(Common.resultPath, Common.resultResourcesFolder) + "\\{0}", imageResource.FilenameWithExtension);
                    imageResource.Save(pathToResource);
                }

                CssText css = htmlDoc.Css;
                Console.WriteLine(css.FilenameWithExtension);
                Console.WriteLine(css.ByteContent);
                Console.WriteLine(css.Name);
                Console.WriteLine(css.TextContent);
                Console.WriteLine(css.Encoding);

                string pathToCss = string.Format(Path.Combine(Common.resultPath, Common.resultResourcesFolder) + "\\{0}", css.FilenameWithExtension);
                css.Save(pathToCss);

                // saving output html file.
                htmlDoc.Save(Path.Combine(Common.resultPath, Common.resultFile), Path.Combine(Common.resultPath, Common.resultResourcesFolder));
            }

            // close stream object to release file for other methods.
            sourceStream.Close();
        }
        //ExEnd:TraverseHTMLResourcesAndCSS
    }
}
//ExEnd:ConvertDocumentToHTMLDOMClass