using GroupDocs.Editor.Options;
using System.IO;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates standard operations with Pdf document, including options for its loading, opening, editing and saving
    /// </summary>
    internal static class EditPdf
    {
        internal static void Run(bool enablePagination)
        {
            //1. Get a path to the input file (or stream with file content). In this case it is sample PDF with complex content and formatting
            string inputFilePath = Constants.SAMPLE_PDF;

            //2. Create stream from this path
            //3. Create load options for this document
            Options.PdfLoadOptions loadOptions = new PdfLoadOptions();

            //3.1. In case if input document is password-protected, we can specify password for its opening...
            loadOptions.Password = "some_password_to_open_a_document";
            //3.2. ...but, because document is unprotected, this password will be ignored

            //4. Load document with options to the Editor instance
            using (Editor editor = new Editor(inputFilePath, loadOptions))
            {
                var documentInfo = editor.GetDocumentInfo(null);
                //5. Create editing options
                Options.PdfEditOptions editOptions = new PdfEditOptions();

                //5.1. Switch to pagination mode instead of default float mode
                editOptions.EnablePagination = enablePagination;

                //6. Create intermediate EditableDocument
                using (EditableDocument editable = editor.Edit(editOptions))
                {
                    string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(inputFilePath), $"editedPdf_{enablePagination}.html");
                    editable.Save(outputPath);

                }
            }
            System.Console.WriteLine("WorkingWithPdf routine has successfully finished");
        }
    }
}