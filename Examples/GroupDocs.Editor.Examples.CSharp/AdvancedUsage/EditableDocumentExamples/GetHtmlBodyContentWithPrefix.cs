using System;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples
{
    class GetHtmlBodyContentWithPrefix
    {
        internal static void Run()
        {
            using (Editor editor = new Editor(Constants.SAMPLE_DOCX, delegate { return new WordProcessingLoadOptions(); }))
            {
                using (EditableDocument document = editor.Edit(new WordProcessingEditOptions()))
                {
                    string externalImagesPrefix = "http://www.mywebsite.com/images/id=";
                    string prefixedBodyContent = document.GetBodyContent(externalImagesPrefix);
                    Console.WriteLine("Inner content of the HTML->BODY element with external images prefix: {0}", prefixedBodyContent);
                }
            }
        }
    }
}