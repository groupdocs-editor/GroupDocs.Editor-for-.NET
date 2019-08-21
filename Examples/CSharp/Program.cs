using System;
using GroupDocs.Editor.Examples.CSharp.QuickStart;

namespace GroupDocs.Editor.Examples.CSharp
{
    /// <summary>
    /// Root class and entry point
    /// </summary>
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Open Program.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("Output folder is '{0}'", FilesHelper.OutputFolder);
            Console.WriteLine("=====================================================");

            #region Quick Start

            SetLicenseFromFile.Run();
            //SetLicenseFromStream.Run();
            //SetMeteredLicense.Run();

            #endregion

            ////// *** Documents Editor Examples (Un-Comment to run each example demo methods) ***

            #region Here are the sample methods call, how to convert document to EditableDocument.

            // Get HTML document content.
            //BasicUsage.GetHtmlContent.Run();

            // Get HTML document content with external resource prefix.
            //BasicUsage.GetHtmlContentWithPrefix.Run();

            // Get HTML document with embedded resources.
            //BasicUsage.GetAllEmbeddedHtmlContent.Run();

            // Get HTML document BODY tag content.
            //BasicUsage.GetHtmlBodyContent.Run();

            // Get HTML document BODY tag content with external resource prefix.
            //BasicUsage.GetBodyContentWithPrefix.Run();

            // Get HTML document external CSS content.
            //BasicUsage.GetExternalCssContent.Run();

            // Get HTML document external CSS content with external resource prefix.
            //BasicUsage.GetExternalCssContentWithPrefix.Run();

            // Save HTML document with resources to specified folder.
            //BasicUsage.SaveHtmlToFolder.Run();

            // Iterate over all HTML resources and save them to specified folder.
            //BasicUsage.SaveHtmlResourcesToFolder.Run();

            #endregion

            #region Here are the sample methods call, how to create EditableDocument instance from HTML document, saved on disk.

            //BasicUsage.CreateEditableDocumentFromHtmlFile.Run();

            #endregion

            #region Here are the sample methods call, how to convert EditableDocument to Word document.

            //BasicUsage.SaveToWordsDocument.Run();

            // Save to Words document with options.
            //BasicUsage.SaveToWordsDocumentWithOptions.Run();

            #endregion

            Console.WriteLine("\r\n\r\n__________________________\r\nAll done. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
