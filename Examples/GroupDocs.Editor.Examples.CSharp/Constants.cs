﻿using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace GroupDocs.Editor.Examples.CSharp
{
    internal static class Constants
    {
        private const string ProjectFolderName = "GroupDocs.Editor.Examples.CSharp";
        private const string ResourcesFolderName = "Resources";
        private static readonly string ResourceFolderFullPath;

        static Constants()
        {
            string exeFolderPath = Environment.CurrentDirectory;
            DirectoryInfo iterableFolder = new DirectoryInfo(exeFolderPath);
            byte safeCounter = 0;
            do
            {
                safeCounter++;
                string currentName = iterableFolder.Name;
                iterableFolder = iterableFolder.Parent;
                if (currentName.StartsWith(ProjectFolderName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    break;
                }
            } while (iterableFolder != null || safeCounter == 255);

            if (iterableFolder == null)
            {
                throw new InvalidOperationException(string.Format("Cannot find an ascendant directory, that starts from a '{0}' substring. Safe counter is {1}",
                    ProjectFolderName, safeCounter));
            }
            DirectoryInfo codebaseProject = iterableFolder.GetDirectories(ProjectFolderName, SearchOption.TopDirectoryOnly)[0];
            DirectoryInfo resourcesFolder = codebaseProject.GetDirectories(ResourcesFolderName, SearchOption.TopDirectoryOnly)[0];
            ResourceFolderFullPath = resourcesFolder.FullName;
        }

        public const string LicensePath = @"D:\GroupDocs\licenses\2019\Conholdate.Total.Product.Family.lic";

        public const string OutputPath = @"./Results/Output";

        public static string SAMPLE_DOCX => GetSampleFilePath("SampleDoc1.docx");

        public static string SAMPLE_HTML => GetSampleFilePath("SampleDoc1.html");

        public static string SAMPLE_HTML_BODY => GetSampleFilePath("PureContentSample.html");

        public static string SAMPLE_HTML_BODY_RESOURCES => GetSampleFilePath("PureContentSample_resources");

        public static string SAMPLE_CSV => GetSampleFilePath("CarsComma.csv");

        public static string SAMPLE_XLSX => GetSampleFilePath("Sample_2SpreadSheet.xlsx");

        public static string SAMPLE_XLS_PROTECTED => GetSampleFilePath("Timesheet - excel_password.xls");

        public static string SAMPLE_XML => GetSampleFilePath("SampleXmlCorrect.xml");

        public static string SAMPLE_TXT => GetSampleFilePath("SamplePlainText1.txt");

        public static string SAMPLE_PPTX => GetSampleFilePath("ComplexTest.pptx");

        private static string GetSampleFilePath(string filePath)
        {
            return Path.Combine(ResourceFolderFullPath, filePath);
        }


        public static string GetOutputDirectoryPath([CallerFilePath] string callerFilePath = null)
        {
            string outputDirectory = Path.Combine(OutputPath, Path.GetFileNameWithoutExtension(callerFilePath));

            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            string path = Path.GetFullPath(outputDirectory);
            return path;
        }
    }
}