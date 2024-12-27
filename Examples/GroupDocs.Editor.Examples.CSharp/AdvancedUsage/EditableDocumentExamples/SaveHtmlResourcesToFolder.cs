using GroupDocs.Editor.HtmlCss.Resources.Fonts;
using GroupDocs.Editor.HtmlCss.Resources.Images;
using GroupDocs.Editor.HtmlCss.Resources.Textual;
using GroupDocs.Editor.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples
{
    class SaveHtmlResourcesToFolder
    {
        internal static void Run()
        {
            using (Editor editor = new Editor(Constants.SAMPLE_DOCX, new WordProcessingLoadOptions()))
            {
                using (EditableDocument document = editor.Edit(new WordProcessingEditOptions()))
                {
                    List<IImageResource> images = document.Images;
                    List<FontResourceBase> fonts = document.Fonts;
                    List<CssText> stylesheets = document.Css;

                    string outputFolder = Constants.GetOutputDirectoryPath(Constants.SAMPLE_DOCX);

                    foreach (IImageResource oneImage in images)
                    {
                        Console.WriteLine("Saving {0} of {1} type and {2} dimensions",
                            oneImage.FilenameWithExtension, oneImage.Type.FormalName, oneImage.LinearDimensions);
                        oneImage.Save(Path.Combine(outputFolder, oneImage.FilenameWithExtension));
                    }

                    foreach (FontResourceBase oneFont in fonts)
                    {
                        Console.WriteLine("Saving {0} of {1} type",
                            oneFont.FilenameWithExtension, oneFont.Type.FormalName);
                        oneFont.Save(Path.Combine(outputFolder, oneFont.FilenameWithExtension));
                    }

                    foreach (CssText oneStylesheet in stylesheets)
                    {
                        Console.WriteLine("Saving {0} of {1} type and {2} encoding",
                            oneStylesheet.FilenameWithExtension, oneStylesheet.Type.FormalName, oneStylesheet.Encoding);
                        oneStylesheet.Save(Path.Combine(outputFolder, oneStylesheet.FilenameWithExtension));
                    }
                }
            }
        }
    }
}