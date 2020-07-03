---
id: enabling-language-information
url: editor/net/enabling-language-information
title: Enabling language information
weight: 3
description: "Following this guide you will learn how to edit Word document using locale info, apply spell-checkers to a document content written in different languages using GroupDocs.Editor for .NET API."
keywords: Edit Word document with language. Edit Word document with locale
productName: GroupDocs.Editor for .NET
hideChildren: False
---
Documents of all WordProcessing formats can contain text in different languages. But, unlike the plain text documents (TXT), WordProcessing documents also contain a metadata about specific language (locale) of every piece of text. [**GroupDocs.Editor**](https://products.groupdocs.com/editor/net) allows to extract and export this language information. For achieving this the [WordProcessingEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions) class contains the [`EnableLanguageInformation`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions/properties/enablelanguageinformation) public boolean property:

```csharp
public bool EnableLanguageInformation {get; set;}
```

By default its value is `false`, which means that language metadata will not be extracted. But when this option is manually enabled, GroupDocs.Editor extracts locale info for every piece of textual content and preserves it in the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance, when document is edited. Finally, when user have obtained the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance and is generating the HTML markup for transferring it to the WYSIWYG HTML-editor in order to make document editable in the browser, this language information is represented as the 'lang' HTML attributes with appropriate values inside the SPAN HTML elements.

Enabling language information is useful when document contains different text parts in different languages; if document has text in some single language, this option has no many sense and thus is disabled by default.

However, when document is multi-language, enabling language information may be very suitable for two scenarios:

*   It eases spell checking for client-base JavaScript spell-checkers, that are working in the browser. However, this is very dependent on specific spell-checker, as not all spell-checkers are able to grab values from "lang" attributes or even use language information at all.
*   It improves the quality of output WordProcessing document in roundtrip scenarios. When document with enabled [`EnableLanguageInformation`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions/properties/enablelanguageinformation) option was converted to the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance, then HTML markup was generated, edited in the some HTML-editor, and then new instance of [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) class was created from edited markup, language metadata in "lang" attributes is still preserved. When edited [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) will be converted back to the output document of some WordProcessing format like DOCX or RTF, the textual content inside it will have connections to correct locale.

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
