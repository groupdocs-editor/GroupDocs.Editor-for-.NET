---
id: save-html-to-folder
url: editor/net/save-html-to-folder
title: Save HTML to folder
weight: 2
description: "This article explains how to save edited document in HTML form to folder at local disk using GroupDocs.Editor for .NET features."
keywords: Save edited HTML, Save edited document, Save HTML to folder
productName: GroupDocs.Editor for .NET
hideChildren: False
---
> This demonstration shows how to open input document, convert it to intermediate [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument), and save to disk as HTML file with resource folder.

Almost all HTML WYSIWYG client-side editors are able to open HTML document from disk (from path). [**GroupDocs.Editor**](https://products.groupdocs.com/editor/net) allows to open any supportable document, convert it to HTML and save to disk, which may be very useful for the subsequent editing it in some WYSIWYG editor. The code below demonstrates such example.

```csharp
string inputFilePath = "C:\\input_path\\document.docx"; //path to some document
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
Editor editor = new Editor(inputFilePath, delegate { return loadOptions; }); //passing path and load options (via delegate) to the constructor
EditableDocument document = editor.Edit(new WordProcessingEditOptions());
string outputHtmlFilePath = "C:\\output_path\\document.html"; //path to output HTML document
document.Save(outputHtmlFilePath);
```

In this example we load input WordProcessing (DOCX) document to Editor class with load options, specific for this document family type - [WordProcessingLoadOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingloadoptions). Load options are passed via delegate. Then document is converted to the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) using the [Edit()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/edit) method, which, in turn, obtains document-specific [WordProcessingEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions). In the last line content is saved to the HTML file on disk, that is specified by absolute path. Please note that GroupDocs.Editor will create accompanying folder with resources automatically in the same directory, where HTML file is saved. There is another overload of the [Save()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/save) method, that obtains 2 parameters: path to HTML file and path to existing folder, where resources should be saved. For example, last 2 lines can be rewritten in the next way:

```csharp
string outputHtmlFilePath = "C:\\output_path\\document.html"; //path to output HTML document
string outputHtmlFolderPath = "C:\\output_path\\document_files\\";//path to folder, where resources will be saved
document.Save(outputHtmlFilePath, outputHtmlFolderPath);
```

By the way, don't forget to dispose all resources, if you're not using a `using` directive.

```csharp
document.Dispose();
editor.Dispose();
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