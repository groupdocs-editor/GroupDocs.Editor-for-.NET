using System.Globalization;
using System.IO;
using GroupDocs.Editor.Formats;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.BasicUsage
{
    public class SaveToWordsDocumentWithOptions
    {
        internal static void Run()
        {
            string path = FilesHelper.Docx;
            using (Editor editor = new Editor(path, delegate { return new WordProcessingLoadOptions(); }))
            {
                using (EditableDocument original = editor.Edit(new WordProcessingEditOptions()))
                {
                    // Obtain HTML document content
                    string htmlContent = original.GetEmbeddedHtml();

                    //create output EditableDocument
                    using (EditableDocument edited = EditableDocument.FromMarkup(htmlContent, null))
                    {
                        string outputFilePath = Path.Combine(FilesHelper.OutputFolder, "edited.docm");
                        
                        Options.WordProcessingSaveOptions saveOptions = new WordProcessingSaveOptions(WordProcessingFormats.Docm);
                        saveOptions.Password = "password";
                        saveOptions.OptimizeMemoryUsage = true;
                        saveOptions.Protection = new WordProcessingProtection(WordProcessingProtectionType.ReadOnly, "write password");
                        saveOptions.Locale = CultureInfo.GetCultureInfo("en-GB");

                        //save
                        editor.Save(edited, outputFilePath, saveOptions);
                    }
                }
            }
        }
    }
}