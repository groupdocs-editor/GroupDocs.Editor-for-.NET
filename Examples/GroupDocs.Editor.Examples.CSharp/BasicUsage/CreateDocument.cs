using GroupDocs.Editor.Formats;
using GroupDocs.Editor.Options;
using System.IO;

namespace GroupDocs.Editor.Examples.CSharp.BasicUsage
{

    /// <summary>
    /// This example demonstrates how to create new documents by format in GroupDocs.Editor and apply edit options.
    /// </summary>
    internal static class CreateDocument
    {
        internal static void Run()
        {
            Stream memoryStream = Stream.Null;

            // Callback function to save the new document stream
            void SaveNewDocument(Stream resultStream)
            {
                memoryStream = resultStream;
            }

            // Create a new WordProcessing document and save it using a callback Action<Stream>.
            using (Editor editor = new Editor(SaveNewDocument, WordProcessingFormats.Docx))
            {
                // Edit the WordProcessing document with default options.
                EditableDocument defaultWordProcessingDoc = editor.Edit();

                // Edit the WordProcessing document with specified options and some defined settings.
                WordProcessingEditOptions wordProcessingEditOptions = new WordProcessingEditOptions();
                wordProcessingEditOptions.EnablePagination = false;  // Disable pagination for the document.
                wordProcessingEditOptions.EnableLanguageInformation = true;  // Enable language information for the document.
                wordProcessingEditOptions.FontExtraction = FontExtractionOptions.ExtractAllEmbedded;  // Extract all embedded fonts.

                EditableDocument editableWordProcessingDocument = editor.Edit(wordProcessingEditOptions);
            }

            // Create a new Spreadsheet document and save it via callback Action<Stream>.
            using (Editor editor = new Editor(SaveNewDocument, SpreadsheetFormats.Xlsx))
            {
                // Edit the Spreadsheet document with default options.
                EditableDocument defaultEditableSpreadsheetDocument = editor.Edit();

                // Edit the Spreadsheet document with specified options and some defined settings.
                SpreadsheetEditOptions spreadsheetEditOptions = new SpreadsheetEditOptions();
                spreadsheetEditOptions.WorksheetIndex = 0;
                spreadsheetEditOptions.ExcludeHiddenWorksheets = true;

                EditableDocument editableSpreadsheetDocument = editor.Edit(spreadsheetEditOptions);
            }

            // Create a new Presentation document and save it via callback Action<Stream>.
            using (Editor editor = new Editor(SaveNewDocument, PresentationFormats.Pptx))
            {
                // Edit the Presentation document with default options.
                EditableDocument defaultEditablePresentationDocument = editor.Edit();

                // Edit the Presentation document with specified options and some defined settings.
                PresentationEditOptions presentationEditOptions = new PresentationEditOptions();
                presentationEditOptions.ShowHiddenSlides = false;
                presentationEditOptions.SlideNumber = 0;

                EditableDocument editablePresentationDocument = editor.Edit(presentationEditOptions);
            }

            // Create a new Ebook document and save it via callback Action<Stream>.
            using (Editor editor = new Editor(SaveNewDocument, EBookFormats.Epub))
            {
                // Edit the Ebook document with default options.
                EditableDocument defaultEditableEbookDocument = editor.Edit();

                // Edit the Ebook document with specified options and some defined settings.
                EbookEditOptions ebookEditOptions = new EbookEditOptions();
                ebookEditOptions.EnablePagination = false;
                ebookEditOptions.EnableLanguageInformation = true;

                EditableDocument editableEbookDocument = editor.Edit(ebookEditOptions);
            }

            // Create a new Email document and save it via callback Action<Stream>.
            using (Editor editor = new Editor(SaveNewDocument, EmailFormats.Eml))
            {
                // Edit the Email document with default options.
                EditableDocument defaultEditableEmailDocument = editor.Edit();

                // Edit the Email document with specified options and some defined settings.
                EmailEditOptions emailEditOptions = new EmailEditOptions();
                emailEditOptions.MailMessageOutput = MailMessageOutput.All;

                EditableDocument editableEmailDocument = editor.Edit(emailEditOptions);
            }

            // Dispose of the memory stream
            memoryStream.Dispose();

            // Display completion message
            System.Console.WriteLine("CreateDocument routine has successfully finished");
        }
    }
}
