---
id: font-extraction-options
url: editor/net/font-extraction-options
title: Font extraction options
weight: 5
description: "Learn this guide to know about extracting fonts from input Word document when editing with GroupDocs.Editor API."
keywords: Edit document with fonts, Font extraction
productName: GroupDocs.Editor for .NET
hideChildren: False
---
### Introduction

WordProcessing documents contain usually text content, while every piece of text should be represented with some font. There may be used system fonts (installed in the operating system), but also custom fonts, which are not installed in the system. On the other hand, lots of WordProcessing formats like DOCX and ODT have an ability to store fonts inside the document itself; such fonts, stored as the binary resources inside WordProcessing files, are called *embedded*. Embedded fonts are the only choice for the end-user to use some specific fonts, which are not installed in the system. But any font can be embedded into the document. This means, that, for example, there can be a situation, when the same font is installed in the system, and at the same time embedded in the WordProcessing document.

In the MS Windows operating system before Windows 10 (and MS Windows Server 2016) there is only one location, where fonts, installed in the system, are stored: system folder "`%windir%\fonts`", fonts from which are available for all users. However, starting from MS Windows 10 every user has its own local fonts storage: "`%userprofile%\AppData\Local\Microsoft\Windows\Fonts`" (along with common folder, which still exists, of course).

When we're saying "the WordProcessing document uses some font", this statement can be treated differently, because WordProcessing document can use fonts differently. From the "broad" point of view, every font, which is referenced in the WordProcessing somehow, applied to text content or is a part of some style, is used by the document. In counterpart, from "narrow" point of view, only those font, which is applied to some text content, is used by the document. For example, there can be a scenario when user created a WordProcessing  document, writes some text, creates some style named "*Style1*" with specific font "*Font1*", and applies this style "*Style1*" to the text. In this situation those specific "*Font1*" is used by the document from all point of views. However, after this, user edits the document, and removes all the textual content, which uses "*Style1*" style, but, what is important, the "*Style1*" is not removed from the document, — it still exists and holds a reference to the "*Font1*". In this situation, from narrow point of view, document don't use "*Font1*", because there is no any piece of text, which uses this font, even while "*Font1*" is still a part of "*Style1*" style, which is a part of a document.

### Usage

GroupDocs.Editor has an ability to extract fonts from WordProcessing document and represent them as resources in the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance; when this instance will be used for generating HTML markup, all font resources will be present and correctly linked to the HTML content. GroupDocs.Editor is able to extract embedded fonts from the WordProcessing document, as well as extract installed fonts from system. Prior version 20.3 it was possible to extract system fonts only from the system folder, common for all users. Now, starting from the version 20.3, GroupDocs.Editor for .NET supports fonts, installed into the user folder, too.

There are two public properties, responsible for working with fonts, all of them are located in the [WordProcessingEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions) class:

```csharp
public FontExtractionOptions FontExtraction {get; set;}

public bool ExtractOnlyUsedFont { get; set; }
```

[FontExtractionOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/fontextractionoptions) is a public enum, located in the [GroupDocs.Editor.Options](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/) namespace. By default, when an instance of the [WordProcessingEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions) class is created, this enum has a default value `NotExtract`, which means do not extract any fonts: neither from document nor from the system. Other values are the next:

*   `ExtractAllEmbedded`. In this case the GroupDocs.Editor extracts all the fonts, embedded in the input WordProcessing document regardless of the fact, are some of them installed in the system or not. In other words, converter finds and extracts all 100% font resources, which are embedded into the input WordProcessing document, but it doesn't determine whether they are system or custom. Because of this fact the converter doesn't touch Windows Registry or system folders at all.
*   `ExtractEmbeddedWithoutSystem`. Unlike the previous option, in this case GroupDocs.Editor not only simply extracts all embedded fonts, but also checks every font whether it is system or not. If some embedded font is system-installed, it will be ignored and will not be present in the font resources inside the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument). In order to detect, which font is system or not, the converter tries to obtain a list of all system fonts by using Windows Registry and system folders, and then compares this list with a set of embedded fonts. As a result, only subset of those embedded fonts, which were not found in system, will be returned.
*   `ExtractAll`. When this option is selected, GroupDocs.Editor tries to extract absolutely all fonts, which are used in the input document, regardless of their nature: embedded or system. In order to do this, the GroupDocs.Editor is analyzing an input WordProcessing document and finds all fonts, which are used there (from "broad" point of view). If some of these used fonts are embedded in the document, GroupDocs.Editor extracts and uses them. If document contains no embedded fonts at all, or collection of embedded fonts is present, but doesn't cover all used fonts in the document, the GroupDocs.Editor tries to extract these font resources from system by using Windows Registry and system folders. This option is perfectly useful in case, when clients want to make sure, that the input document will have the perfect representation for every end-user regardless of what fonts are installed on the client machine or not.

Second property, a boolean flag named `ExtractOnlyUsedFont`, was added to the GroupDocs.Editor starting from the version 20.3. By default is has a '`false`' value, which means that all fonts, used in the WordProcessing document from the "broad" point of view, will be processed. This is the default behavior, the same, as GroupDocs.Editor did prior the version 20.3, when this option didn't exist. But when it is enabled by setting a '`true`' value, GroupDocs.Editor processes only those fonts, which are used in the WordProcessing document from the "narrow" point of view, i.e. only those fonts, which are applied to some textual content in the document.

These two public options work in conjunction. In particular:

*   If `FontExtraction` enum has a `NotExtract`value, then the value of `ExtractOnlyUsedFont` property will be ignored.
*   If `FontExtraction` enum has a `ExtractAllEmbedded` value,and `ExtractOnlyUsedFont` flag is set to '`true`', GroupDocs.Editor will not extract 100% of all embedded fonts, but only subset of those embedded, which are used in the WordProcessing document from the "narrow" point of view.
*   If `FontExtraction` enum has a `ExtractEmbeddedWithoutSystem` value,and `ExtractOnlyUsedFont` flag is set to '`true`', GroupDocs.Editor returns a subset of the fonts, which are returned by this option, when `ExtractOnlyUsedFont` flag is set to '`false`' — will be returned only those fonts, which are simultaneously embedded in the WordProcessing document, not installed in the system, and used in the document from the "narrow" point of view.
*   If `FontExtraction` enum has a `ExtractAll` value,and `ExtractOnlyUsedFont` flag is set to '`true`', GroupDocs.Editor first of all forms a list of fonts, which are used in the document from "narrow" point of view, and then only these fonts are returned from embedded or (if not found in embedded) from system-installed font storages.

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