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
            foreach (Formats.WordProcessingFormats oneFormat in Formats.WordProcessingFormats.All)
            {
                System.Console.WriteLine("Name is {0}, extension is {1}", oneFormat.Name, oneFormat.Extension);
            }

            //Presentation
            foreach (Formats.PresentationFormats oneFormat in Formats.PresentationFormats.All)
            {
                System.Console.WriteLine("Name is {0}, extension is {1}", oneFormat.Name, oneFormat.Extension);
            }

            //Parsing from extension
            Formats.SpreadsheetFormats expectedXlsm = Formats.SpreadsheetFormats.FromExtension(".xlsm");
            System.Console.WriteLine("Parsed Spreadsheet format is {0}", expectedXlsm.Name);
            Formats.TextualFormats expectedHtml = Formats.TextualFormats.FromExtension("html");
            System.Console.WriteLine("Parsed Textual format is {0}", expectedHtml.Name);
        }
    }
}