using System.Collections.Generic;
using System.IO;
using GroupDocs.Editor.Formats;
using GroupDocs.Editor.HtmlCss.Resources;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates, how to convert input Plain Text document (TXT) to intermediate document, edit,
    /// and then save back to TXT, and simultaneously to WordProcessing and HTML
    /// </summary>
    internal static class WorkingWithPlainTextDocuments
    {
        internal static void Run()
        {
            //1. Get a path to the input TXT file (or stream with file content)
            string inputFilePath = Constants.SAMPLE_TXT;

            //2. Create Editor instance (not load options required)
            using (Editor editor = new Editor(inputFilePath))
            {
                //3. Create TXT editing options
                Options.TextEditOptions editOptions = new TextEditOptions();
                editOptions.Encoding = System.Text.Encoding.UTF8;
                editOptions.RecognizeLists = true;
                editOptions.LeadingSpaces = TextLeadingSpacesOptions.ConvertToIndent;
                editOptions.TrailingSpaces = TextTrailingSpacesOptions.Trim;

                //4. Create EditableDocument instance
                EditableDocument beforeEdit = editor.Edit(editOptions);

                //5. Edit is somehow
                string originalTextContent = beforeEdit.GetContent();
                string updatedTextContent = originalTextContent.Replace("text", "EDITED text");

                List<IHtmlResource> allResources = beforeEdit.AllResources;

                //6. Create EditableDocument with updated content
                EditableDocument afterEdit = EditableDocument.FromMarkup(updatedTextContent, allResources);

                //7. Create WordProcessing save options
                Options.WordProcessingSaveOptions wordSaveOptions = new WordProcessingSaveOptions(WordProcessingFormats.Docm);
                wordSaveOptions.Locale = System.Globalization.CultureInfo.GetCultureInfo("en-GB");

                //8. Create TXT saving options
                Options.TextSaveOptions txtSaveOptions = new TextSaveOptions();
                txtSaveOptions.Encoding = System.Text.Encoding.UTF8;
                txtSaveOptions.PreserveTableLayout = true;

                //9. Prepare paths for saving resultant DOCX and TXT files
                string outputWordPath = Path.Combine(Constants.GetOutputDirectoryPath(inputFilePath), Path.GetFileNameWithoutExtension(inputFilePath) + ".docm");
                string outputTxtPath = Path.Combine(Constants.GetOutputDirectoryPath(inputFilePath), Path.GetFileNameWithoutExtension(inputFilePath) + ".txt");

                //10. Save
                editor.Save(afterEdit, outputWordPath, wordSaveOptions);
                editor.Save(afterEdit, outputTxtPath, txtSaveOptions);
            }
            System.Console.WriteLine("WorkingWithPlainTextDocuments routine has successfully finished");
        }
    }
}