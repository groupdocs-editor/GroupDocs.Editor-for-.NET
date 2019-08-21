using System;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.BasicUsage
{
    class GetAllEmbeddedHtmlContent
    {
        internal static void Run()
        {
            using (Editor editor = new Editor(FilesHelper.Docx, delegate { return new WordProcessingLoadOptions(); }))
            {
                using (EditableDocument document = editor.Edit(new WordProcessingEditOptions()))
                {
                    string embeddedHtmlContent = document.GetEmbeddedHtml();
                    Console.WriteLine("HTML content of the input document, where all resources are embedded in base64 encoding: {0}", embeddedHtmlContent);
                }
            }
        }
    }
}