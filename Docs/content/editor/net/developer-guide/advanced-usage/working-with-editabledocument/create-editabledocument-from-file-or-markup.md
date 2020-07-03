---
id: create-editabledocument-from-file-or-markup
url: editor/net/create-editabledocument-from-file-or-markup
title: Create EditableDocument from file or markup
weight: 4
description: "This article explains how to create instance of the EditableDocument class from HTML files from disk or from HTML markup with resources using GroupDocs.Editor for .NET API."
keywords: Edit HTML document, GroupDocs.Editor
productName: GroupDocs.Editor for .NET
hideChildren: False
---
> This demonstration shows how to create instance of the EditableDocument class from HTML files from disk or from HTML markup with resources

#### Introduction

When working with [**GroupDocs.Editor**](https://products.groupdocs.com/editor/net) in usual way by loading, opening, editing and saving documents, the instances of [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) class are produced by the [Editor.Edit](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/edit/index) method and accepted by the [Editor.Save](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/save/index) method. However, in some cases it is required to create a [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance from existing HTML markup with optional resources. For example, some document was loaded to `Editor` class, opened for editing, and then [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) was saved to the disk as a set of HTML file and connected resources. Then this HTML document was passed to the WYSIWYG-editor, edited, and save back to the disk as modified HTML. Or raw output from the WYSIWYG-editor was saved to the `string` variable. In order to save it to some final format like DOCX or XLSX, user needs to pass the document to the [Editor.Save](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/save/index) method in a form of [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance. This means that user should create an instance of [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) class manually.

[EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) contains three public static methods for creating its instances: [FromFile](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/fromfile), [FromMarkup](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/frommarkup) and [FromBodyMarkupAndResourceFolder](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/frombodymarkupandresourcefolder). This article reviews all of them.

#### Opening from file

Let's suppose that we have an HTML file with edited document content, that is saved on the disk. There is also a folder with resources (images, fonts, stylesheets), that are used by this document, and document has correct links to this resources. Let's say, HTML document has name "document.html" and is located in the "input" folder. Resource folder is located in the same "input" folder and has name "document\_resources". And, what is most important, HTML markup from "document.html" has proper links to files from "document\_resources" folder. For example, there will be

<link rel = "stylesheet" type = "text/css" href = "document\_resources/style.css" />

in the "document.html", and "document\_resources" folder actually contains "style.css" file.

In that case creating the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance is the most simple:

```csharp
string inputHtmlPath = "C://input/document.html";
EditableDocument document = EditableDocument.FromFile(inputHtmlPath, null);
```

The [FromFile](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/fromfile) method accepts two parameters, where first is a path to HTML file, while second is a path to resource folder. If HTML file contains correct links, as it is described above, second parameter is not necessary: GroupDocs.Editor will scan the links and automatically find the resource folder and correct resources. However, if path to resource folder doesn't match to the links in HTML file, it is possible to specify a resource folder forcibly, what is illustrated in code below:

```csharp
string inputHtmlPath = "C://input/document.html";
string inputResourceFolderPath = "C://input/document_resources/";
EditableDocument document = EditableDocument.FromFile(inputHtmlPath, inputResourceFolderPath);
```

If HTML file contains a link to same resource, that is not present in the resource folder, it will be omitted.

#### Opening from markup

In some cases edited HTML document is not present as a file. It may be stored in database, obtained from remote storage, or something else. In such cases [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) class delivers a [FromMarkup](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/frommarkup) method. This method, like previous, has two parameters:

*   `string newHtmlContent` — string, that contains raw HTML markup. This parameter is mandatory.
*   IEnumerable<[IHtmlResource](https://apireference.groupdocs.com/net/editor/groupdocs.editor.htmlcss.resources/ihtmlresource)> resources — this is a set of prepared resources (images, fonts, stylesheets), that are used or may be used in the HTML document. User needs to prepare this collection by himself. This parameter is optional, user may pass NULL or empty collection. As with previous method, if HTML markup refers to some resource, that is not found in "resources" collection, that it will be skipped (omitted).

The code example below demonstrates this approach.

```csharp
string inputHtmlMarkup = "<HTML><HEAD><TITLE>Edited document</TITLE>.....";
JpegImage image1 = new JpegImage("image1.jpg", /* stream or base64 text*/);
PngImage image2 = new PngImage("image2.png", /* stream or base64 text*/);
CssText stylesheet = new CssText("stylesheet.css", "p {color: black; text-align: left; }......", System.Text.Encoding.UTF8);

List<IHtmlResource> allResources = new List<IHtmlResource>();
allResources.Add(image1);
allResources.Add(image2);
allResources.Add(stylesheet);

EditableDocument document = EditableDocument.FromMarkup(inputHtmlMarkup, allResources);
```

#### Opening from inner-BODY HTML content and folder with resources

All previously described methods of creating instances of [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) class assume that both HTML file or string with HTML markup contains a valid, well-formed HTML document in all according to all W3C requirements. Such document should contain an HTML Document Definition (DOCTYPE) and a root HTML element, that, in turn, has two and only two children: HEAD (with document meta-information) and a BODY (with document content). All stylesheets are included and/or embedded in the HEAD element (LINK and/or STYLE elements respectively), and are 'used by' content markup (by using 'class' and 'id' attributes, in most cases).

However, most of client-side WYSIWYG HTML-editors like TinyMCE and CKEditor are working only with inner content of BODY element: they can obtain only such markup on input and produce such markup on output. External stylesheet(s) are usually included in the HTML-editor settings or somewhere else, but not through HTML-markup (excepting the inline styles in the "style" attribute). For passing a HTML->BODY markup *into* the HTML-editor there is a [GetBodyContent()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/getbodycontent) method, that returns an inner content of HTML-BODY element. And, in counterpart, for obtaining a HTML markup *from* HTML-editor and creating a new [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance with this markup the new method was introduced in the 19.12 version: [FromBodyMarkupAndResourceFolder()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/frombodymarkupandresourcefolder). Like [FromFile](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/fromfile) and [FromMarkup](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/frommarkup), this is also a static method, that serves as a factory for creating the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instances. It obtains two mandatory parameters:

*   `string htmlBodyContent `— string, that contains raw HTML markup, that is located inside BODY element (between <BODY> and </BODY> tags, without this pair of opening/closing tags itself). Of course, this should be a valid markup.
*   `string resourceFolderPath` — string, that contains a full path to the folder with all external resources for the opening document. If the folder doesn't exist, an exception will be thrown.

Because inner-BODY markup doesn't contain stylesheets (neither included not embedded), these stylesheets should be referenced by some another way. For obtaining them a second parameter exists; user should specify a full path to the folder, that contains an images, fonts and stylesheets, used by the HTML document, specified in the 1st parameter. GroupDocs.Editor scans this folder, founds \*.css files, opens them, parses their content, and if this content is valid, applies these stylesheets for the document. If stylesheet references on external images and/or fonts, GroupDocs.Editor will try to find these resources in this resource folder too. Also, if HTML markup, specified in the 1st parameter, contains external images, referenced using an IMG element, GroupDocs.Editor will try to find these images in this resource folder too. In other words, the [FromBodyMarkupAndResourceFolder()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/frombodymarkupandresourcefolder) method "assumes" that contains resources for that specific HTML document, which inner-BODY content was specified in the 1st parameter.

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