using System;
using System.IO;

namespace GroupDocs.Editor.Examples.CSharp
{
    internal static class FilesHelper
    {
        private const string ProjectFolderName = "GroupDocs.Editor.Examples.CSharp";
        private const string ResourcesFolderName = "Resources";
        private static readonly string DataFolderFullPath;

        static FilesHelper()
        {
            string exeFolderPath = Environment.CurrentDirectory;
            DirectoryInfo iterableFolder = new DirectoryInfo(exeFolderPath);
            byte safeCounter = 0;
            do
            {
                safeCounter++;
                string currentName = iterableFolder.Name;
                iterableFolder = iterableFolder.Parent;
                if (currentName.Equals(ProjectFolderName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    break;
                }
            } while (iterableFolder != null || safeCounter == 255);
            DirectoryInfo dataFolderPath = iterableFolder.GetDirectories(ResourcesFolderName, SearchOption.TopDirectoryOnly)[0];
            DataFolderFullPath = dataFolderPath.FullName;
        }

        internal static string LicensePath
        {
            get
            {
                string licensePath = "D:/Some path/to license/file.lic";
                return licensePath;
            }
        }

        internal static string DataFolderPath
        {
            get { return DataFolderFullPath; }
        }

        internal static string Docx
        {
            get { return Path.Combine(DataFolderPath, "SampleDoc1.docx"); }
        }

        internal static string Csv
        {
            get { return Path.Combine(DataFolderPath, "CarsComma.csv"); }
        }

        internal static string Xlsx2Tabs
        {
            get { return Path.Combine(DataFolderPath, "Sample_2SpreadSheet.xlsx"); }
        }

        internal static string XlsProtected
        {
            get { return Path.Combine(DataFolderPath, "Timesheet - excel_password.xls"); }
        }

        internal static string Xml
        {
            get { return Path.Combine(DataFolderPath, "SampleXmlCorrect.xml"); }
        }

        internal static string Txt
        {
            get { return Path.Combine(DataFolderPath, "SamplePlainText1.txt"); }
        }

        internal static string HtmlFile
        {
            get { return Path.Combine(DataFolderPath, "SampleDoc1.html"); }
        }

        internal static string InnerBodyHtmlFile
        {
            get { return Path.Combine(DataFolderPath, "PureContentSample.html"); }
        }

        internal static string InnerBodyResourceFolder
        {
            get { return Path.Combine(DataFolderPath, "PureContentSample_resources"); }
        }

        internal static string Pptx
        {
            get { return Path.Combine(DataFolderPath, "ComplexTest.pptx"); }
        }

        internal static string OutputFolder
        {
            get { return System.Environment.CurrentDirectory; }
        }
    }
}