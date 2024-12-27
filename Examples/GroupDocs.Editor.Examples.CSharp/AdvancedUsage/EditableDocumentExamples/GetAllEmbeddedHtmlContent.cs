using GroupDocs.Editor.Options;
using System;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples
{
    class GetAllEmbeddedHtmlContent
    {
        internal static void Run()
        {
            using (Editor editor = new Editor(Constants.SAMPLE_DOCX, new WordProcessingLoadOptions()))
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