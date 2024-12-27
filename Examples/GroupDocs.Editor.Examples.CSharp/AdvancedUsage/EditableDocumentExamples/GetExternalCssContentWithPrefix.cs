using GroupDocs.Editor.Options;
using System;
using System.Collections.Generic;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples
{
    class GetExternalCssContentWithPrefix
    {
        internal static void Run()
        {
            using (Editor editor = new Editor(Constants.SAMPLE_DOCX, new WordProcessingLoadOptions()))
            {
                using (EditableDocument document = editor.Edit(new WordProcessingEditOptions()))
                {
                    string externalImagesPrefix = "http://www.mywebsite.com/images/id=";
                    string externalFontsPrefix = "http://www.mywebsite.com/fonts/id=";
                    List<string> stylesheets = document.GetCssContent(externalImagesPrefix, externalFontsPrefix);
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