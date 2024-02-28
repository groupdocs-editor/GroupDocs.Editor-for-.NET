using System;
using System.IO;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples
{
    /// <summary>
    /// This example demonstrates creating instance of EditableDocument from inner-BODY markup (without HTML->HEAD->BODY elements) and resource folder
    /// </summary>
    internal static class CreateEditableDocumentFromInnerBody
    {
        internal static void Run()
        {
            //1. Get path to the file with HTML BODY inner markup
            string pathToHtmlFile = Constants.SAMPLE_HTML_BODY;

            //2. Read this markup to string
            string content = File.ReadAllText(pathToHtmlFile);

            //3. Get path to the resource folder
            string pathToResourceFolder = Constants.SAMPLE_HTML_BODY_RESOURCES;

            //4. Initialize EditableDocument
            using (EditableDocument inputDoc = EditableDocument.FromMarkupAndResourceFolder(content, pathToResourceFolder))
            {
                //5. Check obtained document
                Console.WriteLine("There should be 2 stylesheets, and actually is {0}", inputDoc.Css.Count);
                Console.WriteLine("There should be 2 images, and actually is {0}", inputDoc.Images.Count);

                //6. Save it to the file
                string outputHtmlFilePath = Path.Combine(Constants.GetOutputDirectoryPath(pathToHtmlFile), Path.GetFileNameWithoutExtension(pathToHtmlFile) + "_output.html");
                inputDoc.Save(outputHtmlFilePath);

                //7. Save it to the document
                //7.1. Get saving format
                Formats.WordProcessingFormats saveFormat = Formats.WordProcessingFormats.FromExtension("docm");
                //7.2. Get saving options
                Options.WordProcessingSaveOptions saveOptions = new Options.WordProcessingSaveOptions(saveFormat);
                //7.3. Create instance of Editor class, initialize it with anything
                using (Editor editor = new Editor(pathToHtmlFile))
                {
                    //7.4. Prepare output path for the DOCM document
                    string outputDocmFilePath = Path.Combine(Constants.GetOutputDirectoryPath(pathToHtmlFile),
                        Path.GetFileNameWithoutExtension(pathToHtmlFile) + "_output." + saveFormat.Extension);
                    //7.5. Save it
                    editor.Save(inputDoc, outputDocmFilePath, saveOptions);
                }
            }
            System.Console.WriteLine("CreateEditableDocumentFromInnerBody routine has successfully finished");
        }
    }
}