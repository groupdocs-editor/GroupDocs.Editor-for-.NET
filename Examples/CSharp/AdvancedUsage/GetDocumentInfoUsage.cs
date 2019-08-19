using System;
using GroupDocs.Editor.Metadata;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates a usage of Editor.GetDocumentInfo method, that allows to extract metadata from file of unknown type (format)
    /// </summary>
    internal static class GetDocumentInfoUsage
    {
        internal static void Run()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("Starting 'GetDocumentInfoUsage' routine");

            //1. Let's check some WordProcessing document. Get its path or stream
            string docxInputFilePath = FilesHelper.Docx;

            //2. Instantiate Editor class, LoadOptions are not necessary, as we suppose that we know nothing about this file, especially don't know its format
            Editor editorDocx = new Editor(docxInputFilePath);

            //3. Check it
            IDocumentInfo infoDocx = editorDocx.GetDocumentInfo(null);

            //4. Maybe it is Spreadsheet?
            bool isSpreadsheet = infoDocx is SpreadsheetDocumentInfo;
            Console.WriteLine("Is '{0}' a Spreadsheet: {1}", docxInputFilePath, isSpreadsheet ? "yes" : "no");

            //5. Or text?
            bool isText = infoDocx is TextualDocumentInfo;
            Console.WriteLine("Is '{0}' a Textual document: {1}", docxInputFilePath, isText ? "yes" : "no");

            //6. Or maybe WordProcessing?
            bool isWordProcessing = infoDocx is WordProcessingDocumentInfo;
            Console.WriteLine("Is '{0}' a WordProcessing document: {1}", docxInputFilePath, isWordProcessing ? "yes" : "no");

            //7. If yes - get detailed info about it
            if (isWordProcessing)
            {
                WordProcessingDocumentInfo casted = (WordProcessingDocumentInfo) infoDocx;
                Console.WriteLine(string.Format("Format is: {0}; extension is: {1}; Page count: {2}; Size: {3} bytes; Is encrypted: {4}", 
                    casted.Format.Name, casted.Format.Extension, casted.PageCount, casted.Size, casted.IsEncrypted));
            }

            //8. Now let's check 2-tab Spreadsheet
            string xlsxInputFilePath = FilesHelper.Xlsx2Tabs;
            Editor editorXlsx = new Editor(xlsxInputFilePath);
            IDocumentInfo infoXlsx = editorXlsx.GetDocumentInfo(null);

            //9. Check and display its type
            Console.WriteLine("It is:\r\nWordProcessing: {0}\r\nSpreadsheet: {1}\r\nTextual: {2}",
                infoXlsx is WordProcessingDocumentInfo, infoXlsx is SpreadsheetDocumentInfo, infoXlsx is TextualDocumentInfo);

            //10. Print detailed info
            {
                SpreadsheetDocumentInfo casted = (SpreadsheetDocumentInfo) infoXlsx;
                Console.WriteLine(string.Format("Format is: {0}; extension is: {1}; Tabs count: {2}; Size: {3} bytes; Is encrypted: {4}",
                    casted.Format.Name, casted.Format.Extension, casted.PageCount, casted.Size, casted.IsEncrypted));
            }

            //11. Now let's try to open a password-protected document
            string xlsInputFilePath = FilesHelper.XlsProtected;
            Editor editorXls = new Editor(xlsInputFilePath);

            //12. First of all, try to check it without password
            IDocumentInfo infoXls;
            try
            {
                infoXls = editorXls.GetDocumentInfo(null);
            }
            catch (PasswordRequiredException)
            {
                Console.WriteLine("Oops! We tried to open a password-protected document without password");
            }

            //13. With invalid password at this time
            try
            {
                infoXls = editorXls.GetDocumentInfo("I don't know the password...");
            }
            catch (IncorrectPasswordException)
            {
                Console.WriteLine("Oops! We specified password at this time, but it is incorrect");
            }

            //14. Finally, let's try with valid password
            infoXls = editorXls.GetDocumentInfo("excel_password");

            //15. Check it
            Console.WriteLine("Password-protected document actually is:\r\nWordProcessing: {0}\r\nSpreadsheet: {1}\r\nTextual: {2}",
                infoXls is WordProcessingDocumentInfo, infoXls is SpreadsheetDocumentInfo, infoXls is TextualDocumentInfo);

            //16. Print detailed info
            {
                SpreadsheetDocumentInfo casted = (SpreadsheetDocumentInfo)infoXls;
                Console.WriteLine(string.Format("Format is: {0}; extension is: {1}; Tabs count: {2}; Size: {3} bytes; Is encrypted: {4}",
                    casted.Format.Name, casted.Format.Extension, casted.PageCount, casted.Size, casted.IsEncrypted));
            }

            //17. Now let's try to play with text-based documents
            string xmlInputFilePath = FilesHelper.Xml;
            Editor editorXml = new Editor(xmlInputFilePath);

            //18. Grab data and check it
            IDocumentInfo infoXml = editorXml.GetDocumentInfo(null);
            Console.WriteLine("XML document is:\r\nWordProcessing: {0}\r\nSpreadsheet: {1}\r\nTextual: {2}",
                infoXml is WordProcessingDocumentInfo, infoXml is SpreadsheetDocumentInfo, infoXml is TextualDocumentInfo);

            //19. Print detailed info
            {
                TextualDocumentInfo casted = (TextualDocumentInfo)infoXml;
                Console.WriteLine(string.Format("Format is: {0}; extension is: {1}; Encoding: {2}; Size: {3} bytes",
                    casted.Format.Name, casted.Format.Extension, casted.Encoding, casted.Size));
            }

            //20. Plain text at this time
            string txtInputFilePath = FilesHelper.Txt;
            Editor editorTxt = new Editor(txtInputFilePath);

            //21. Grab data and check it
            IDocumentInfo infoTxt = editorTxt.GetDocumentInfo(null);
            Console.WriteLine("Text document is:\r\nWordProcessing: {0}\r\nSpreadsheet: {1}\r\nTextual: {2}",
                infoTxt is WordProcessingDocumentInfo, infoTxt is SpreadsheetDocumentInfo, infoTxt is TextualDocumentInfo);

            //22. Print detailed info
            {
                TextualDocumentInfo casted = (TextualDocumentInfo)infoTxt;
                Console.WriteLine(string.Format("Format is: {0}; extension is: {1}; Encoding: {2}; Size: {3} bytes",
                    casted.Format.Name, casted.Format.Extension, casted.Encoding, casted.Size));
            }

            //23. Don't forget to dispose all resources
            editorDocx.Dispose();
            editorXlsx.Dispose();
            editorXls.Dispose();
            editorXml.Dispose();
            editorTxt.Dispose();

            System.Console.WriteLine("GetDocumentInfoUsage routine has successfully finished");
        }
    }
}