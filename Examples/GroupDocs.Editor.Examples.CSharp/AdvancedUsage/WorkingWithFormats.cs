using System;
using GroupDocs.Editor.Formats;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates operations with structs, which implement IDocumentFormat and represent all supportable file formats
    /// </summary>
    internal static class WorkingWithFormats
    {
        internal static void Run()
        {
            //WordProcessing
            foreach (WordProcessingFormats oneFormat in Formats.WordProcessingFormats.All)
            {
                Console.WriteLine("Name is {0}, extension is {1}", oneFormat.Name, oneFormat.Extension);
            }

            //Presentation
            foreach (PresentationFormats oneFormat in Formats.PresentationFormats.All)
            {
                Console.WriteLine("Name is {0}, extension is {1}", oneFormat.Name, oneFormat.Extension);
            }

            //Parsing from extension
            Formats.SpreadsheetFormats expectedXlsm = SpreadsheetFormats.FromExtension(".xlsm");
            Console.WriteLine("Parsed Spreadsheet format is {0}", expectedXlsm.Name);
            Formats.TextualFormats expectedHtml = TextualFormats.FromExtension("html");
            Console.WriteLine("Parsed Textual format is {0}", expectedHtml.Name);
        }
    }
}