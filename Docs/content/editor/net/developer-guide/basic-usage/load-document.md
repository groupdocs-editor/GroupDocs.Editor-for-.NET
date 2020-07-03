---
id: load-document
url: editor/net/load-document
title: Load document
weight: 2
description: "Following this guide you will learn how to load document from local disk or file stream for editing with GroupDocs.Editor for .NET API."
keywords: Load document with GroupDocs.Editor, Load and edit document, edit document, edit spreadsheet, edit presentation
productName: GroupDocs.Editor for .NET
hideChildren: False
---
> This article describes how to load input document to the [**GroupDocs.Editor**](https://products.groupdocs.com/editor/net) and how to apply load options.

First of all the input document, which should be accessible as a byte stream or through valid file path, should be loaded into the GroupDocs.Editor by creating an instance of the [Editor](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor) class through one of the constructor overloads.   
If the input document is presented as a stream, it should be loaded through delegate. Source code below shows two ways of loading documents: from path and from stream.

```csharp
//through path
string inputFilePath = "C:\\input_path\\document.docx"; //path to some document
Editor editor = new Editor(inputFilePath);

//through stream
FileStream inputStream = System.IO.File.OpenRead(inputFilePath);
Editor editor = new Editor(delegate { return inputStream; });
```

When two overloads from example above are used, GroupDocs.Editor automatically detects the format of input document and applies the most appropriate default loading options for the input document.   
However, it is possible and even recommended to specify correct loading options explicitly using constructor overloads, which accept two parameters. Like streams, loading options should be specified through delegates.   
Source code below shows using such options.

```csharp
//through path
string inputFilePath = "C:\\input_path\\document.docx"; //path to some document
WordProcessingLoadOptions wordLoadOptions = new WordProcessingLoadOptions();
Editor editor = new Editor(inputFilePath, delegate { return wordLoadOptions; }); //passing path and load options (via delegate) to the constructor

//through stream
MemoryStream inputStream = new MemoryStream();//obtained from somewhere
SpreadsheetLoadOptions spreadsheetLoadOptions = new SpreadsheetLoadOptions();
Editor editor = new Editor(delegate { return inputStream; }, delegate { return spreadsheetLoadOptions; });
```

Please note that not all document formats have appropriate classes, that represent load options. As for version 19.10, only WordProcessing, Spreadsheet and Presentation family formats have load options. For other document types, such as DSV, TXT or XML, there are no load options.

| Format family | Example formats | Load options class |
| --- | --- | --- |
| WordProcessing | DOC, DOCX, DOCM, DOT, ODT | `WordProcessingLoadOptions` |
| Spreadsheet | XLS, XLSX, XLSM, XLSB | `SpreadsheetLoadOptions` |
| Presentation | PPT, PPTX, PPS, POT | `PresentationLoadOptions` |

Using load options is the only way for working with password-protected input documents. Any document can be loaded into the `Editor` instance, even encoded document without the password. However, on the next step — opening for editing, — the exception will be thrown. GroupDocs.Editor handles passwords and encoded documents in the next way:

1.  If document is not encoded, password is ignored anyway, whether or not it was specified.
2.  If document is password-protected, but password is not specified, the [PasswordRequiredException](https://apireference.groupdocs.com/net/editor/groupdocs.editor/passwordrequiredexception) will be thrown later during editing.
3.  If document is password-protected, and password is specified, but is incorrect, the [IncorrectPasswordException](https://apireference.groupdocs.com/net/editor/groupdocs.editor/incorrectpasswordexception) will be thrown later during editing.

Example below shows specifying password for opening some password-protected WordProcessing document.

```csharp
Stream inputStream = GetDocumentStreamFromSomewhere();
WordProcessingLoadOptions wordLoadOptions = new WordProcessingLoadOptions();
wordLoadOptions.Password = "correct_password";
Editor editor = new Editor(inputFilePath, delegate { return wordLoadOptions; });
```

{{< alert style="info" >}}Same approach is applicable for Spreadsheet and Presentation documents too.{{< /alert >}}

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

