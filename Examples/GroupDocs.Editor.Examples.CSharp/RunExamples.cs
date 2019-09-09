using System;
using GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples;
using GroupDocs.Editor.Examples.CSharp.BasicUsage;
using GroupDocs.Editor.Examples.CSharp.QuickStart;

namespace GroupDocs.Editor.Examples.CSharp
{
    /// <summary>
    /// Root class and entry point
    /// </summary>
    static class RunExamples
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

            #region Here are basic examples

            BasicUsage.Introduction.Run();

            BasicUsage.LoadDocument.Run();

            BasicUsage.EditDocument.Run();

            BasicUsage.SaveDocument.Run();

            #endregion

            #region Advanced usage

            AdvancedUsage.WorkingWithWordProcessing.Run();

            AdvancedUsage.WorkingWithSpreadsheetPasswordProtected.Run();

            AdvancedUsage.WorkingWithSpreadsheetMultiTab.Run();

            AdvancedUsage.WorkingWithDsv.Run();

            AdvancedUsage.WorkingWithPlainTextDocuments.Run();

            AdvancedUsage.WorkingWithXml.Run();

            AdvancedUsage.ExtractingDocumentInfo.Run();

            #endregion

            #region Working with EditableDocument

            AdvancedUsage.EditableDocumentExamples.GetHtmlContent.Run();

            AdvancedUsage.EditableDocumentExamples.GetHtmlContentWithPrefix.Run();

            AdvancedUsage.EditableDocumentExamples.GetHtmlBodyContent.Run();

            AdvancedUsage.EditableDocumentExamples.GetHtmlBodyContentWithPrefix.Run();

            AdvancedUsage.EditableDocumentExamples.GetAllEmbeddedHtmlContent.Run();

            AdvancedUsage.EditableDocumentExamples.GetExternalCssContent.Run();

            AdvancedUsage.EditableDocumentExamples.GetExternalCssContentWithPrefix.Run();

            AdvancedUsage.EditableDocumentExamples.SaveHtmlToFolder.Run();

            AdvancedUsage.EditableDocumentExamples.SaveHtmlResourcesToFolder.Run();

            AdvancedUsage.EditableDocumentExamples.WorkingWithResources.Run();

            AdvancedUsage.EditableDocumentExamples.EditableDocumentAdvancedUsage.Run();

            #endregion

            Console.WriteLine("\r\n\r\n__________________________\r\nAll done. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
