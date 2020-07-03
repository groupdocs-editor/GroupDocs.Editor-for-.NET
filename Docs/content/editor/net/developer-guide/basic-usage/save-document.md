---
id: save-document
url: editor/net/save-document
title: Save document
weight: 4
description: "This article demonstrates how to save edited text documents, spreadsheets and presentations with GroupDocs.Editor for .NET API."
keywords: Save edited document, edit document, GroupDocs.Editor
productName: GroupDocs.Editor for .NET
hideChildren: False
---
This article describes how to obtain edited document content from client, process it and save to the resultant document of some specified format.

When end-user has finished document editing in the WYSIWYG HTML-editor (this is usually a pure client-side application, written on JavaScript), he submits the editing operation, and HTML markup with stylesheets, images, and maybe other resources are passed to the server-side. In order to generate a document of some output format, these resources should be passed to the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument).

As it was shown in previous articles, instances of [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) are generated and returned by the [Editor](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor).[Edit()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/edit) method and then are used for emitting HTML markup and resources for passing them *to* the WYSIWYG editor.  
However [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) also has a second purpose — to obtain edited content *from* WYSIWYG editor. [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) class has no public constructors; instead of them it has two static factories, that obtain HTML document in different forms:

1.  [FromFile](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/fromfile) method is designed for opening HTML-documents from disk — it obtains path to \*.html file and path to corresponding resource folder.
2.  [FromMarkup](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/frommarkup) method is designed for opening HTML-documents from memory — it obtains HTML-markup as a `System.String` and a list of [IHtmlResource](https://apireference.groupdocs.com/net/editor/groupdocs.editor.htmlcss.resources/ihtmlresource) items.

More information about creating [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instances from files or markup with resources can be found in corresponding article "[Create EditableDocument from file or markup]({{< ref "editor/net/developer-guide/advanced-usage/working-with-editabledocument/create-editabledocument-from-file-or-markup.md" >}})".

When [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) is created, it can be converted to the output document. For doing this, user must use [Editor](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor).[Save()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/save) method, that has two overloads. These overloads differ only with the way how output document is specified: as path, where file should be created, or as a byte stream, into which the document content should be written. All other parameters are same. They are:

1.  Instance of [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) class, that holds a content of edited document.
2.  Output document, that is specified as file path (`System.String`) or byte stream (`System.IO.Stream`).
3.  Mandatory save options, that are represented by one of inheritors of the [ISaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/isaveoptions) interface.

Like with load and edit options, every family format has its own class, that implements [ISaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/isaveoptions) interface. These classes are listed below.

| Format family | Example formats | Save options class | Format class |
| --- | --- | --- | --- |
| WordProcessing | DOC, DOCX, DOCM, DOT, ODT | [WordProcessingSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions) | [WordProcessingFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/wordprocessingformats) |
| Spreadsheet | XLS, XLSX, XLSM, XLSB | [SpreadsheetSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetsaveoptions) | [SpreadsheetFormat](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/spreadsheetformats) |
| Delimiter-Separated Values (DSV) | CSV, TSV | [DelimitedTextSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/delimitedtextsaveoptions) | [TextualFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/textualformats) |
| Presentation | PPT, PPTX, PPS, POT | [PresentationSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/presentationsaveoptions) | [PresentationFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/presentationformats) |
| Plain Text documents | TXT | [TextSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/textsaveoptions) | [TextualFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/textualformats) |
| PDF | PDF | [PdfSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/pdfsaveoptions) | N/A |

Source code below shows creating an instance of [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) class and consequent saving a two versions of the document: one to the file and second — to the stream.

```csharp
string inputHtmlPath = "C:\input\document.html";
EditableDocument document = EditableDocument.FromFile(inputHtmlPath, null);

Editor editor = new Editor("C:\path\original.docx");

//save 1st version to file through path
string outputPath = "C:\\output_path\\document.rtf";
WordProcessingSaveOptions saveOptions1 = new WordProcessingSaveOptions(WordProcessingFormats.Rtf);
editor.Save(document, outputPath, saveOptions1);

//save 2nd version to stream
MemoryStream outputStream = new MemoryStream();
WordProcessingSaveOptions saveOptions2 = new WordProcessingSaveOptions(WordProcessingFormats.Docm);
editor.Save(document, outputStream, saveOptions2);
```

As you can see from example above, it is possible to create multiple output documents from a single `EditableDocument` with different save options and different formats. And these output formats should not be strictly same as format of input document.

Even more: in some cases format family can also be different. For example, original document can be some of WordProcessing formats, while output document can be TXT or PDF. Same transitions are allowed between Spreadsheets and DSV (two-ways). But, of course, they are not allowed, where formats are theoretically incompatible in their essence, like WordProcessing and Spreadsheet.

## More resources
### Advanced Usage Topics
To learn more about document viewing features, please refer to the [advanced usage section]({{< ref "editor/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Editor for .NET examples, plugins, and showcase](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET)   
*   [GroupDocs.Editor for Java examples, plugins, and showcase](https://github.com/groupdocs-editor/GroupDocs.Editor-for-Java)    
*   [Document Editor for .NET MVC UI Example](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-MVC)     
*   [Document Editor for .NET App WebForms UI Modern Example](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-WebForms)    
*   [Document Editor for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-editor/GroupDocs.Editor-for-Java-Dropwizard)    
*   [Document Editor for Java Spring UI Example](https://github.com/groupdocs-editor/GroupDocs.Editor-for-Java-Spring)
    
### Free Online App
Along with full-featured .NET library we provide simple but powerful free Apps.  
You are welcome to edit your Microsoft Word (DOC, DOCX, RTF etc.), Microsoft Excel (XLS, XLSX, CSV etc.), Open Document (ODT, OTT, ODS) and other documents with free to use online **[GroupDocs Editor App](https://products.groupdocs.app/editor)**.

