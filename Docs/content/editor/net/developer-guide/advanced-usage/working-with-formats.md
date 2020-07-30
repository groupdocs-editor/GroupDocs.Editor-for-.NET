---
id: working-with-formats
url: editor/net/working-with-formats
title: Working with formats
weight: 8
description: "This article explains document formats and format families supported by GroupDocs.Editor for .NET and how to operate them in .NET code."
keywords: GroupDocs.Editor supported formats, editable document formats
productName: GroupDocs.Editor for .NET
hideChildren: False
---
> This article describes classes and interfaces of [**GroupDocs.Editor**](https://products.groupdocs.com/editor/net), which represent all supportable family formats and individual formats.

GroupDocs.Editor supports different document formats, all of them are conditionally divided onto several family formats:

1.  WordProcessing formats, which includes DOC, DOCX, DOCM, RTF, ODT etc.
2.  Spreadsheet formats, which includes XLS, XLT, XLSX, XLSM, XLTX, ODS etc.
3.  Delimiter-Separated Values (DSV) formats, also known as delimited text, that are text-based form of spreadsheets, and includes CSV, TSV, semicolon-delimited, whitespace-delimited etc.
4.  Presentation formats, which includes PPT, PPS, POT, PPTX, PPTM etc.
5.  Text-based formats, which includes TXT, HTML, XML etc.
6.  Fixed-layout formats, which includes only PDF at this time (for version 19.12).

For representing some of these format families the [Formats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/)namespace and [IDocumentFormat](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/idocumentformat)interface exists, along with four inheritors of this interface:

1.  [WordProcessingFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/wordprocessingformats), which is common for all WordProcessing formats.
2.  [SpreadsheetFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/spreadsheetformats), which is common for all Spreadsheet formats.
3.  [PresentationFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/presentationformats), which is common for all Presentation formats.
4.  [TextualFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/textualformats), which is common for all text-based formats, including plain text (TXT), markup formats (XML and HTML), and all Delimiter-Separated Values (DSV) formats.

All these types are immutable structs, all of them have text properties, which reflect their names and file extensions, all of them are equatable. Every struct has a set of static fields, each one represents one specific format within given family format. For every struct there is a `FromExtension` static method, that obtains a file extension, parses it and returns an instance of appropriate format. Every struct has an `All` static field, which allows enumeration over all specific formats within given family format.

Example below demonstrates all main features for the [WordProcessingFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/wordprocessingformats) struct; same is applicable for all other structs.

```csharp
//fetching one format
WordProcessingFormats dotm = Formats.WordProcessingFormats.Dotm;
Console.WriteLine("DOT Macro-enabled: Name is {0}, extension is {1}", dotm.Name, dotm.Extension);
//iterating over all formats within WordProcessing family
foreach (WordProcessingFormats oneFormat in Formats.WordProcessingFormats.All)
{
    Console.WriteLine("Name is {0}, extension is {1}", oneFormat.Name, oneFormat.Extension);
}
//Parsing from extension
Formats.WordProcessingFormats expectedDocm = WordProcessingFormats.FromExtension(".docm");
```

## More resources
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