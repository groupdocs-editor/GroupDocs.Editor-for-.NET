---
id: groupdocs-editor-for-net-20-7-release-notes
url: editor/net/groupdocs-editor-for-net-20-7-release-notes
title: GroupDocs.Editor for .NET 20.7 Release Notes
weight: 58
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 20.7{{< /alert >}}

GroupDocs.Editor for .NET version 20.7 provides several completely new features with new API types and members, a lot of improvements and bug fixes, all of which are described below. Despite a lot of API changes, all of them are new types and members of existing types, and **they don't break a backward compatibility**, so existing client code is fully compatible for this release.

## New features

### Support of Mobi format

Starting from version 20.7, the GroupDocs.Editor for .NET started to support a Mobi E-book format. However, at this time only loading, detecting and editing operations are supported, but not saving. We've prepared a special article, that described working especially with Mobi format: "[Working with Mobi documents]({{< ref "editor/net/developer-guide/advanced-usage/working-with-mobi-documents.md" >}})". Along with this format, we've introduced new public types: [`MobiEditOptions`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/mobieditoptions), [`Metadata.MobiDocumentInfo`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.metadata/mobidocumentinfo), and [`Formats.EBookFormats`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.formats/ebookformats). All of them are introduced in the article.

### Ability to embed fonts in resultant WordProcessing document during saving

Before version 20.7 the GroupDocs.Editor was able to extract fonts from input WordProcessing document, that is editing, and put them into the intermediate [`EditableDocument`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) and through it — to the HTML, that will be edited on client-side. Starting from version 20.7 the GroupDocs.Editor is also able to grab fonts after client-side edit from [`EditableDocument`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) and operating system and embed them into output WordProcessing document, that is generated from edited [`EditableDocument`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument). For doing this there is a new type — an `Options.FontEmbeddingOptions` enum. Also, the [`WordProcessingSaveOptions`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions) class now contains a new property `FontEmbedding`, of `FontEmbeddingOptions` type. Like with Mobi, there is a new article "[Font embedding options]({{< ref "editor/net/developer-guide/advanced-usage/working-with-wordprocessing-documents/font-embedding-options.md" >}})", which is dedicated especially for this feature.

## Improvements

### Support of new CSS properties

In version 20.7 we've added full support of four new CSS properties: box-sizing, visibility, text-rendering, and tab-size. This means that end-users can use these properties in documents while editing them in WYSIWYG-editors; GroupDocs.Editor now is able to parse and correctly process them.

### Support of new HTML elements

In version 20.7 we've added a full support of IFRAME and NOSCRIPT HTML elements. Despite these elements have nothing common with HTML editing in WYSIWYG-editor and are ignored, from now their presence in HTML markup and consequent [`EditableDocument`](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance will not break the GroupDocs.Editor work by causing an exception.

## Bugs

GroupDocs.Editor version 20.7 contains lots of bugfixes, related no distorted document rendering, exceptions, missed elements in edited documents, improper support and processing of different use-cases and so on.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1069 | Implement support of MOBI document format | New feature |
| EDITORNET-1558 | Implement font embedding for backward HTML-to-WordProcessing converter | New feature |
| EDITORNET-1716 | Add support of box-sizing CSS declaration | Improvement |
| EDITORNET-1717 | Add support of visibility CSS declaration | Improvement |
| EDITORNET-1718 | Add support of text-rendering CSS declaration | Improvement |
| EDITORNET-1721 | Add support of tab-size CSS declaration | Improvement |
| EDITORNET-1723 | Add support of IFRAME element | Improvement |
| EDITORNET-1724 | Add support of NOSCRIPT element | Improvement |
| EDITORNET-1608 | Fix layout truncation from right side in paged mode | Bug |
| EDITORNET-1694 | Check possible bug in Presentation module | Bug |
| EDITORNET-1715 | Exception while comparing IMG elements with absent images | Bug |
| EDITORNET-1719 | Exception while opening reconverted XLSX | Bug |
| EDITORNET-1725 | Add support of QUOT mnemonics for font-family | Bug |
| EDITORNET-1726 | Content is shifted to the left outside from viewport | Bug |
| EDITORNET-1728 | Can't get HTML representation of docx file | Bug |

## Public API and Backward Incompatible Changes

As it was described in "New Features" section above, there is a several new public types and members in GroupDocs.Editor API, however, all of them don't break a backward compatibility.

List of new types is below:
* GroupDocs.Editor.Formats.EBookFormats struct
* GroupDocs.Editor.Metadata.MobiDocumentInfo struct
* GroupDocs.Editor.Options.MobiEditOptions class
* GroupDocs.Editor.Options.FontEmbeddingOptions enum

List of new members in existing types:
* FontEmbedding property of FontEmbeddingOptions type in GroupDocs.Editor.Options.WordProcessingSaveOptions class


