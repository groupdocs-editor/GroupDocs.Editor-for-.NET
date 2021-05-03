---
id: groupdocs-editor-for-net-21-4-release-notes
url: editor/net/groupdocs-editor-for-net-21-4-release-notes
title: GroupDocs.Editor for .NET 20.4 Release Notes
weight: 80
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 21.4{{< /alert >}}

GroupDocs.Editor for .NET version 21.4 delivers several significant improvement and a set of different bugfixes in various parts of the product.

## Improvements

GroupDocs.Editor version 21.4 contains three significant improvements:
1. Improved resources import during backward processing. In previous version of GroupDocs.Editor it was a quite hard to properly import HTML markup with external resources during backward conversion, when these resources are references via complete URIs. Now this mechanism was significantly improved, which can ease an integration of GroupDocs.Editor into existing solutions.
2. In previous versions of GroupDocs.Editor for .NET we have changed a table processing mechanism in forward WordProcessing converter in order to fix several bugs. Unfortunately, this new mechanism has a lack of lot of features, which were present in previous one. In version 21.4 we finally fixed all existing bugs in old mechanism, so now table processing is bug-free and also feature-rich, combining all the advantages from both mechanisms.
3. Version 21.4 also contains a support of 3 new HTML elements: RUBY, RP and RT. This means that now WYSIWYG-editors can produce HTML-markup with these elements, and GroupDocs.Editor will correctly recognize and process them during backward conversion.

## Bugs

GroupDocs.Editor version 21.4 contains big amount of bugfixes, which address different exceptions and one performance regression in different modules of GroupDocs.Editor, mainly WordProcessing.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-2059 | Improve resources import during backward processing | Improvement |
| EDITORNET-2062 | Enable old table processing mechanism | Improvement |
| EDITORNET-2065 | Add support of RUBY, RP and RT HTML elements | Improvement |
| EDITORNET-1902 | WordProcessing: in input element put content to placeholder. | Bug |
| EDITORNET-1939 | Performance gap in backward table processing | Bug |
| EDITORNET-1986 | Docx to Markdown converter was lost part of text. | Bug |
| EDITORNET-1987 | Footnotes are not correctly transfered during conversion between DOCX and Markdown | Bug |
| EDITORNET-2017 | Length cannot be less than 2 Parameter name: colorStops Actual value was 0. | Bug |
| EDITORNET-2034 | HTML generated is not consistent | Bug |
| EDITORNET-2057 | Presentation: not rendering Shape's figure | Bug |
| EDITORNET-2060 | Fix exception while processing lists | Bug |
| EDITORNET-2061 | EMF and WMF images are emitted to HTML without reconverting to PNG | Bug |
| EDITORNET-2063 | Fix missing table borders | Bug |
| EDITORNET-2064 | Fix bug with broken local links | Bug |

## Public API and Backward Incompatible Changes

No new types members or changes in existing types/members in public API.
