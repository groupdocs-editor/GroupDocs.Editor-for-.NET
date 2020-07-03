---
id: groupdocs-editor-for-net-20-5-release-notes
url: editor/net/groupdocs-editor-for-net-20-5-release-notes
title: GroupDocs.Editor for .NET 20.5 Release Notes
weight: 60
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 20.5{{< /alert >}}

## Major Features

GroupDocs.Editor for .NET version 20.5 contains different bug fixes and improvements, that are described below. There are no changes or new members in a public API.

### New HTML structure for WordProcessing documents in paged mode

Starting from version 20.5, GroupDocs.Editor generates new structure of HTML elements, when opening WordProcessing documents in paged mode. This was done in order to improve handling and quality of roundtrip of internal WordProcessing structure: sections, page headers/footers, footnotes area etc. This feature doesn't have any negative effects and hasn't touched public API.

### Correct rendering of rectangular textboxes

There is a set of shapes in a WordProcessing documents, which in fact are not the raster images, but text with complex formatting inside borders. Prior version 20.5 GroupDocs.Editor processed such shapes as images by rasterizing them to PNG (so, in the intermediate HTML such shapes was represented as ordinary raster PNG images). Starting from version 20.5, GroupDocs.Editor represents them without rasterization, using only HTML/CSS. Along with decreased final document size, this also allows end-users to edit content of such shapes.

### Support of several new HTML5 elements

Starting from version 20.5, GroupDocs.Editor supports the next HTML5 sectioning elements: SECTION, ARTICLE, ASIDE, MAIN, HEADER, and FOOTER. This means that end-users can use these elements within their front-end HTML editors, and these elements will be correctly parsed, processed and represented in the final WordProcessing document.

### Preserving WordProcessing page settings during roundtrip with support of @page at-rule

Almost all WordProcessing documents have page settings, which specify page orientation (landscape or portrait), page sizes (width and height) and margins (left, top, right, and bottom). Prior version 20.5 GroupDocs.Editor didn't preserve these page settings. When edited document content was passed to the `EditableDocument` and then saved to the output WordProcessing document, this WordProcessing contains default page settings. Starting from version 20.5, all page settings are preserved. It was done by via CSS @page at-rule, — it is now completely supported. When performing document conversion from WordProcessing to `EditableDocument` and then to HTML, all page settings are stored inside the @page at-rule. And when the document was edited in the HTML editor and passed back to the `EditableDocument` instance, the GroupDocs.Editor correctly parsed @page at-rule, extracts all page settings from it and applies them to the output document.

This pipeline also means that end-users can manually add or modify @page at-rule in order to adjust page settings for their needs.

### Plenty of fixed bugs

GroupDocs.Editor for .NET version 20.5 contains a lot of fixed serious bugs, which caused different exceptions, lack of features and improper rendering in different use-cases.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1615 | Implement new HTML elements structure for the paged mode | Improvement |
| EDITORNET-1620 | Develop correct rendering of rectangular textboxes | Improvement |
| EDITORNET-1639 | Add support of several HTML5 sectioning elements | Improvement |
| EDITORNET-1645 | Implement page settings during roundtrip | Improvement |
| EDITORNET-1585 | Extra left margin and truncation from right side in output WordProcessing after roundtrip | Bug |
| EDITORNET-1593 | Unexpected list level mismatch | Bug |
| EDITORNET-1594 | Internal error - unexpected data mismatch | Bug |
| EDITORNET-1600 | Value cannot be null | Bug |

## Public API and Backward Incompatible Changes

No new types members or changes in existing types/members in public API.
