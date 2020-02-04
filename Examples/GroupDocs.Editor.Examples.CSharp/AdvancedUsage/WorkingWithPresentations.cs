using System.Collections.Generic;
using System.IO;
using GroupDocs.Editor.Formats;
using GroupDocs.Editor.HtmlCss.Resources;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates loading, editing and saving Presentation documents with combination of different options and possibilities
    /// </summary>
    internal static class WorkingWithPresentations
    {
        internal static void Run()
        {
            //1. Get a path to the input file (or stream with file content).
            //In this case it is sample PPTX (OOXML) with three slides.
            string inputFilePath = Constants.SAMPLE_PPTX;

            //2. Create stream from this path
            using (FileStream fs = File.OpenRead(inputFilePath))
            {
                //3. Create load options for this document
                Options.PresentationLoadOptions loadOptions = new PresentationLoadOptions();

                //3.1. In case if input document is password-protected, we can specify password for its opening...
                loadOptions.Password = "some_password_to_open_a_document";
                //3.2. ...but, because document is unprotected, this password will be ignored

                //4. Load document with options to the Editor instance
                using (Editor editor = new Editor(delegate { return fs; }, delegate { return loadOptions; }))
                {
                    //5. Create editing options
                    Options.PresentationEditOptions editOptions = new PresentationEditOptions();

                    //5.1. Specify slide index from original document.
                    editOptions.SlideNumber = 0;//Because index is 0-based, it is 1st slide
                    
                    //5.2. Enable option that allows to show hidden slides in original document.
                    editOptions.ShowHiddenSlides = true;

                    //6. Create intermediate EditableDocument with editing options, so it is only 1st slide
                    using (EditableDocument beforeEdit = editor.Edit(editOptions))
                    {
                        //7. Extract textual content as HTML markup with all resources
                        string originalContent = beforeEdit.GetContent();
                        //7.1. Extract all resources from original document
                        List<IHtmlResource> allResources = beforeEdit.AllResources;

                        //8. Modify content somehow on client side
                        string editedContent = originalContent.Replace("New text", "edited text");

                        //9. Create new EditableDocument instance with edited content and same old resources
                        using (EditableDocument afterEdit = EditableDocument.FromMarkup(editedContent, allResources))
                        {
                            //10. Create document save options
                            Options.PresentationSaveOptions saveOptions = new PresentationSaveOptions(PresentationFormats.Pptm);

                            //10.1 Encrypt output document by setting non-null and non-empty opening password
                            saveOptions.Password = "password";

                            //11. Save it
                            //11.1. Prepare saving filename and path
                            string outputFilename = Path.GetFileNameWithoutExtension(inputFilePath) + "." + saveOptions.OutputFormat.Extension;
                            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), outputFilename);

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
            System.Console.WriteLine("WorkingWithPresentations routine has successfully finished");
        }
    }
}