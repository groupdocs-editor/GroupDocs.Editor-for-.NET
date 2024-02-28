using System.IO;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples
{
    class SaveHtmlToFolder
    {
        internal static void Run()
        {
            using (Editor editor = new Editor(Constants.SAMPLE_DOCX, delegate { return new WordProcessingLoadOptions(); }))
            {
                using (EditableDocument document = editor.Edit(new WordProcessingEditOptions()))
                {
                    string outputFolder = Constants.GetOutputDirectoryPath(Constants.SAMPLE_DOCX);
                    string outputHtml = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(Constants.SAMPLE_DOCX)+".html");
                    document.Save(outputHtml);
                }
            }
        }
    }
}