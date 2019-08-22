using System.Collections.Generic;
using System.IO;
using GroupDocs.Editor.Formats;
using GroupDocs.Editor.HtmlCss.Resources;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrate how to open and edit DSV (Delimiter Separated Value) table document (Spreadsheet)
    /// and how to save it back to DSV with different separators, or binary Spreadsheet (like OOXML)
    /// </summary>
    internal static class DsvRoundtrip
    {
        internal static void Run()
        {
            //1. Get a path to the input DSV file. In our case it is CSV
            string inputFilePath = FilesHelper.Csv;

            //2. Create Editor instance (not load options required)
            using (Editor editor = new Editor(inputFilePath))
            {
                //3. Create DSV edit options and specify mandatory parameter - separator (delimiter)
                Options.DelimitedTextEditOptions editOptions = new DelimitedTextEditOptions(",");
                editOptions.ConvertDateTimeData = false;
                editOptions.ConvertNumericData = true;
                editOptions.TreatConsecutiveDelimitersAsOne = true;

                //4. Create EditableDocument instance
                EditableDocument beforeEdit = editor.Edit(editOptions);

                //5. Edit is somehow (just for example)
                string originalTextContent = beforeEdit.GetContent();
                string updatedTextContent = originalTextContent.Replace("SsangYong", "Chevrolet").Replace("Kyron", "Camaro");
                List<IHtmlResource> allResources = beforeEdit.AllResources;

                //6. Create EditableDocument with updated content
                EditableDocument afterEdit = EditableDocument.FromMarkup(updatedTextContent, allResources);

                //7. Create CSV save options and specify mandatory separator (delimiter) - comma
                Options.DelimitedTextSaveOptions csvSaveOptions = new DelimitedTextSaveOptions(",");
                //csvSaveOptions.TrimLeadingBlankRowAndColumn = true;
                csvSaveOptions.Encoding = System.Text.Encoding.UTF8;

                //8. Create TSV save options and specify mandatory separator (delimiter) - tab character
                Options.DelimitedTextSaveOptions tsvSaveOptions = new DelimitedTextSaveOptions("\t");
                tsvSaveOptions.TrimLeadingBlankRowAndColumn = false;
                tsvSaveOptions.Encoding = System.Text.Encoding.UTF8;

                //9. Create Spreadsheet save options
                Options.SpreadsheetSaveOptions cellsSaveOptions = new SpreadsheetSaveOptions(SpreadsheetFormats.Xlsm);
                
                //10. Prepare 3 different save paths
                string outputCsvPath = Path.Combine(FilesHelper.OutputFolder, Path.GetFileNameWithoutExtension(inputFilePath) + ".csv");
                string outputTsvPath = Path.Combine(FilesHelper.OutputFolder, Path.GetFileNameWithoutExtension(inputFilePath) + ".tsv");
                string outputCellsPath = Path.Combine(FilesHelper.OutputFolder, Path.GetFileNameWithoutExtension(inputFilePath) + ".xlsm");

                //11. Save edited document to 3 files of different formats
                editor.Save(afterEdit, outputCsvPath, csvSaveOptions);
                editor.Save(afterEdit, outputTsvPath, tsvSaveOptions);
                editor.Save(afterEdit, outputCellsPath, cellsSaveOptions);

                //12. Don't forget to dispose EditableDocument instances manually, because they are not wrapped with "using" operator
                beforeEdit.Dispose();
                afterEdit.Dispose();
            }
            System.Console.WriteLine("DsvRoundtrip routine has successfully finished");
        }
    }
}