---
id: groupdocs-editor-for-net-20-3-release-notes
url: editor/net/groupdocs-editor-for-net-20-3-release-notes
title: GroupDocs.Editor for .NET 20.3 Release Notes
weight: 80
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 20.3{{< /alert >}}

## Major Features

GroupDocs.Editor for .NET version 20.3 contains a set of new features, improvements and bug fixes, which are described below.

### Expanded fonts processing

Starting from version 20.3, GroupDocs.Editor is able to extract fonts, installed in the operating system, not only from the system folder, common for all users, but also from user folder, which was introduced in the MS Windows 10. This feature doesn't affect the public API.

In counterpart, the next feature, related to font processing, has affected the public API: new boolean flag named `ExtractOnlyUsedFont` was added to the [WordProcessingEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions) class. Setting this flag to `true` allows to exclude those fonts, which are not directly applied to textual content in the document.

More info about these two features is located in the corresponding article "[Font extraction options]({{< ref "editor/net/developer-guide/advanced-usage/working-with-wordprocessing-documents/font-extraction-options.md" >}})".

### Improvements in HTML support

With version 20.3, GroupDocs.Editor supports new HTML elements: COLGROUP, SECTION, OPTGROUP, BDI, BDO, CAPTION, ARTICLE, and WBR. Now input or edited HTML document can contain these elements, and their presence will not lead to the exception. This improvement doesn't affect the public API.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1578 | Add support of user-installed fonts folder on Windows 10 | New feature |
| EDITORNET-1579 | Add ability to extract only fonts, actually used in the document | New feature |
| EDITORNET-1536 | Add support of COLGROUP HTML element | Improvement |
| EDITORNET-1537 | Implement the SECTION HTML element | Improvement |
| EDITORNET-1538 | Implement the OPTGROUP HTML element | Improvement |
| EDITORNET-1539 | Add support of BDI HTML element | Improvement |
| EDITORNET-1542 | Add support of BDO HTML element | Improvement |
| EDITORNET-1543 | Add support of CAPTION HTML element | Improvement |
| EDITORNET-1545 | Implement ARTICLE HTML element | Improvement |
| EDITORNET-1546 | Add support of WBR HTML element | Improvement |
| EDITORNET-1535 | Missing footer during roundtrip conversion in paged mode | Bug |
| EDITORNET-1547 | Fix bug in attribute selector parser | Bug |
| EDITORNET-1549 | Exception in bookmark processing mechanism | Bug |
| EDITORNET-1552 | Fix bug with missing HTML attributes in INPUT HTML element | Bug |

## Public API and Backward Incompatible Changes

#### New property in WordProcessingEditOptions class

Implementing a EDITORNET-1579 ticket has a result in form of a new public property in the `GroupDocs.Editor.Options.WordProcessingEditOptions` class:

```csharp
public bool ExtractOnlyUsedFont {get; set;}
```

## Known issues

One of the new features in version 20.3, described above, is support of obtain user-installed fonts on Windows 10. However, in this version it is impossible to obtain user-installed font with .NET Standard 2.0 assembly, only with .NET Framework. In this scenario the code will not raise an exception, — the user-installed font simply will be ignored. This issue is expected to be fixed in the consequent version 20.4.
