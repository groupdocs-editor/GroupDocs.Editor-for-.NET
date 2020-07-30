---
id: locales-for-output-document
url: editor/net/locales-for-output-document
title: Locales for output document
weight: 8
description: "This guide demonstrates how to edit RTL documents and specify locale for Word documents when using  GroupDocs.Editor for .NET API."
keywords: Edit document with locale, GroupDocs.Editor, Edit RTL documents
productName: GroupDocs.Editor for .NET
hideChildren: False
---
[WordProcessingSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions) class contains 3 very similar properties of the same type `System.Globalization.CultureInfo`:

```csharp
public System.Globalization.CultureInfo Locale { get; set; }
public System.Globalization.CultureInfo LocaleBi { get; set; }
public System.Globalization.CultureInfo LocaleFarEast { get; set; }
```

In most cases the output WordProcessing document, which is generated from the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance by the [`editor.Save()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/save) method, contains valid locales for the textual content. But in some cases it is necessary to forcibly and explicitly set a some specific locale for the output document. These three options provide such possibility. However keep in mind that they are suitable only when document should have some single locale. If document is multi-language and contains, for example, English and Spanish text, setting the locale to English ("en-GB", for example) will mark the Spanish text as English too, so spell checking in MS Word, for example, will not work properly for such text.

By default all these three locale-related properties are not specified, their values are NULL. In such case MS Word (or other program) will detect (or choose) the document locale according to its own settings or other factors. Additionally, if document is multi-language, it is strongly encouraged to enable the [`EnableLanguageInformation`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions/properties/enablelanguageinformation) property in the [WordProcessingEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions) class while editing original document, and not to use these 3 properties.

The [`Locale`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions/properties/locale) property is intended to set the locale for usual left-to-right text, which consists of letters.  
The [`LocaleBi`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions/properties/localebi) property should be used when text is right-to-left (RTL), for example, [Arabic script](https://en.wikipedia.org/wiki/Arabic_script) or [Hebrew alphabet](https://en.wikipedia.org/wiki/Hebrew_alphabet).  
The [`LocaleFarEast`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions/properties/localefareast) property should be used for East-Asian (Far-East) text, including [CJK characters](https://en.wikipedia.org/wiki/CJK_characters).

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