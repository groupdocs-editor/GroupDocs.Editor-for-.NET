---
id: groupdocs-editor-for-net-20-6-release-notes
url: editor/net/groupdocs-editor-for-net-20-6-release-notes
title: GroupDocs.Editor for .NET 20.6 Release Notes
weight: 59
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 20.6{{< /alert >}}

## Major Features

GroupDocs.Editor for .NET version 20.6 contains different bug fixes and a lot of different improvements, all of which are described below. There are no changes or new members in a public API.

### Add support of fields, located across multiple adjacent consequent paragraphs

In most usual and common cases fields are located within one single paragraph. However, some specific fields, defined in Office Open XML format, like hyperlink field, may be placed over multiple paragraphs. Before version 20.5 GroupDocs.Editor didn't support them and exception was thrown when such field was faced; now such fields will be correctly processed and represented in HTML/CSS markup.

### Support of FILENAME field

Prior version 20.5 the FILENAME field was not supported and the exception was thrown; now it is fully supported.

### Support of interleaved lists and complex list item marks

Lists in WordProcessing documents may be very complicated, and have very cumbersome item marks. GroupDocs.Editor team continuously improves quality of list processing. In version 20.6 GroupDocs.Editor starts to support custom list item marks with very complex formatting. Another improvement — *interleaved lists*. There may be a scenario, when there is some numbered list, which is present by several items. Then this list is interrupted, and second list, with completely own marks and numbering base, is started. And then this second list stops, and first one is continuing, with preserving numbering offset. Pure HTML doesn't provide possibility to create such lists with OL/LI elements. However, it is possible with *counter-reset*/*counter-increment* CSS functions. In version 20.6 such lists are fully supported.

### Support of TIME HTML field

Now a TIME HTML5 element is fully supported, along with its emitting during field processing (explained below) and parsing.

### Support of all date- and time-related fields

WordProcessing standard (Office Open XML presumable) defines a set of fields, some of which are date- and time-related: DATE, TIME, CREATEDATE, PRINTDATE, and SAVEDATE. All of them were supported previously, but poorly and without specificity. Now all of them are supported at the best: they are represented in HTML markup within HTML5 TIME element, with metadata regarding exact time in special attribute, and representation inside the TIME element, with preserving all formatting.

### Better processing of incompatible markup in WordProcessing converter in paged mode

When editing WordProcessing documents in paged mode, and when saving edited in WYSIWYG editor document (which is represented as HTML) back to some WordProcessing format using the `Editor.Save()` method, GroupDocs.Editor expects HTML markup with very strict and defined structure — root MAIN element with one or more SECTION child elements, and so on. Only when such structure is present and valid, this markup will be saved back to WordProcessing document in paged mode.

In version older then 20.6, if such structure was corrupted, GroupDocs.Editor was throwing an exception. Starting from version 20.6, GroupDocs.Editor seamlessly switches to the float mode without throwing an exception.

### Support of collapsed borders between adjacent paragraphs

Paragraphs in WordProcessing documents may have own borders of different style, width and color, on any side or on all sides. And when there are two or mode adjacent paragraphs, they may have or may not have a border between them. If such border exists, it will be collapsed. Before version 20.6, GroupDocs.Editor had no support of borders between paragraphs. Starting from 20.6, such inter-paragraph borders are fully and correctly supported.

### Improved compatibility with Linux

The 20.6 release is notable in context of Linux support — there were implemented a huge amount of improvements and fixed tons of bugs, which are related to Linux and occur only when running GroupDocs.Editor on Linux platform on .NET Core. These bugs and improvements include, but not limited to:

*   Using Windows-specific DLLs
*   Numbers rounding
*   Different file/folder path separators
*   Different new line/carriage return characters
*   Lots of other

### Plenty of fixed bugs

GroupDocs.Editor for .NET version 20.6 contains a lot of fixed serious bugs, which caused different exceptions, lack of features and improper rendering in different use-cases. This includes exceptions during processing lists and fields, bug with improper text underlying, bug with insufficient and improper paragraph borders, bug with missed background image in Presentation slides, and some other minor bugs.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1654 | Add support of fields, located across multiple adjacent consequent paragraphs | Improvement |
| EDITORNET-1674 | Add support of FILENAME field | Improvement |
| EDITORNET-1675 | Improve processing of complex list item marks and interleaved lists | Improvement |
| EDITORNET-1677 | Add support of TIME element | Improvement |
| EDITORNET-1678 | Add support of all DateTime-related fields | Improvement |
| EDITORNET-1682 | Stabilize passing an invalid markup into backward WordProcessing converter in paged mode | Improvement |
| EDITORNET-1686 | Implement collapsed borders between adjacent paragraphs | Improvement |
| EDITORNET-1713 | Improve compatibility with Linux and fix Linux-specific bugs | Improvement |
| EDITORNET-1595 | An item with the same key has already been added | Bug |
| EDITORNET-1601 | Object reference not set to an instance of an object | Bug |
| EDITORNET-1676 | Fix bug with redundant text underlining | Bug |
| EDITORNET-1681 | Fix borders in empty paragraphs | Bug |
| EDITORNET-1685 | Background image is missed after backward conversion from HTML to Presentation | Bug |

## Public API and Backward Incompatible Changes

No new types members or changes in existing types/members in public API.


