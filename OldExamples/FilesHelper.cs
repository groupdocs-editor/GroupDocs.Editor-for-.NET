using System;
using System.IO;

namespace GroupDocs.Editor.Examples.CSharp
{
    internal static class FilesHelper
    {
        private static readonly string DataFolderFullPath;

        static FilesHelper()
        {
            string exeFolderPath = Environment.CurrentDirectory;
            DirectoryInfo iterableFolder = new DirectoryInfo(exeFolderPath);
            byte safeCounter = 0;
            const string projectFolderName = "CSharp";
            do
            {
                safeCounter++;
                string currentName = iterableFolder.Name;
                iterableFolder = iterableFolder.Parent;
                if (currentName.Equals(projectFolderName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    break;
                }
            } while (iterableFolder != null || safeCounter == 255);
            DirectoryInfo dataFolderPath = iterableFolder.GetDirectories("Data", SearchOption.TopDirectoryOnly)[0];
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

        internal static string OutputFolder
        {
            get { return System.Environment.CurrentDirectory; }
        }
    }
}