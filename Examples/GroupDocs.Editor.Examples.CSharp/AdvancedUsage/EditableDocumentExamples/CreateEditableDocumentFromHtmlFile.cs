using System.IO;
using GroupDocs.Editor.Formats;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples
{
    /// <summary>
    /// This example demonstrates, how to open EditableDocument from HTML file with resource folder from disk and save it as DOCX
    /// </summary>
    class CreateEditableDocumentFromHtmlFile
    {
        internal static void Run()
        {
            string htmlFilePath = Constants.SAMPLE_HTML;
            using (EditableDocument document = EditableDocument.FromFile(htmlFilePath, null))
            {
                using (Editor editor = new Editor(htmlFilePath))
                {
                    Options.WordProcessingSaveOptions saveOptions = new WordProcessingSaveOptions(WordProcessingFormats.Docx);
                    string savePath = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileNameWithoutExtension(htmlFilePath) + ".docx");
                    editor.Save(document, savePath, saveOptions);
                }
            }
        }
    }
}