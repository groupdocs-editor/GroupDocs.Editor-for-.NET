using System;
using System.Collections.Generic;
using System.IO;
using TinyMce.MvcSample.Models;

namespace TinyMce.MvcSample
{
    public class Repository
    {
        public static string PrepareFilename(string inputFilename)
        {
            if (inputFilename == null) { throw new ArgumentNullException("inputFilename"); }
            string temp = Path.GetFileName(inputFilename);
            temp = temp.Replace(' ', '_');
            temp = temp.Replace('.', '_');
            return temp;
        }

        public static bool CreateFolderIfNotExists(string folderPath)
        {
            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ClearOrCreate(string fullPath)
        {
            if (fullPath == null) { throw new ArgumentNullException("fullPath"); }
            DirectoryInfo inputDir = new DirectoryInfo(fullPath);
            if (!inputDir.Exists)
            {
                Directory.CreateDirectory(fullPath);
                return true;
            }
            else
            {
                foreach (DirectoryInfo dir in inputDir.GetDirectories())
                {
                    dir.Delete(true);
                }
                foreach (FileInfo file in inputDir.GetFiles())
                {
                    file.Delete();
                }
                return false;
            }
        }

        public static List<SampleDocumentInfo> PrepareSampleDocuments(string sampleDocumentsFolder)
        {
            List<SampleDocumentInfo> output = new List<SampleDocumentInfo>();

            DirectoryInfo sampleDocumentsFolderInfo = new DirectoryInfo(sampleDocumentsFolder);

            foreach (DirectoryInfo oneSubFolder in sampleDocumentsFolderInfo.GetDirectories())
            {
                foreach (FileInfo oneDocument in oneSubFolder.GetFiles())
                {
                    //if (oneDocument.Extension.Equals(".doc", StringComparison.OrdinalIgnoreCase) ||
                    //    oneDocument.Extension.Equals(".docx", StringComparison.OrdinalIgnoreCase))
                    {
                        output.Add(new SampleDocumentInfo(
                            oneSubFolder.Name + "/" + oneDocument.Name, oneDocument.FullName, oneDocument.LastWriteTime, (int)oneDocument.Length));
                    }
                }
            }

            foreach (FileInfo oneDocument in sampleDocumentsFolderInfo.GetFiles())
            {
                //if (oneDocument.Extension.Equals(".doc", StringComparison.OrdinalIgnoreCase) ||
                //    oneDocument.Extension.Equals(".docx", StringComparison.OrdinalIgnoreCase))
                {
                    output.Add(new SampleDocumentInfo(
                            oneDocument.Name, oneDocument.FullName, oneDocument.LastWriteTime, (int)oneDocument.Length));
                }
            }

            return output;
        }

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}