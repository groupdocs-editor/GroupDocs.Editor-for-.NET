//ExStart:CommonClass
using System;
using System.IO;
using System.Collections.Generic;
using GroupDocs.Editor;
using System.Reflection;

namespace GroupDocs.Editor.Examples.CSharp
{
    class Common
    {
        //ExStart:CommonProperties
        // storagePath property to set source file/s directory
        public static string sourcePath = Path.Combine(Environment.CurrentDirectory, @"../../../../Data/SourceFiles/");

        // sourceResourcesPath property to set source resources directory
        public static string sourceResourcesPath = Path.Combine(Environment.CurrentDirectory, @"../../../../Data/SourceFiles/");

        // outputPath property to set output file/s directory
        public static string resultPath = Path.Combine(Environment.CurrentDirectory, @"../../../../Data/OuputFiles");

        // resultResourcesPath property to set output resources directory
        public static string resultResourcesPath = Path.Combine(Environment.CurrentDirectory, @"../../../../Data/OuputFiles");

        // licensePath property to set GroupDocs.Editor license file anme and path
        public static string licensePath = Path.Combine(Environment.CurrentDirectory, @"GroupDocs.editor.lic");

        // sourceFile property to set input source file
        public static string sourceFile = "source.docx";

        // resultResourcesFolder property to set input resources folder name
        public static string sourceResourcesFolder = "Resources";

        // resultResourcesFolder property to set output resources folder name
        public static string resultResourcesFolder = "Resources";

        // sourceFilePassword property to set input source file password
        public static string sourceFilePassword = "SomePassword";

        // targetFile property to set input target file
        public static string resultFile = "result.docx";

        //ExEnd:CommonProperties

        //ExStart:ApplyLicense
        /// <summary>
        /// Applies GroupDocs.Editor license
        /// </summary>
        public static void ApplyLicense(string filepath)
        {
            // Instantiate GroupDocs.Editor license
            GroupDocs.Editor.License license = new GroupDocs.Editor.License();

            // Apply GroupDocs.Editor license using license path
            license.SetLicense(filepath);
        }

        /// <summary>
        /// Applies GroupDocs.Editor license using stream input
        /// </summary>
        public static void ApplyLicense(Stream licenseStream)
        {
            // Instantiate GroupDocs.Editor license
            GroupDocs.Editor.License license = new GroupDocs.Editor.License();

            // Apply GroupDocs.Editor license using license file stream
            license.SetLicense(licenseStream);
        }
        //ExEnd:ApplyLicense
    }
}
//ExEnd:CommonClass