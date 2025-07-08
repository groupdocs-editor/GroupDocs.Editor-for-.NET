using GroupDocs.Editor.Formats;
using GroupDocs.Editor.Options;
using System.IO;

namespace GroupDocs.Editor.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to create a new WordProcessing document using GroupDocs.Editor,
    /// apply specific edit options, modify the content, and save the edited document to a stream.
    /// </summary>
    internal static class EditNewDocument
    {
        /// <summary>
        /// Runs the editing process for a new WordProcessing document.
        /// </summary>
        internal static void Run()
        {
            // Create a memory stream to hold the edited document.
            Stream memoryStream = new MemoryStream();

            // Initialize the Editor instance for a WordProcessing format (DOCX in this case).
            using (Editor editor = new Editor(WordProcessingFormats.Docx))
            {
                // Create edit options for the WordProcessing document.
                WordProcessingEditOptions wordProcessingEditOptions = new WordProcessingEditOptions();

                // Disable pagination to treat the document as a continuous flow of content.
                wordProcessingEditOptions.EnablePagination = false;

                // Enable language metadata extraction (e.g., for spell check or localization features).
                wordProcessingEditOptions.EnableLanguageInformation = true;

                // Specify that all embedded fonts should be extracted during editing.
                wordProcessingEditOptions.FontExtraction = FontExtractionOptions.ExtractAllEmbedded;

                // Load the document into an editable form using the specified options.
                EditableDocument wordProcessingDocument = editor.Edit(wordProcessingEditOptions);

                // Get the document content as embedded HTML.
                string srcHtml = wordProcessingDocument.GetEmbeddedHtml();

                // Modify the HTML by replacing a placeholder span with new text.
                string editedHtml = srcHtml.Replace(
                    "<span class = \"text001\">&#xa0;</span>",
                    "<span class = \"text001\">New text</span>");

                // Create a new EditableDocument from the modified HTML markup.
                EditableDocument editedDoc = EditableDocument.FromMarkup(editedHtml);

                // Define options for saving the WordProcessing document.
                WordProcessingSaveOptions saveOptions = new WordProcessingSaveOptions();

                // Save the edited document to the memory stream using the save options.
                editor.Save(editedDoc, memoryStream, saveOptions);
            }

            // Clean up by disposing the memory stream.
            memoryStream.Dispose();

            // Notify the user that the routine has completed successfully.
            System.Console.WriteLine("EditNewDocument routine has successfully finished");
        }
    }

}
