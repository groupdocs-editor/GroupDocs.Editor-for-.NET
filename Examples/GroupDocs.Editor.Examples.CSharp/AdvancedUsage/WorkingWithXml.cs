using System.Collections.Generic;
using System.IO;
using GroupDocs.Editor.Formats;
using GroupDocs.Editor.HtmlCss.Resources;
using GroupDocs.Editor.HtmlCss.Serialization;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates, how to convert input XML document to intermediate, edit it, and save to WordProcessing and to TXT
    /// </summary>
    internal static class WorkingWithXml
    {
        internal static void Run()
        {
            //1. Get a path to the input XML file (or stream with file content)
            string inputFilePath = Constants.SAMPLE_XML;

            //2. Create Editor instance (not load options required)
            using (Editor editor = new Editor(inputFilePath))
            {
                //3. Create XML editing options
                Options.XmlEditOptions editOptions = new XmlEditOptions();
                editOptions.AttributeValuesQuoteType = QuoteType.DoubleQuote;
                editOptions.RecognizeEmails = true;
                editOptions.RecognizeUris = true;
                editOptions.TrimTrailingWhitespaces = true;

                //4. Create EditableDocument instance
                using (EditableDocument beforeEdit = editor.Edit(editOptions))
                {
                    //5. Edit is somehow
                    string originalTextContent = beforeEdit.GetContent();
                    string updatedTextContent = originalTextContent.Replace("John", "Samuel");

                    List<IHtmlResource> allResources = beforeEdit.AllResources;

                    //6. Create EditableDocument with updated content
                    using (EditableDocument afterEdit = EditableDocument.FromMarkup(updatedTextContent, allResources))
                    {
                        //7. Create WordProcessing save options
                        Options.WordProcessingSaveOptions wordSaveOptions = new WordProcessingSaveOptions(WordProcessingFormats.Docx);
                        
                        //8. Create TXT save options
                        Options.TextSaveOptions txtSaveOptions = new TextSaveOptions();
                        txtSaveOptions.Encoding = System.Text.Encoding.UTF8;

                        //9. Prepare paths for saving resultant DOCX and TXT files
                        string outputWordPath = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileNameWithoutExtension(inputFilePath) + ".docx");
                        string outputTxtPath = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileNameWithoutExtension(inputFilePath) + ".txt");

                        //10. Save
                        editor.Save(afterEdit, outputWordPath, wordSaveOptions);
                        editor.Save(afterEdit, outputTxtPath, txtSaveOptions);
                    }
                }
            }
            System.Console.WriteLine("WorkingWithXml routine has successfully finished");
        }
    }
}