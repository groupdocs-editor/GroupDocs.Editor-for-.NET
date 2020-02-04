using System;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Editor.HtmlCss.Resources.Fonts;
using GroupDocs.Editor.HtmlCss.Resources.Images;
using GroupDocs.Editor.HtmlCss.Resources.Textual;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples
{
    /// <summary>
    /// This example demonstrates working and operating with resources (GroupDocs.Editor.HtmlCss.Resources namespace)
    /// </summary>
    internal static class WorkingWithResources
    {
        internal static void Run()
        {
            /*
             * Almost every document contains or may contain some attachments of binary or textual nature; first of all they are images and/or fonts.
             * Also, when input document is converted to the intermediate EditableDocument instance,
             * all style-related data may be represented as stylesheets (CSS).
             * All of these are grouped in the GroupDocs.Editor.HtmlCss.Resources namespace, where every resource has its own class and methods.
             */
            Console.WriteLine("****************************************");
            Console.WriteLine("Investigating resources of DOCX document");

            //1. Lets create a EditableDocument instance in usual way, by loading and editing input document of some supportable format
            string inputFilePath = Constants.SAMPLE_DOCX;
            Editor editor = new Editor(inputFilePath, delegate { return new WordProcessingLoadOptions(); });

            WordProcessingEditOptions editOptions = new WordProcessingEditOptions();
            //1.1. Enable max font extraction - ExtractAll
            editOptions.FontExtraction = FontExtractionOptions.ExtractAll;

            //1.2. Create EditableDocument instance
            EditableDocument beforeEdit = editor.Edit(editOptions);

            //2. Gather resources
            List<IImageResource> images = beforeEdit.Images;
            List<FontResourceBase> fonts = beforeEdit.Fonts;
            List<CssText> stylesheets = beforeEdit.Css;

            //3. Print detailed info about every used resource and save every resource to the file
            string outputFolderPath = Path.Combine(Constants.GetOutputDirectoryPath(), "Resources");
            if (!Directory.Exists(outputFolderPath))
            {
                Directory.CreateDirectory(outputFolderPath);
            }

            //3.1. All image resources implement IImageResource interface.
            Console.WriteLine("{0} images are used:", images.Count);
            for (int i = 0; i < images.Count; i++)
            {
                IImageResource oneImage = images[i];
                Console.WriteLine("{0}. {1}. Type: {2}. Aspect ratio: {3}. Linear dimensions: {4}px",
                    i, oneImage.FilenameWithExtension, oneImage.Type.FormalName, oneImage.AspectRatio.ToString(), oneImage.LinearDimensions.ToString());
                oneImage.Save(Path.Combine(outputFolderPath, oneImage.FilenameWithExtension));
            }
            Console.WriteLine();

            //3.2. All fonts implement FontResourceBase abstract class
            Console.WriteLine("{0} fonts are used:", fonts.Count);
            for (int i = 0; i < fonts.Count; i++)
            {
                FontResourceBase oneFont = fonts[i];
                Console.WriteLine("{0}. {1}. Type: {2}.",
                    i, oneFont.FilenameWithExtension, oneFont.Type.FormalName);
                oneFont.Save(Path.Combine(outputFolderPath, oneFont.FilenameWithExtension));
            }
            Console.WriteLine();

            //3.3. All stylesheets are of CssText type
            Console.WriteLine("{0} stylesheets are used:", stylesheets.Count);
            for (int i = 0; i < stylesheets.Count; i++)
            {
                CssText oneStylesheet = stylesheets[i];
                Console.WriteLine("{0}. {1}. Type: {2}. Encoding: {3}.",
                    i, oneStylesheet.FilenameWithExtension, oneStylesheet.Type.FormalName, oneStylesheet.Encoding);
                oneStylesheet.Save(Path.Combine(outputFolderPath, oneStylesheet.FilenameWithExtension));
            }
            Console.WriteLine();

            //4. For every resource it is possible to get its content:
            //4.1. As a byte stream...
            Stream ms = images[0].ByteContent;//do with this stream something
            //4.2. ...and as a base64-encoded string
            string base64EncodedResource = images[0].TextContent;
            
            //Don't forget to dispose all resources
            beforeEdit.Dispose();
            editor.Dispose();
            System.Console.WriteLine("WorkingWithResources routine has successfully finished");
        }
    }
}