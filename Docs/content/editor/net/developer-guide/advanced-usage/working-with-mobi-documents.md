---
id: working-with-mobi-documents
url: editor/net/working-with-mobi-documents
title: Working with Mobi documents
weight: 10
description: "This article demonstrates how to open and edit documents of Mobi format."
keywords: GroupDocs.Editor Mobi support, Mobi format, editing Mobi documents
productName: GroupDocs.Editor for .NET
hideChildren: False
---
## Introduction

Mobi format is an E-Book format, developed by the French company MobiPocket and is based on XML. EBooks in this format can contain text with rich formatting, images, and different annotations like bookmarks, notes, highlights, corrections and so on. Mobi books can have a DRM protection.

Starting from the version 20.7, the GroupDocs.Editor for .NET is able to open (load) Mobi documents for editing. However, on this moment saving _into_ Mobi is not available, so users should choose some other format (mostly some of WordProcessing) in order to save edited Mobi document.

## Loading Mobi documents

Despite of a distinct format, which doesn't belong to any of existing format families, Mobi has no dedicated loading options. So for loading it into the instance of the [`Editor`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor) class, users should simply specify a path to the Mobi file or a stream with its content in the constructor:

```csharp
string inputMobiPath = "C://input/book.mobi";
Editor editorFromPath = new Editor(inputMobiPath);
 
FileStream inputMobiStream = File.OpenRead("C://input/book.mobi");
Editor editorFromStream = new Editor(delegate() { return inputMobiStream; });
```

There is no loading options, because Mobi has nothing to tune-up during loading, — it cannot have a password protection, and can be processed only by one way.

## Editing Mobi documents

Like all formats and format families, Mobi format has its own edit options — a [`MobiEditOptions`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/mobieditoptions) class. This class may be described as a truncated version of a [`WordProcessingEditOptions`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions) class, because [`MobiEditOptions`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/mobieditoptions) contains a subset of options from [`WordProcessingEditOptions`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions) — [`EnablePagination`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/mobieditoptions/properties/enablepagination) and [`EnableLanguageInformation`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/mobieditoptions/properties/enablelanguageinformation) and, as in the [`WordProcessingEditOptions`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions), they are disabled (`false`) by default:

```csharp
public bool EnablePagination { get; set; }
 
public bool EnableLanguageInformation { get; set; }
```

They have exactly the same meaning as their "siblings" from [`WordProcessingEditOptions`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions). [`EnablePagination`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/mobieditoptions/properties/enablepagination) allows to switch between float and paginal mode in the resultant HTML document. [`EnableLanguageInformation`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/mobieditoptions/properties/enablelanguageinformation) allows to enable exporting language information in HTML. This is very useful for books, which have parts of text, written on different languages.

Example of usage is below (let's assume that [`Editor`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor) instance with loaded Mobi document is already created):

```csharp
Options.MobiEditOptions editOptions = new Options.MobiEditOptions();                
editOptions.EnablePagination = true;
editOptions.EnableLanguageInformation = true;
using (EditableDocument opened = editor.Edit(editOptions))
{
    //save it or pass to the WYSIWYG-editor
}
```

## Saving Mobi documents

As it was stated in the introduction, for now saving edited document in Mobi format is not supported.

## Detecting Mobi documents

As for documents of all supporting types, Mobi documents can be detected using a [`GetDocumentInfo()`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/getdocumentinfo) method of the [`Editor`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor) class. In case when a valid Mobi document was loaded into the [`Editor`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor) instance, a [`GetDocumentInfo()`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/getdocumentinfo) will return an instance of a [`Metadata.MobiDocumentInfo`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.metadata/mobidocumentinfo) class, which inherits from [`IDocumentInfo`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.metadata/idocumentinfo) interface, which, in turn, defines 4 properties: `Format`, `PageCount`, `Size`, and `IsEncrypted`.
* [`Format`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.metadata/mobidocumentinfo/properties/format) property always returns a `Formats.EBookFormats.Mobi` enum value.
* [`PageCount`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.metadata/mobidocumentinfo/properties/pagecount) property returns an **approximate** number of pages. It is approximate, because Mobi format internally is a set of HTML documents (chapters), which are not separated on pages and even have no strict page dimensions, which allows to split content on page blocks and thus calculate the number of pages. This decision was made by Mobi format designers intentionally to allows variable page size (and count) on different devices — from FullHD displays to smartphones. So, for returning a page count for a Mobi document, GroupDocs.Editor assumes standard A4 page size in a portrait orientation, splits existing document content on such "papers", and then calculates its count. So the returning number should be treated very carefully and approximately, users should not rely on it.
* [`Size`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.metadata/mobidocumentinfo/properties/size) property returns a number of bytes of a Mobi document.
* [`IsEncrypted`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.metadata/mobidocumentinfo/properties/isencrypted) property always returns a `false` value, because Mobi documents cannot be encrypted with password, like PDF or Office Open XML.
