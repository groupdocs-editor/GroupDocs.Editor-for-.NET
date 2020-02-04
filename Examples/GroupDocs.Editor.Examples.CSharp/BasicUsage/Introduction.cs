using System;
using System.IO;
using GroupDocs.Editor.Formats;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates the most basic usage of GroupDocs.Editor for editing documents: loading a document from file path, editing, and saving with complete minimum of options and settings
    /// </summary>
    internal static class Introduction
    {
        internal static void Run()
        {
			//1. Get a path to the input file (or stream with file content). In this case it is sample DOCX with complex content and formatting
            string inputFilePath = Constants.SAMPLE_DOCX;
						
            //2. Instantiate Editor object by loading the input file
            using (GroupDocs.Editor.Editor editor = new Editor(inputFilePath))
            {
                //3. Open input document for edit — obtain an intermediate document, that can be edited
                EditableDocument beforeEdit = editor.Edit();

                //4. Grab document content and associated resources from editable document
                string content = beforeEdit.GetContent();
                var images = beforeEdit.Images;
                var fonts = beforeEdit.Fonts;
                var stylesheets = beforeEdit.Css;

                //4.1. Get document as a single base64-encoded string, where all resources (images, fonts, etc) are embedded inside this string along with main textual content
                string allEmbeddedInsideString = beforeEdit.GetEmbeddedHtml();
                //4.2. For example, edit its content somehow
                string allEmbeddedInsideStringEdited = allEmbeddedInsideString.Replace("Subtitle", "Edited subtitle");

                //5. Create new EditableDocument instance from edited content and resources
                EditableDocument afterEdit = EditableDocument.FromMarkup(allEmbeddedInsideStringEdited, null);

                //6. Save edited document to the output format
                //6.1. In order to do that, prepare stream or path for saving (writing) output document...
                string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileNameWithoutExtension(inputFilePath)+".rtf");
                //6.2. ...and prepare saving options
                Options.WordProcessingSaveOptions saveOptions = new WordProcessingSaveOptions(WordProcessingFormats.Rtf);
                //6.3. Finally, save to path
                editor.Save(afterEdit, outputPath, saveOptions);
                //6.4. Alternatively, output document can be saved into any stream, that support writing
                using (MemoryStream ms = new MemoryStream())
                {
                    editor.Save(afterEdit, ms, saveOptions);
                }

                //7. Dispose both EditableDocument instances and Editor itself
                beforeEdit.Dispose();
                afterEdit.Dispose();
                editor.Dispose();
            }
            Console.WriteLine("Introduction routine has successfully finished");
        }
    }
}