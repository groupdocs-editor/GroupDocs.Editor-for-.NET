using System.IO;
using GroupDocs.Editor.Formats;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to obtain edited document content from client, process it and save to the resultant document of some specified format.
    /// </summary>
    internal static class SaveDocument
    {
        internal static void Run()
        {
            //Load and edit some document, like it was shown in LoadDocument.cs and EditDocument.cs
            string inputFilePath = Constants.SAMPLE_DOCX;
            Editor editor = new Editor(inputFilePath, delegate { return new Options.WordProcessingLoadOptions(); });
            EditableDocument defaultWordProcessingDoc = editor.Edit();

            //Modify its content somehow. Because there is no attached WYSIWYG-editor, this code simulates document editing
            string allEmbeddedInsideString = defaultWordProcessingDoc.GetEmbeddedHtml();
            string allEmbeddedInsideStringEdited = allEmbeddedInsideString.Replace("Subtitle", "Edited subtitle");//Modified version

            //Create new EditableDocument instance from modified HTML content
            EditableDocument editedDoc = EditableDocument.FromMarkup(allEmbeddedInsideStringEdited, null);

            //Save edited document as RTF, specified through file path
            string outputRtfPath = Path.Combine(Constants.GetOutputDirectoryPath(inputFilePath), "editedDoc.rtf");
            WordProcessingSaveOptions rtfSaveOptions = new WordProcessingSaveOptions(WordProcessingFormats.Rtf);
            editor.Save(editedDoc, outputRtfPath, rtfSaveOptions);

            //Save edited document as DOCM, specified through stream
            string outputDocmPath = Path.Combine(Constants.GetOutputDirectoryPath(inputFilePath), "editedDoc.docm");
            WordProcessingSaveOptions docmSaveOptions = new WordProcessingSaveOptions(WordProcessingFormats.Docm);
            using (FileStream outputStream = File.Create(outputDocmPath))
            {
                editor.Save(editedDoc, outputStream, docmSaveOptions);
            }

            //Save edited document as plain text, specified through file path.
            //Note that all complex content and resources (like images and fonts) will be missed in output TXT
            string outputTxtPath = Path.Combine(Constants.GetOutputDirectoryPath(inputFilePath), "editedDoc.txt");
            TextSaveOptions textSaveOptions = new TextSaveOptions();
            textSaveOptions.Encoding = System.Text.Encoding.UTF8;
            textSaveOptions.PreserveTableLayout = true;
            editor.Save(editedDoc, outputTxtPath, textSaveOptions);

            //Dispose EditableDocument and Editor instances
            editedDoc.Dispose();
            defaultWordProcessingDoc.Dispose();
            editor.Dispose();

            System.Console.WriteLine("SaveDocument routine has successfully finished");
        }
    }
}