//ExStart:WorkingWithWordDocumentsClass
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupDocs.Editor;
using GroupDocs.Editor.Words.HtmlToWords;

namespace GroupDocs.Editor.Examples.CSharp
{
    /// <summary>
    /// Here are code samples to show how to convert HTML DOM to word document.
    /// </summary>
    class WorkingWithWordDocuments
    {
        //ExStart:SaveToWordsDocument
        /// <summary>
        /// Save to Words document.
        /// </summary>
        public static void SaveToWordsDocument()
        {
            // Obtain document stream
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
            {
                // Obtain HTML document content
                string htmlContent = htmlDoc.GetContent();

                using (OutputHtmlDocument editedHtmlDoc = OutputHtmlDocument.FromMarkup(htmlContent, Path.Combine(Common.sourcePath, Common.resultResourcesFolder)))
                {
                    using (System.IO.FileStream outputStream = System.IO.File.Create(Path.Combine(Common.resultPath, Common.resultFile)))
                    {
                        WordsSaveOptions saveOptions = new WordsSaveOptions();
                        EditorHandler.ToDocument(editedHtmlDoc, outputStream, saveOptions);
                    }
                }
            }

            // close stream object to release file for other methods.
            sourceStream.Close();
        }
        //ExEnd:SaveToWordsDocument

        //ExStart:SaveToWordsDocumentWithOptions
        /// <summary>
        /// Save to Words document with options.
        /// </summary>
        public static void SaveToWordsDocumentWithOptions()
        {
            // Obtain document stream
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
            {
                // Obtain HTML document content
                string htmlContent = htmlDoc.GetContent();

                using (OutputHtmlDocument editedHtmlDoc = OutputHtmlDocument.FromMarkup(htmlContent, Path.Combine(Common.sourcePath, Common.resultResourcesFolder)))
                {
                    using (System.IO.FileStream outputStream = System.IO.File.Create(Path.Combine(Common.resultPath, Common.resultFile)))
                    {
                        WordsSaveOptions saveOptions = new WordsSaveOptions(WordFormats.Docx, Common.sourceFilePassword);
                        saveOptions.Locale = CultureInfo.GetCultureInfo(1);
                        saveOptions.LocaleBi = CultureInfo.GetCultureInfo(1);
                        saveOptions.LocaleFarEast = CultureInfo.GetCultureInfo(2);
                        EditorHandler.ToDocument(editedHtmlDoc, outputStream, saveOptions);
                    }
                }
            }

            // close stream object to release file for other methods.
            sourceStream.Close();
        }
        //ExEnd:SaveToWordsDocumentWithOptions
    }
}
//ExEnd:WorkingWithWordDocumentsClass