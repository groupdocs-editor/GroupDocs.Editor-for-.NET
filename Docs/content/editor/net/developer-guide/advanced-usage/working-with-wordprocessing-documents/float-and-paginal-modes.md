---
id: float-and-paginal-modes
url: editor/net/float-and-paginal-modes
title: Float and paginal modes
weight: 4
description: "This article explains pros and cons of float and paginal document editing modes when edit Word documents with GroupDocs.Editor API."
keywords: Edit Word document in float mode, Edit Word document page by page
productName: GroupDocs.Editor for .NET
hideChildren: False
---
WordProcessing module of [**GroupDocs.Editor**](https://products.groupdocs.com/editor/net), that is responsible for converting all WordProcessing formats to [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instances and backward (from [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) to some of WordProcessing format), contains two modes: *float* and *paginal* (also known as *paged*), where first one — float, is default. These modes are presented by two properties with the same name and type:

```csharp
public bool EnablePagination {get; set;}
```

At first, such property is present in the [WordProcessingEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions) class and is doubled in the [overload of class constructor](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions/constructors/1), which obtains one boolean parameter of the same name. In this case this option is responsible for selected mode during forward (WordProcessing to [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument)) conversion.

Secondly, such property is present in the [WordProcessingSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions) class and is responsible for selected mode during backward ([EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) to WordProcessing) conversion.

Main "rule of thumb" for the end-user is to preserve the same mode during full document roundtrip and do not change it. In other words, if input document was converted to the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) (followed by the HTML emitting from [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance) in the *float* mode, then the resultant [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance (obtained from document, edited on client-side) should be converted back to the WordProcessing format also in the *float* mode (same rule for *paginal* mode too).

Main distinguish of these two modes lies in the form of representation of the input WordProcessing document. By default all WordProcessing formats internally have no pages and page division, they are internally represented as a float smoothness and pageless structure. However, they contain page-related information like headers, footers, page watermarks, page numbering formatting info etc. And when WordProcessing document is opened in some of desktop or browser-based text processor like MS Word, OpenOffice or Google Docs, this text processor dynamically and "on the fly" splits the document onto multiple pages, which are re-calculated every time when user is performing some edits in document content. For example, when user removes the line from the beginning of the huge document, the empty space is "collapsing", and all subsequent content is like "moving upward' to fill the gap, where removed line was located. Same real-time calculations are valid also for situations when content is added, — new inserted content is pushing the existing content to move downward, with creating new pages if necessary.

The problem is the most of used client-side browser-based JavaScript HTML WYSIWYG editors like TinyMCE or CKEditor do not support pages, page separation and described calculations at all. They support only documents with pageless structure. That's why GroupDocs.Editor support two modes:

*   In the *float* mode the WordProcessing document in represented in pageless form. Content is not separated on pages, There are no any page-related entities like headers, footers, watermarks and page numbers. This mode is the most suitable for almost all widespread WYSIWYG HTML-editors and that's why this mode is default.
*   In the *paginal* mode the WordProcessing document in represented as a set of pages, where content is divided onto pages in the same way as MS Word does. Al page-related entities like headers, footers, watermarks and page numbers are present. This mode should be turned on manually (as it is described above) and is fitting for scenarios where end-user is able to process such content in some appropriate and suitable way, for example, in his own-made HTML editing software.

### Paginal mode in PDF

Along with family of WordProcessing formats, GroupDocs.Editor support a PDF as one of output (resultant) formats. In other words, input WordProcessing may be opened, edited, but saved not only to the WordProcessing, but also to the PDF. Prior GroupDocs.Editor version 20.3 the *paginal* mode was accessed only for forward and backward WordProcessing conversions, and was not available for PDF. This means that there was no possibility to generate an output PDF in *paged* mode, regardless of [EnablePagination](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/wordprocessingeditoptions/properties/enablepagination) flag in the [WordProcessingEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions) class. In other words, even if input WordProcessing document was converted to [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) in *paginal* mode, the output PDF will be generated in *float* mode.

Starting from GroupDocs.Editor version 20.4 these two conversion mode were added into the PDF processor. Now [PdfSaveOptions](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/pdfsaveoptions) class contains the same property — [EnablePagination](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/pdfsaveoptions/properties/enablepagination) boolean flag, which, like the same in WordProcessing, has `false` default value, which means *float* mode, when `true` value means *paginal* mode. If input WordProcessing document was converted to [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) in *paginal* mode, the output PDF should be generated in *paginal* mode too, with enabled [EnablePagination](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/pdfsaveoptions/properties/enablepagination) flag.

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