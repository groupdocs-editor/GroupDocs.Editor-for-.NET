using System;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.BasicUsage
{
    class GetHtmlBodyContent
    {
        internal static void Run()
        {
            using (Editor editor = new Editor(FilesHelper.Docx, delegate { return new WordProcessingLoadOptions(); }))
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