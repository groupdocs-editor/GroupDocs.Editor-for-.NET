using GroupDocs.Editor.Options;
using System;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples
{
    class GetHtmlBodyContent
    {
        internal static void Run()
        {
            using (Editor editor = new Editor(Constants.SAMPLE_DOCX, new WordProcessingLoadOptions()))
            {
                using (EditableDocument document = editor.Edit(new WordProcessingEditOptions()))
                {
                    string bodyContent = document.GetBodyContent();
                    Console.WriteLine("Inner content of the HTML->BODY element: {0}", bodyContent);
                }
            }
        }
    }
}