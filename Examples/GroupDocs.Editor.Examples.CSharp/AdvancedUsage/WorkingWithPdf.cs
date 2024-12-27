using GroupDocs.Editor.Formats;
using GroupDocs.Editor.HtmlCss.Resources;
using GroupDocs.Editor.Options;
using System.Collections.Generic;
using System.IO;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates standard operations with Pdf document, including options for its loading, opening, editing and saving
    /// </summary>
    internal static class WorkingWithPdf
    {
        internal static void Run()
        {
            //1. Get a path to the input file (or stream with file content). In this case it is sample PDF with complex content and formatting
            string inputFilePath = Constants.SAMPLE_PDF;

            //2. Create stream from this path
            using (FileStream fs = File.OpenRead(inputFilePath))
            {
                //3. Create load options for this document
                Options.PdfLoadOptions loadOptions = new PdfLoadOptions();

                //3.1. In case if input document is password-protected, we can specify password for its opening...
                loadOptions.Password = "some_password_to_open_a_document";
                //3.2. ...but, because document is unprotected, this password will be ignored

                //4. Load document with options to the Editor instance
                using (Editor editor = new Editor(fs, loadOptions))
                {
                    var documentInfo = editor.GetDocumentInfo(null);
                    //5. Create editing options
                    Options.PdfEditOptions editOptions = new PdfEditOptions();

                    //5.1. Switch to pagination mode instead of default float mode
                    editOptions.EnablePagination = true;

                    //6. Create intermediate EditableDocument
                    using (EditableDocument beforeEdit = editor.Edit(editOptions))
                    {
                        //7. Extract textual content as HTML markup with all resources
                        string originalContent = beforeEdit.GetContent();
                        List<IHtmlResource> allResources = beforeEdit.AllResources;

                        //8. Modify content somehow on client side
                        string editedContent = originalContent.Replace("document", "edited document");

                        //9. Create new EditableDocument instance with edited content
                        using (EditableDocument afterEdit = EditableDocument.FromMarkup(editedContent, allResources))
                        {
                            string originalContent3 = afterEdit.GetContent();
                            //10. Create document save options
                            FixedLayoutFormats docmFormat = FixedLayoutFormats.Pdf;
                            Options.PdfSaveOptions saveOptions = new PdfSaveOptions();

                            //10.1 Encrypt output document by setting non-null and non-empty opening password
                            saveOptions.Password = "password";

                            //10.2. Because pagination was previously enabled in WordProcessingEditOptions (editOptions variable),
                            //for better output result it is highly recommended to enable it in WordProcessingSaveOptions (saveOptions variable)
                            saveOptions.OptimizeMemoryUsage = true;

                            //10.2. If document is really huge and causes OutOfMemoryException, you can set memory optimization option
                            saveOptions.OptimizeMemoryUsage = true;

                            //11. Save it
                            //11.1. Prepare saving filename and path
                            string outputFilename = Path.GetFileNameWithoutExtension(inputFilePath) + "." + docmFormat.Extension;
                            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(inputFilePath), outputFilename);

                            //11.2. Prepare stream for saving
                            using (FileStream outputStream = File.Create(outputPath))
                            {
                                //11.3. Save
                                editor.Save(afterEdit, outputStream, saveOptions);
                            }
                        }
                    }
                }
            }
            System.Console.WriteLine("WorkingWithPdf routine has successfully finished");
        }
    }
}