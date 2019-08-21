using System;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Editor.HtmlCss.Resources;
using GroupDocs.Editor.HtmlCss.Resources.Fonts;
using GroupDocs.Editor.HtmlCss.Resources.Images;
using GroupDocs.Editor.HtmlCss.Resources.Textual;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates advanced work with EditableDocument class, that represents intermediate document before and after editing
    /// </summary>
    internal static class EditableDocumentAdvancedUsage
    {
        internal static void Run()
        {
            /*
             * Instance of EditableDocument class can be produced by the Editor.Edit method or created by the user himself.
             * EditableDocument internally stores document in its own closed format,
             * which is compatible (convertible) with all import and export formats, that GroupDocs.Editor supports.
             * In order to make document editable in any WYSIWYG client-side editor (like CKEditor or TinyMCE), EditableDocument provides methods for generating HTML markup and producing resources, that can be accepted by the user.
             */

            //1. Lets create a EditableDocument instance in usual way, by loading and editing input document of some supportable format
            string inputFilePath = FilesHelper.Docx;
            Editor editor = new Editor(inputFilePath, delegate { return new WordProcessingLoadOptions();});
            EditableDocument beforeEdit = editor.Edit(new WordProcessingEditOptions());

            //2. Now beforeEdit contains "disassembled" version of input DOCX, and it is possible to get it whole or get some of its parts

            //2.1. It is possible to generate a single string, that contains all document with all its resources as a single HTML, where stylesheets are embedded into STYLE tags, while images and fonts are embedded using base64 encoding.
            string allAsHtmlInsideOneString = beforeEdit.GetEmbeddedHtml();//note: this string is huge

            //2.2. There is ability to extract all images
            List<IImageResource> allImages = beforeEdit.Images;

            //2.3. Ability to extract all fonts
            List<FontResourceBase> allFonts = beforeEdit.Fonts;

            //2.4. Ability to extract all stylesheets and present them in textual (serialized) form
            List<CssText> allStylesheets = beforeEdit.Css;

            //2.5. There is also an ability to gather all resources at one call
            List<IHtmlResource> allResources = beforeEdit.AllResources;
            //allResources in fact is a concatenation of all images, fonts and stylesheets (allImages + allFonts + allStylesheets)

            //2.6. Obtain HTML markup of the document (without embedded resources)
            string htmlMarkup = beforeEdit.GetContent();

            //3. Sometimes it is necessary to obtain HTML markup, where all external links will be adjusted to some remote resource,
            // that can handle these resource requests. EditableDocument allows to specify such prefix.
            // Such markup, with tuned links, can be injected directly into WYSIWYG-editor.

            //3.1. Preparing prefixes, that will prepend original external links
            string customImagesRequesthandlerUri = "http://example.com/ImagesHandler/id=";
            string customCssRequesthandlerUri = "http://example.com/CssHandler/id=";
            string customFontsRequesthandlerUri = "http://example.com/FontsHandler/id=";

            //3.2. Generating prefixed HTML markup to a string.
            // Now, for example, <img src="car.jpg" /> is turned into <img src="http://example.com/ImagesHandler/id=car.jpg" />
            string prefixedHtmlMarkup = beforeEdit.GetContent(customImagesRequesthandlerUri, customCssRequesthandlerUri);

            //3.3. Some WYSIWYG-editors can handle only pure TML markup, without header (in other words, only internals of HTML->BODY element).
            // EditableDocument can provide such part of a document.
            string onlyBodyContent = beforeEdit.GetBodyContent();

            //3.4. Like with overall content, it is possible to specify a custom prefix for external images
            string prefixedBodyContent = beforeEdit.GetBodyContent(customImagesRequesthandlerUri);

            //3.5. Sometimes it is required to obtain only stylesheet for the document.
            // Depending on the scenario and input document type, document can have one or more stylesheets.
            // EditableDocument can return all of them as a list of strings, where one string represents one stylesheet
            List<string> stylesheets = beforeEdit.GetCssContent();

            //3.6. Like with overall and BODY-only content, it is possible to specify an external resource prefix
            List<string> prefixedStylesheets = beforeEdit.GetCssContent(customImagesRequesthandlerUri, customFontsRequesthandlerUri);

            //4. It is possible to save the document from EditableDocument as a simple HTML-file with resources to the disk
            // In the example below a separate directory for resources (stylesheets, images, and fonts) will be created automatically.
            // However, by using a 2-parameter overload of a "Save" method you can create it manually.
            string htmlFilePath = Path.Combine(FilesHelper.OutputFolder, Path.GetFileNameWithoutExtension(inputFilePath) + ".html");
            beforeEdit.Save(htmlFilePath);

            //5. Along with implementing IDisposable, EditableDocument provides ability to check whether current instance is disposed
            // and subscribe to the disposing event
            Console.WriteLine("beforeEdit variable of EditableDocument type is {0} disposed", !beforeEdit.IsDisposed ? "not" : "already");

            EventHandler someMethod = delegate
            {//Custom OnDispose event handler, that will be triggered right after beforeEdit disposing
                Console.WriteLine("Disposing event was spotted!");
            };
            beforeEdit.Disposed += someMethod;


            //6. It is possible to create instance of EditableDocument from input HTML document (with optional resources). There are two static factories:
            //6.1. From HTML file with resources on disk
            EditableDocument afterEditFromFile = EditableDocument.FromFile(htmlFilePath, null);
            //6.2.
            EditableDocument afterEditFromMarkup = EditableDocument.FromMarkup(htmlMarkup, allResources);

            //6.3. In the examples above two EditableDocument instances (afterEditFromFile and afterEditFromMarkup)
            //were created from content of initial EditableDocument (beforeEdit). So, all 3 of them are identical.

            //7. Manually dispose beforeEdit. Note that 'someMethod' event handler will fire only now
            beforeEdit.Dispose();
            afterEditFromFile.Dispose();
            afterEditFromMarkup.Dispose();
            editor.Dispose();

            System.Console.WriteLine("EditableDocumentAdvancedUsage routine has successfully finished");
        }
    }
}