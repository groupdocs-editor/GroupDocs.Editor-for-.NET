---
id: font-embedding-options
url: editor/net/font-embedding-options
title: Font embedding options
weight: 6
description: "Learn this guide to know about embedding fonts into output Word document when editing with GroupDocs.Editor API."
keywords: Edit document with fonts, Font embedding
productName: GroupDocs.Editor for .NET
hideChildren: False
---
## Introduction

Starting from version 20.7 the GroupDocs.Editor for .NET is able, along with font extraction, ability to embed fonts into the output WordProcessing document. This feature can be treated as similar to Microsoft Word feature to embed fonts into the saved document after its editing.

In counterpart to the _font extraction_ mechanism with corresponding [`FontExtractionOptions`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/fontextractionoptions) class, which are responsible for extracting font resources from input WordProcessing document into intermediate [`EditableDocument`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument), the font embedding mechanism with corresponding class are responsible for transferring fonts from [`EditableDocument`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) into output WordProcessing document through embedding. When user obtains a document content, edited in the WYSIWYG-editor, and creates a new [`EditableDocument`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance with edited document content, he then needs to invoke an [`Editor`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor).[`Save()`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/save) method, that will generate an output WordProcessing document from specified [`EditableDocument`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) and [`WordProcessingSaveOptions`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions) class. The [`WordProcessingSaveOptions`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions) class is the point where font embedding, which is disabled by default, can be enabled and tuned.

When font embedding is enabled, the GroupDocs.Editor analyzes a document content of [`EditableDocument`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) and forms a list of all fonts, which are used in document body, for example, in paragraphs, labels and so on. After this GroupDocs.Editor tries to find all of these fonts in the font resources of input [`EditableDocument`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) (property [`EditableDocument.Fonts`](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editabledocument/properties/fonts)). If [`EditableDocument`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) contains all font resources, that are used in document body, they will be embedded into the output WordProcessing document. However, if there are some fonts, used in the document content, which have no corresponding font resources in [`EditableDocument`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument), then GroupDocs.Editor tries to find them in the OS (where GroupDocs.Editor is running), extract and embed into the output document.

There may be a situation, when during the document editing in WYSIWYG-editor end-user deleted some text, for example, a paragraph, with some specific font, and after the deletion this font is no longer used, while corresponding font resource is still leaving in the [`EditableDocument`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument). During font embedding such dangling font resources are detected and ignored, so they will not be passed into the output document.

When working with fonts, the GroupDocs.Editor must work with so-called _system fonts_. System fonts are the fonts, which are the most vital for the operation system; for example, they are using in Windows Explorer, Console, system built-in applications of the operation system. When performing font embedding, user can define whether to embed the system fonts into the output document or not. Including system fonts may be useful if the user is on an East Asian system and wants to create a document that is readable by others who do not have fonts for that language on their system. For example, a user on a Japanese system could choose to embed the fonts in a document so that the Japanese document would be readable on all systems.

## Usage

In order to support fonts embedding, starting from the version 20.7, the [`WordProcessingSaveOptions`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions) class now contains a new property `FontEmbedding`. This property is of type `FontEmbeddingOptions` — it is enum with three possible values. By default, when creating a new instance of [`WordProcessingSaveOptions`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions) class, the value of `FontEmbedding` property is set to `NotEmbed`, — in this case GroupDocs.Editor do not embed fonts at all and thus acts like previous versions, so the existing client code will not be broken after updating from older versions to 20.7.

`FontEmbeddingOptions` enum contains two values for embedding fonts, which are almost the same, but with one slight difference:
* `EmbedAll`. As it is described above, when this option is chosen, the GroupDocs.Editor analyzes the document content for used fonts, and then looking for these fonts in EditableDocument and, if required, in operating system.This option resembles the "Embed fonts in the file" option with all sub-options turned off in Microsoft Word 2007 and higher.
* `EmbedWithoutSystem`. This option is almost the same as previous one, but with one little distinction: it does not embed system fonts. This option resembles the "Embed fonts in the file" option with enabled "Do not embed common system fonts" sub-option in Microsoft Word 2007 and higher.

In the example below all these options are shown:

```csharp
Options.WordProcessingSaveOptions saveOptions = new WordProcessingSaveOptions(Formats.WordProcessingFormats.Docx);
             
//By default fonts are not embedded
Assert.AreEqual(Options.FontEmbeddingOptions.NotEmbed, saveOptions.FontEmbedding);
 
//Embed all used fonts, including system fonts
saveOptions.FontEmbedding = Options.FontEmbeddingOptions.EmbedAll;
 
//Embed all used fonts, but except system fonts
saveOptions.FontEmbedding = Options.FontEmbeddingOptions.EmbedWithoutSystem;
```
