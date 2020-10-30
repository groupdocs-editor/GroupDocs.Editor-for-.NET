---
id: groupdocs-editor-for-net-20-10-release-notes
url: editor/net/groupdocs-editor-for-net-20-10-release-notes
title: GroupDocs.Editor for .NET 20.10 Release Notes
weight: 54
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 20.10{{< /alert >}}

GroupDocs.Editor for .NET version 20.10 provides one new important feature, which has an impact on public API, as well as a set of improvements and bugfixes. It is worth to mention that this new feature _doesn't break a backward compatibility_, but only introduces new public members in existing type, so existing client code is fully compatible for this release. All of these are described in detail below.

## New features

### Ability to save content of edited worksheet in the original spreadsheet

Before version 20.10 when working with spreadsheet documents it was possible only to generate a spreadsheet with single worksheet (tab) after editing. From now, user is able to enable a possibility to insert an edited worksheet into the original spreadsheet on desired position. This feature introduces two new public properties — integer [WorksheetNumber](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetsaveoptions/properties/WorksheetNumber) and boolean flag [InsertAsNewWorksheet](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetsaveoptions/properties/InsertAsNewWorksheet), — in the [SpreadsheetSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetsaveoptions) class. More on that in special dedicated article ["Inserting edited worksheet into existing Spreadsheet"]({{< ref "editor/net/developer-guide/advanced-usage/working-with-spreadsheets/inserting-edited-worksheet-into-existing-spreadsheet.md" >}}).

## Improvements
### Support of new HTML elements

Version 20.10 contains a full support of the next HTML elements: RUBY, FIGURE, FIGCAPTION. This improvement doesn't affect an API, but now GroupDocs.Editor can properly and without exceptions handle the HTML markup with these HTML elements inside.

### Multiple improvements in CSS processing

Module, which is responsible for working with CSS stylesheets, was significantly improved in the 20.10 version. In particular:

1. Before version 20.10, when obtaining a stylesheet, where duplicate selectors are present, the GroupDocs.Editor generated an exception. From now it properly handles such rulesets by merging them into one.
2. Support of `margin` CSS property and its long-hand versions was completely reworked, so now typos and invalid values will not cause a parse error.
3. A `hyphens` CSS property was added.

### Improvements in Presentation module

Presentation module was also improved in the version 20.10. In particular, from this moment OLE frames in presentations are fully supported, while before version 20.10 their presence in presentation caused the exceptions. Also, a full support of bidirectional text in slides was added.

## Bugs

GroupDocs.Editor version 20.10 contains lots of bugfixes, which address different exceptions in different modules of GroupDocs.Editor, including WordProcessing, Spreadsheet, Presentation, and XML.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1812 | Add feature for saving edited content of specific sheet in the initial file | New feature |
| EDITORNET-1845 | Add support of RUBY HTML element | Improvement |
| EDITORNET-1846 | Add support of Hyphens CSS declaration | Improvement |
| EDITORNET-1853 | Add ability to parse stylesheets with duplicate selectors | Improvement |
| EDITORNET-1854 | Fully rework and improve a Margin recognizer | Improvement |
| EDITORNET-1857 | Add support of FIGURE and FIGCAPTION HTML elements | Improvement |
| EDITORNET-1860 | Implement support of bidirectional text in presentations | Improvement |
| EDITORNET-1861 | Implement support of OLE frames in presentations | Improvement |
| EDITORNET-1819 | Cannot process atribute value, which contains a '@style' substring | Bug |
| EDITORNET-1847 | Exception while processing 2nd slide of PPT | Bug |
| EDITORNET-1858 | Node type 'EditableRangeEnd' ('12') and corresponding instance of 'Aspose.Words.EditableRangeEnd' class currently are not supported | Bug |
| EDITORNET-1862 | Font name cannot be NULL, empty or whitespaces | Bug |
| EDITORNET-1868 | Parameter is not valid when editing PowerPoint document | Bug |

## Public API and Backward Incompatible Changes

As it was described in "New Features" section above, there are two new public properties GroupDocs.Editor API, however, all of them don't break a backward compatibility.

List of new members in existing types:
1. [WorksheetNumber](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetsaveoptions/properties/WorksheetNumber) property in [GroupDocs.Editor.Options.SpreadsheetSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetsaveoptions) class
2. [InsertAsNewWorksheet](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetsaveoptions/properties/InsertAsNewWorksheet) property in [GroupDocs.Editor.Options.SpreadsheetSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetsaveoptions) class
