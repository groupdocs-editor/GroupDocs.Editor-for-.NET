using GroupDocs.Editor.Options;
using System;
using System.IO;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples
{
    class GetHtmlContent
    {
        internal static void Run()
        {
            using (FileStream fs = File.OpenRead(Constants.SAMPLE_DOCX))
            {
                using (Editor editor = new Editor(fs, new WordProcessingLoadOptions()))
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