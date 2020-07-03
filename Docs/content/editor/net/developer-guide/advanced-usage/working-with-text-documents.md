---
id: working-with-text-documents
url: editor/net/working-with-text-documents
title: Working with text documents
weight: 5
description: "This guide demonstrates how to edit plain text files with encoding, lists recognition, pagination and other powerful features of GroupDocs.Editor for .NET"
keywords: Edit TXT file, Edit plain text, Edit TXT programmatically
productName: GroupDocs.Editor for .NET
hideChildren: False
---
> This demonstration shows how to load, open for editing and save textual documents, explains edit and save options and their destination.

#### Introduction

Textual documents are simple Plain Text flat files (TXT), that contain no images, pages, paragraphs, lists, tables and so on. However, users can create some primitive formatting like lists with leading markers, left indents with whitespaces, tables with pseudo-graphics, paragraphs with line breaks, and so on. [**GroupDocs.Editor**](https://products.groupdocs.com/editor/net) can recognize some of these structures. Other non-obvious feature, that GroupDocs.Editor provide, is ability to save edited TXT document not only back to TXT, but also to WordProcessing.

#### Loading text documents

Unlike WordProcessing and Spreadsheet documents, DSV documents are loaded into the `Editor` class without any loading options. They are simple text files by their nature, so it is nothing to adjust:

```csharp
string inputTxtPath = "C://input/file.txt";
Editor editor = new Editor(inputTxtPath);
```

#### Editing text documents

In order to open a text document for edit by creating the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance it is required to use the [TextEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/texteditoptions) class. This class has several options (properties), that are described below:

1.  [Encoding](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/texteditoptions/properties/encoding) — allows to set character encoding of the input text document. By default, if not specified, is UTF8.
2.  [RecognizeLists](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/texteditoptions/properties/recognizelists) — boolean flag, that indicates how exactly numbered list items are recognized. If this option is set to false (default value), lists recognition algorithm detects list paragraphs, when list numbers ends with either dot, right bracket or bullet symbols (such as "•", "\*", "-" or "o"). If this option is set to true, whitespaces are also used as list number delimiters: list recognition algorithm for Arabic style numbering (1., 1.1.2.) uses both whitespaces and dot (".") symbols.
3.  [LeadingSpaces](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/texteditoptions/properties/leadingspaces) — enum flag, that indicates how consecutive leading spaces should be handled: convert to left indent (default value), preserve as consecutive spaces, or trim.
4.  [TrailingSpaces](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/texteditoptions/properties/trailingspaces) — enum flag, that indicates how consecutive trailing spaces should be handled: truncated (default value), or trim.
5.  [EnablePagination](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/texteditoptions/properties/enablepagination) — boolean flag, that allows to enable paged view of the document. In their nature all text documents are pageless, however, GroupDocs.Editor allows to split them on pages, like MS Word does.
6.  Direction — enum flag, which allows to specify the direction of text flow in the input plain text document. By default is Left-to-Right.

Source code below demonstrates using this option class and opening input text document for editing. Then, when [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocumenthttps://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance is ready, example below demonstrates, how to emit HTML markup from it, edit it and create new [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance from edited content:

```csharp
TextEditOptions editOptions = new TextEditOptions();
editOptions.Encoding = System.Text.Encoding.UTF8;
editOptions.RecognizeLists = true;
editOptions.LeadingSpaces = TextLeadingSpacesOptions.ConvertToIndent;
editOptions.TrailingSpaces = TextTrailingSpacesOptions.Trim;
editOptions.Direction = TextDirection.Auto;

EditableDocument beforeEdit = editor.Edit(editOptions); // Create EditableDocument instance

string originalTextContent = beforeEdit.GetContent(); // Get HTML content
string updatedTextContent = originalTextContent.Replace("text", "EDITED text"); // Edit content
List<IHtmlResource> allResources = beforeEdit.AllResources; // Get resources (only one stylesheet actually in this case)

//Finally, create new EditableDocument
EditableDocument afterEdit = EditableDocument.FromMarkup(updatedTextContent, allResources);
```

#### Saving text documents

After being edited, text document can be saved back as TXT or as WordProcessing. For saving back to TXT format user must use a [TextSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/textsaveoptions) class, that have three properties, described below:

1.  [Encoding](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/textsaveoptions/properties/encoding) — character encoding of the text document, which will be applied for its saving. By default, if not specified, is UTF8.
2.  [AddBidiMarks](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/textsaveoptions/properties/addbidimarks) — boolean flag, that determines whether to add bi-directional marks before each BiDi run when saving in plain text format.
3.  [PreserveTableLayout](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/textsaveoptions/properties/addbidimarks) — boolean flag, that specifies whether the GroupDocs.Editor should try to preserve layout of tables when saving in the plain text format. The default value is false.

Source code below shows how to save  [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) to both TXt and WordProcessing formats:

```csharp
TextSaveOptions txtSaveOptions = new TextSaveOptions();
txtSaveOptions.AddBidiMarks = true;
txtSaveOptions.PreserveTableLayout = true;

WordProcessingSaveOptions wordSaveOptions = new WordProcessingSaveOptions(WordProcessingFormats.Docm);

string outputTxtPath = "C:\output\document.txt";
string outputWordPath = "C:\output\document.docm";

editor.Save(afterEdit, outputTxtPath, txtSaveOptions);
editor.Save(afterEdit, outputWordPath, wordSaveOptions);
```

As a result, after running this example user will have two versions of the edited document: in TXT and DOCM formats.

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