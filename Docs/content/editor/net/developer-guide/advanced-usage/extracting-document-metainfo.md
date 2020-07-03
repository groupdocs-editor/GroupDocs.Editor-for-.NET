---
id: extracting-document-metainfo
url: editor/net/extracting-document-metainfo
title: Extracting document metainfo
weight: 6
description: "Following this guide you will learn how to obtain basic document metadata like pages count, size, file type before editing it with GroupDocs.Editor for .NET API."
keywords: Extract document metadata, Get document info
productName: GroupDocs.Editor for .NET
hideChildren: False
---
> This demonstration shows and explains usage of the [GetDocumentInfo](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/getdocumentinfo) method, that extracts meta info from the document.

#### Introduction

In some situations it is required to grab meta info from the document before actually editing it. For example, user wants to edit last tab of the multi-tabbed spreadsheet, but he doesn't know, how many tabs the document contains. Ir it is unclear for the user, is the document password-protected or not. For such situations [**GroupDocs.Editor**](https://products.groupdocs.com/editor/net) provides a [GetDocumentInfo](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/getdocumentinfo) method, that returns detailed meta info (metadata) about the specified document.

#### Using the method

In order to grab the meta info from the document, it should firstly be loaded into the `Editor` class. Then [GetDocumentInfo](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/getdocumentinfo)() should be called. This method obtains one parameter — password as a string. If document is encoded and user knows the password, he can specify it here. For other cases the null or empty string can be passed. Code example below demonstrates the usage:

```csharp
Editor editor = new Editor("C://input/document.docx");
IDocumentInfo infoDocxWithoutPassword = editorDocx.GetDocumentInfo(null);
IDocumentInfo infoDocxWithPassword = editorDocx.GetDocumentInfo("password"); 
```

There can be several scenarios here regarding whether document is encoded or not, and did user specified a password:

1.  If password is specified, but document is not password-protected, or the document format doesn't support encoding at all, the password will be ignored.
2.  If document is password-protected, but password is not specified, the [PasswordRequiredException](https://apireference.groupdocs.com/net/editor/groupdocs.editor/passwordrequiredexception) will be thrown while calling [GetDocumentInfo](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/getdocumentinfo)().
3.  If document is password-protected,and password is specified, but is incorrect, the [IncorrectPasswordException](https://apireference.groupdocs.com/net/editor/groupdocs.editor/incorrectpasswordexception) will be thrown while calling [GetDocumentInfo()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/getdocumentinfo).

#### Explaining resulting type

[GetDocumentInfo](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/getdocumentinfo)() method returns a [IDocumentInfo](https://apireference.groupdocs.com/net/editor/groupdocs.editor.metadata/idocumentinfo). This is interface, that stores meta info about one particular document and contains the next properties:

1.  [PageCount](https://apireference.groupdocs.com/net/editor/groupdocs.editor.metadata/idocumentinfo/properties/pagecount). This is a positive number, that returns page count for WordProcessing documents, tabs (worksheets) count for Spreadsheets, and 1 for pageless documents like XML or TXT.
2.  [Size](https://apireference.groupdocs.com/net/editor/groupdocs.editor.metadata/idocumentinfo/properties/size). Document size in bytes.
3.  [IsEncrypted](https://apireference.groupdocs.com/net/editor/groupdocs.editor.metadata/idocumentinfo/properties/isencrypted). A boolean flag that indicates whether document is encrypted with the password or not. If document is of type, that doesn't support encryption at all, like CSV or XML, this property will return 'false'.
4.  [Format](https://apireference.groupdocs.com/net/editor/groupdocs.editor.metadata/idocumentinfo/properties/format). Returns info about the format itself.

There are three inheritors of the [IDocumentInfo](https://apireference.groupdocs.com/net/editor/groupdocs.editor.metadata/idocumentinfo) interface:

1.  [WordProcessingDocumentInfo](https://apireference.groupdocs.com/net/editor/groupdocs.editor.metadata/wordprocessingdocumentinfo) — common for all WordProcessing family formats.
2.  [SpreadsheetDocumentInfo](https://apireference.groupdocs.com/net/editor/groupdocs.editor.metadata/spreadsheetdocumentinfo) — common for all Spreadsheet family formats.
3.  [PresentationDocumentInfo](https://apireference.groupdocs.com/net/editor/groupdocs.editor.metadata/presentationdocumentinfo) — common for all Presentation family formats.
4.  [TextualDocumentInfo](https://apireference.groupdocs.com/net/editor/groupdocs.editor.metadata/textualdocumentinfo) — common for all textual types, including all DSV (like CSV and TSV), XML, HTML, and plain text.

One important thing to note: if [GetDocumentInfo()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/getdocumentinfo) returns NULL value instead of some of [IDocumentInfo](https://apireference.groupdocs.com/net/editor/groupdocs.editor.metadata/idocumentinfo) inheritors, this means that specified document is not supported by the GroupDocs.Editor and thus cannot be opened for editing or saved.

#### Explaining document format

[IDocumentInfo](https://apireference.groupdocs.com/net/editor/groupdocs.editor.metadata/idocumentinfo) interface contains a `Format` property of [IDocumentFormat](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/idocumentformat) type. [IDocumentFormat](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/idocumentformat) is an interface, that is common for all format descriptors. It is designed for indicating one particular document format and stores format name, extension, and has equality operators. It has three inheritors, all of them are structs:

1.  [WordProcessingFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/wordprocessingformats) — holds all formats from WordProcessing family.
2.  [SpreadsheetFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/spreadsheetformats) — holds all formats from Spreadsheet family.
3.  [PresentationFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/spreadsheetformats) — holds all formats from Presentation family.
4.  [TextualFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/textualformats) — holds all formats with text-based nature.

Each inheritor of [IDocumentFormat](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/idocumentformat) interface delivers two properties: [Name](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/idocumentformat/properties/name), that provides name of the format, and [Extension](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/idocumentformat/properties/extension), that provides a format extension.

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