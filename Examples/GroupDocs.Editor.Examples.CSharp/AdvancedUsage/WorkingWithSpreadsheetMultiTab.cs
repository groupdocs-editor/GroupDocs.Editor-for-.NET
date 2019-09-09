using System.IO;
using GroupDocs.Editor.Formats;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates loading, editing and saving multi-tab Spreadsheet documents
    /// </summary>
    internal static class WorkingWithSpreadsheetMultiTab
    {
        internal static void Run()
        {
            //1. Get a path to the input file (or stream with file content).
            //In this case it is sample XLSX (OOXML) with two tabs.
            string inputFilePath = FilesHelper.Xlsx2Tabs;


            //2. Load it into Editor instance from stream
            using (FileStream inputStream = File.OpenRead(inputFilePath))
            {
                using (Editor editor = new Editor(delegate { return inputStream;}, delegate { return new SpreadsheetLoadOptions();}))
                {
                    //3. Let's create an intermediate EditableDocument from 1st tab
                    SpreadsheetEditOptions editOptions1 = new SpreadsheetEditOptions();
                    editOptions1.WorksheetIndex = 0;//index is 0-based
                    EditableDocument firstTabBeforeEdit = editor.Edit(editOptions1);

                    //4. Let's create an intermediate EditableDocument from 2nd tab
                    SpreadsheetEditOptions editOptions2 = new SpreadsheetEditOptions();
                    editOptions2.WorksheetIndex = 1;//index is 0-based
                    EditableDocument secondTabBeforeEdit = editor.Edit(editOptions2);

                    //5. Save first tab from EditableDocument #1 to separate document
                    SpreadsheetSaveOptions saveOptions1 = new SpreadsheetSaveOptions(SpreadsheetFormats.Xlsm);
                    string outputFilename1 = Path.GetFileNameWithoutExtension(inputFilePath) + "_tab1.xlsm";
                    string outputPath1 = Path.Combine(FilesHelper.OutputFolder, outputFilename1);
                    editor.Save(firstTabBeforeEdit, outputPath1, saveOptions1);

                    //6. Save second tab from EditableDocument #2 to separate document
                    SpreadsheetSaveOptions saveOptions2 = new SpreadsheetSaveOptions(SpreadsheetFormats.Xlsb);
                    string outputFilename2 = Path.GetFileNameWithoutExtension(inputFilePath) + "_tab2.xlsb";
                    string outputPath2 = Path.Combine(FilesHelper.OutputFolder, outputFilename2);
                    editor.Save(secondTabBeforeEdit, outputPath2, saveOptions2);

                    //7. Dispose both EditableDocument instances
                    firstTabBeforeEdit.Dispose();
                    secondTabBeforeEdit.Dispose();
                }
            }
            System.Console.WriteLine("WorkingWithSpreadsheetMultiTab routine has successfully finished");
        }
    }
}