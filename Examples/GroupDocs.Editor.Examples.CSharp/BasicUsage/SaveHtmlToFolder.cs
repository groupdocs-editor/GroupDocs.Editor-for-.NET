using System;
using System.IO;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.BasicUsage
{
    class SaveHtmlToFolder
    {
        internal static void Run()
        {
            using (Editor editor = new Editor(FilesHelper.Docx, delegate { return new WordProcessingLoadOptions(); }))
            {
                using (EditableDocument document = editor.Edit(new WordProcessingEditOptions()))
                {
                    string outputFolder = FilesHelper.OutputFolder;
                    string outputHtml = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(FilesHelper.Docx)+".html");
                    document.Save(outputHtml);
                }
            }
        }
    }
}