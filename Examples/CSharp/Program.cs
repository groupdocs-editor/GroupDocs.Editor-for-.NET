using System;

namespace GroupDocs.Editor.Examples.CSharp
{
    /// <summary>
    /// Root class and entry point
    /// </summary>
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Open Program.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");

            #region Set license
            BasicUsage.LicenseSetter.Run();
            //BasicUsage.MeteredLicenseSetter.Run();
            #endregion Set license

            #region Roundtrip conversion - basic example
            //BasicUsage.BasicRoundtrip.Run();
            #endregion Roundtrip conversion - basic example

            #region Standard WordProcessing roundtrip
            //BasicUsage.StandardWordProcessingRoundtrip.Run();
            #endregion Standard WordProcessing roundtrip

            #region Password Protected Spreadsheet roundtrip
            //BasicUsage.PasswordProtectedSpreadsheetRoundtrip.Run();
            #endregion Password Protected Spreadsheet roundtrip

            #region Multi-tab Spreadsheet roundtrip
            //BasicUsage.MultiTabSpreadsheetRoundtrip.Run();
            #endregion Multi-tab Spreadsheet roundtrip

            #region XML conversion
            //BasicUsage.XmlConversion.Run();
            #endregion XML conversion

            #region Plain text roundtrip
            //BasicUsage.PlainTextRoundtrip.Run();
            #endregion Plain text roundtrip

            #region Dsv Roundtrip
            //BasicUsage.DsvRoundtrip.Run();
            #endregion Dsv Roundtrip

            #region Get Document Info
            AdvancedUsage.GetDocumentInfoUsage.Run();
            #endregion Get Document Info

            Console.WriteLine("\r\n\r\n__________________________\r\nAll done. Press any key to exit.");
            Console.ReadKey();
            return;
        }
    }
}
