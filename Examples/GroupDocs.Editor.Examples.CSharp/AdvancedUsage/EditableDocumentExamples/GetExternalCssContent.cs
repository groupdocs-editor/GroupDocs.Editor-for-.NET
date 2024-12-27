using GroupDocs.Editor.Options;
using System;
using System.Collections.Generic;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples
{
    class GetExternalCssContent
    {
        internal static void Run()
        {
            using (Editor editor = new Editor(Constants.SAMPLE_DOCX, new WordProcessingLoadOptions()))
            {
                using (EditableDocument document = editor.Edit(new WordProcessingEditOptions()))
                {
                    List<string> stylesheets = document.GetCssContent();
                    Console.WriteLine("There are {0} stylesheets in the input document", stylesheets.Count);
                    foreach (string css in stylesheets)
                    {
                        Console.WriteLine(css);
                    }
                }
            }
        }
    }
}