using System.Collections.Generic;
using GroupDocs.Editor.HtmlCss.Resources;
using GroupDocs.Editor.HtmlCss.Resources.Images;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to open for editing a previously loaded document, which options should be applied, and how to send document content to the WYSIWYG HTML-editor or any other editing application.
    /// </summary>
    internal static class EditDocument
    {
        internal static void Run()
        {
            //Load some WordProcessing document somehow, as it is shown in LoadDocument.cs
            string inputFilePath = Constants.SAMPLE_DOCX; //path to some document
            Editor editor1 = new Editor(inputFilePath, delegate { return new Options.WordProcessingLoadOptions(); });

            //Edit WordProcessing document with default options
            EditableDocument defaultWordProcessingDoc = editor1.Edit();

            //Edit WordProcessing document with specified options with some defined settings
            WordProcessingEditOptions wordProcessingEditOptions1 = new WordProcessingEditOptions();
            wordProcessingEditOptions1.EnablePagination = false;
            wordProcessingEditOptions1.EnableLanguageInformation = true;
            wordProcessingEditOptions1.FontExtraction = FontExtractionOptions.ExtractAllEmbedded;

            EditableDocument version1WordProcessingDoc = editor1.Edit(wordProcessingEditOptions1);


            //Edit same WordProcessing document with another configuration of option parameters
            WordProcessingEditOptions wordProcessingEditOptions2 = new WordProcessingEditOptions(true);
            wordProcessingEditOptions2.FontExtraction = FontExtractionOptions.ExtractAll;

            EditableDocument version2WordProcessingDoc = editor1.Edit(wordProcessingEditOptions2);


            //Load another document, Spreadsheet at this time
            Editor editor2 = new Editor(Constants.SAMPLE_XLSX, delegate { return new SpreadsheetLoadOptions();});

            //Edit 1st tab of this Spreadsheet
            SpreadsheetEditOptions sheetTab1EditOptions = new SpreadsheetEditOptions();
            sheetTab1EditOptions.WorksheetIndex = 0;//index is 0-based, so this is 1st tab
            EditableDocument firstTab = editor2.Edit(sheetTab1EditOptions);

            //Edit 2nd tab of this Spreadsheet
            SpreadsheetEditOptions sheetTab2EditOptions = new SpreadsheetEditOptions();
            sheetTab2EditOptions.WorksheetIndex = 1;//index is 0-based, so this is 2nd tab
            EditableDocument secondTab = editor2.Edit(sheetTab2EditOptions);

            //Obtaining HTML markup from some EditableDocument instance
            string bodyContent = firstTab.GetBodyContent();//HTML markup from inside the HTML->BODY element
            string allContent = firstTab.GetContent();//Full HTML markup of all document, with HTML->HEAD header and all its content
            List<IImageResource> onlyImages = firstTab.Images;
            List<IHtmlResource> allResourcesTogether = firstTab.AllResources;

            //Dispose all Editor and EditableDocument instances
            defaultWordProcessingDoc.Dispose();
            version1WordProcessingDoc.Dispose();
            version2WordProcessingDoc.Dispose();
            firstTab.Dispose();
            secondTab.Dispose();
            editor1.Dispose();
            editor2.Dispose();

            System.Console.WriteLine("EditDocument routine has successfully finished");
        }
    }
}