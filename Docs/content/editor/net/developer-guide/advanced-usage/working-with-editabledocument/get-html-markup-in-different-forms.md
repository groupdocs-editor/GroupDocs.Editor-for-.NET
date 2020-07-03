---
id: get-html-markup-in-different-forms
url: editor/net/get-html-markup-in-different-forms
title: Get HTML markup in different forms
weight: 1
description: "Learn this article to know how to get edited document HTML markup - body without head tag, content in a raw and base64 form and other using GroupDocs.Editor for .NET API."
keywords: Get html content, get html body, get html markup
productName: GroupDocs.Editor for .NET
hideChildren: False
---
> This demonstration shows how to open input document, convert it to intermediate [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument), and get HTML markup in different forms depending on client requirements.

#### Preparations

When input document is loaded into [Editor](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor) class and opened for edit by transforming to the intermediate [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) class, it is possible to generate and get HTML markup in different forms. Code below shows all variations of such procedure.

First of all user needs to load document into [Editor](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor) class and open it for editing, what is demonstrated in the code below.

```csharp
string inputFilePath = "C:\\input_path\\document.docx"; //path to some document
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
Editor editor = new Editor(inputFilePath, delegate { return loadOptions; }); //passing path and load options (via delegate) to the constructor
EditableDocument document = editor.Edit(new WordProcessingEditOptions()); //opening document for editing with format-specific edit options

```

Piece of code above has prepared a ready-to-use instance of [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) class, that contains the original document in its own intermediate format and is able to generate HTML markup in different forms.

#### Getting whole HTML content

The most default and standard method for generating HTML markup is parameterless [GetContent](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/getcontent) method:

```csharp
string htmlContent = document.GetContent();

```

If document has external resources (stylesheets, fonts, images), they are referenced via different HTML elements: stylesheets are specified through LINK elements, while images — through IMG. When using the [GetContent()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/getcontent) method, such external resources will be referenced by external links. For example:

```csharp
<link href="stylesheet.css" rel="stylesheet"/>
<IMG src="image.png"/"> 
```

Quite often on the web-server, where such HTML will be edited, resources are processed by specific HTTP handler. In such cases it is required to adjust paths to such endpoints. More advanced overload of the [GetContent()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/getcontent) method can help:

```csharp
string externalImagesPrefix = "http://www.mywebsite.com/images/id=";
string externalCssPrefix = "http://www.mywebsite.com/css/id=";
string prefixedHtmlContent = document.GetContent(externalImagesPrefix, externalCssPrefix);
```

In the example above specified prefixes will be added to every external link in the document's markup. For example, with the code above link will be the next:

```csharp
<link href="http://www.mywebsite.com/css/id=stylesheet.css" rel="stylesheet"/>
<IMG src="http://www.mywebsite.com/css/id=image.png"/"> 
```

#### Getting HTML BODY content

Lot of HTML WYSIWYG editors are not able to process the whole HTML document, with HEAD section and so on. They are able only to process inner content of HTML->BODY element. In order to obtain such part of HTML markup, [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) class contains the [GetBodyContent()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument/methods/getcontent) method, which, as previous one, has two overloads, that are provided below:

```csharp
string bodyContent = document.GetBodyContent();
string externalImagesPrefix = "http://www.mywebsite.com/images/id=";
string prefixedBodyContent = document.GetBodyContent(externalImagesPrefix); 
```

First parameterless overload, like previous one, leaves links to the external images intact. Second, that obtains external resource prefix, adds this prefix to every url in the 'src' attribute of every IMG tag, that is found inside HTML->BODY markup.

#### Getting base64-encoded content

Sometimes it is necessary to obtain all content of all document with all used resources into one single string.GroupDocs.Editor allows to do this:

```csharp
string embeddedHtmlContent = document.GetEmbeddedHtml();
```

In such string all stylesheets will be placed into the STYLE elements in the HTML->HEAD section, all images in IMG elements will be serialized with base64 encoding and placed directly in the 'src' attributes. All fonts and images, which are used in stylesheets, will also be serialized and stored in appropriate locations in the corresponding stylesheet. Such string will be fully autonomous and self-sufficient.

#### Conclusion

This guide has explained different ways of obtaining HTML markup from a document in different forms.

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