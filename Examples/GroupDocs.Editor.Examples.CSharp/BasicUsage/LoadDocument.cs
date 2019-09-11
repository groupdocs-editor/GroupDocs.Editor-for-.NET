using System.IO;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to load input document to the GroupDocs.Editor and how to apply load options.
    /// </summary>
    internal static class LoadDocument
    {
        internal static void Run()
        {
            
            string inputPath = FilesHelper.Docx;
            
            //Load document as file via path and without load options
            Editor editor1 = new Editor(inputPath);

            //Load document as file via path and with load options
            Options.WordProcessingLoadOptions wordLoadOptions = new WordProcessingLoadOptions();
            wordLoadOptions.Password = "some password";
            Editor editor2 = new Editor(inputPath, delegate { return wordLoadOptions;});

            FileStream inputStream = File.OpenRead(FilesHelper.Xlsx2Tabs);

            //Load document as content from byte stream and without load options
            Editor editor3 = new Editor(delegate { return inputStream;});

            //Load document as content from byte stream and with load options
            Options.SpreadsheetLoadOptions sheetLoadOptions = new SpreadsheetLoadOptions();
            sheetLoadOptions.OptimizeMemoryUsage = true;
            Editor editor4 = new Editor(delegate { return inputStream;}, delegate { return sheetLoadOptions;});

            //Dispose all resources
            editor1.Dispose();
            editor2.Dispose();
            editor3.Dispose();
            editor4.Dispose();

            System.Console.WriteLine("LoadDocument routine has successfully finished");
        }
    }
}