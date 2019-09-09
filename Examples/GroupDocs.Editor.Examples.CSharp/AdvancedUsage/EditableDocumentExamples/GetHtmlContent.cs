using System;
using System.IO;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples
{
    class GetHtmlContent
    {
        internal static void Run()
        {
            using (FileStream fs = File.OpenRead(FilesHelper.Docx))
            {
                using (Editor editor = new Editor(delegate { return fs; }, delegate { return new WordProcessingLoadOptions(); }))
                {
                    using (EditableDocument document = editor.Edit(new WordProcessingEditOptions()))
                    {
                        string htmlContent = document.GetContent();
                        Console.WriteLine("HTML content of the input document (first 200 chars): {0}", htmlContent.Substring(0, 200));
                    }
                }
            }
        }
    }
}