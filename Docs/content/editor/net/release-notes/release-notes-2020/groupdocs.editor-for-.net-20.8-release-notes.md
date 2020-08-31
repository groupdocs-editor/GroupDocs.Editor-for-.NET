---
id: groupdocs-editor-for-net-20-8-release-notes
url: editor/net/groupdocs-editor-for-net-20-8-release-notes
title: GroupDocs.Editor for .NET 20.8 Release Notes
weight: 56
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 20.8{{< /alert >}}

GroupDocs.Editor for .NET version 20.8 provides mostly different bugfixes, that address various problems in different modules and scenarios. Along with that, there are several important improvements, which, however, doesn't affect the public API.

## Improvements

### Support of SmartArt elements in Presentations

The most important feature in the version 20.8 is a support of particular SmartArt elements, which are used in the most common Presentation formats such as PPTX, PPTM, POTX and so on. Prior this version the SmartArt was not supported at all, and its presence in the input document inevitably caused an exception. Despite described as a feature, SmartArt support should be treated as improvement, because it doesn't affect the public API at all.

### Support of @namespace at-rule

In version 20.8 we've added a full support of a @namespace CSS at-rule, including its object model, serialization and parsing, so now a presence of this rule in the customer stylesheet(s) will not cause an exception.

### Support of new NAV HTML5 element

In version 20.8 we've added a full support of a NAV HTML5 elements. Despite GroupDocs.Editor currently doesn't emit this element when generates a HTML-representation of the document, but this element may occur in user-generated HTML and will be properly handled, parsed and transferred without causing an exception.

## Bugs

GroupDocs.Editor version 20.8 contains lots of bug-fixes, related no distorted document rendering, exceptions, missed elements in edited documents, improper support and processing of different use-cases and so on.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1760 | Add support of SmartArt nodes for Presentations | Improvement |
| EDITORNET-1761 | Add support of namespace at-rule | Improvement |
| EDITORNET-1763 | Add support of NAV HTML5 element | Improvement |
| EDITORNET-1616 | Insert Fields into backward paged converters | Bug |
| EDITORNET-1688 | File representation is distorted | Bug |
| EDITORNET-1689 | File is damaged error | Bug |
| EDITORNET-1727 | Save edits failed | Bug |
| EDITORNET-1767 | Not supported Shape | Bug |
| EDITORNET-1768 | Fix issue with overlapping list label mark and list item content | Bug |
| EDITORNET-1769 | Exception while calculating table cell width | Bug |
| EDITORNET-1773 | Fix bug with unsupported FieldStart node in unknown SDT node | Bug |
| EDITORNET-1774 | Fix bug with unsupported BookmarkStart node within the RichText SDT node | Bug |
| EDITORNET-1775 | Fix bug with unsupported Run node in TOC SDT node | Bug |

## Public API and Backward Incompatible Changes

No new types members or changes in existing types/members in public API.


