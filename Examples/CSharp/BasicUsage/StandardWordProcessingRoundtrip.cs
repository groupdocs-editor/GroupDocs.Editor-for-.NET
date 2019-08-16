using System.Collections.Generic;
using System.IO;
using GroupDocs.Editor.Formats;
using GroupDocs.Editor.HtmlCss.Resources;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates standard operations with WordProcessing document, including options for its loading, opening, editing and saving
    /// </summary>
    internal static class StandardWordProcessingRoundtrip
    {
        internal static void Run()
        {
            //1. Get a path to the input file (or stream with file content). In this case it is sample DOCX with complex content and formatting
            string inputFilePath = FilesHelper.Docx;

            //2. Create stream from this path
            using (FileStream fs = File.OpenRead(inputFilePath))
            {
                //3. Create load options for this document
                Options.WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
                
                //3.1. In case if input document is password-protected, we can specify password for its opening...
                loadOptions.Password = "some_password_to_open_a_document";
                //3.2. ...but, because document is unprotected, this password will be ignored

                //4. Load document with options to the Editor instance
                using (Editor editor = new Editor(delegate { return fs; }, delegate { return loadOptions; }))
                {
                    //5. Create editing options
                    Options.WordProcessingEditOptions editOptions = new WordProcessingEditOptions();
                    
                    //5.1. Enable font extraction from original document to intermediate EditableDocument
                    editOptions.FontExtraction = FontExtractionOptions.ExtractEmbeddedWithoutSystem;
                    
                    //5.2. Enable extracting language information for better subsequent spell-checking on client side
                    editOptions.EnableLanguageInformation = true;

                    //5.3. Switch to pagination mode instead of default float mode
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
                            //10. Create document save options
                            WordProcessingFormats docmFormat = WordProcessingFormats.Docm;
                            Options.WordProcessingSaveOptions saveOptions = new WordProcessingSaveOptions(docmFormat);
                            
                            //10.1 Encrypt output document by setting non-null and non-empty opening password
                            saveOptions.Password = "password";

                            //10.2. Because pagination was previously enabled in WordProcessingEditOptions (editOptions variable),
                            //for better output result it is highly recommended to enable it in WordProcessingSaveOptions (saveOptions variable)
                            saveOptions.EnablePagination = true;

                            //10.3. You can set locale for output WordProcessing document manually
                            saveOptions.Locale = System.Globalization.CultureInfo.GetCultureInfo("en-US");

                            //10.4. If document is really huge and causes OutOfMemoryException, you can set memory optimization option
                            saveOptions.OptimizeMemoryUsage = true;

                            //10.5. You can protect document from writing (make it read-only) with password
                            saveOptions.Protection = new WordProcessingProtection(WordProcessingProtectionType.ReadOnly, "write_password");

                            //11. Save it
                            //11.1. Prepare saving filename and path
                            string outputFilename = Path.GetFileNameWithoutExtension(inputFilePath) + "." + docmFormat.Extension;
                            string outputPath = Path.Combine(System.Environment.CurrentDirectory, outputFilename);

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
            System.Console.WriteLine("StandardWordProcessingRoundtrip routine has successfully finished");
        }
    }
}