---
id: groupdocs-editor-for-net-20-1-release-notes
url: editor/net/groupdocs-editor-for-net-20-1-release-notes
title: GroupDocs.Editor for .NET 20.1 Release Notes
weight: 100
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 20.1{{< /alert >}}{{< alert style="danger" >}}In this version we will remove Legacy API of GroupDocs.Editor. So from version 20.1 GroupDocs.Editor.Legacy. does not exist anymore{{< /alert >}}

## Major Features

GroupDocs.Editor for .NET version 20.1 contains a list of improvements and bug-fixes, but the most important is that starting from this version the Legacy API is completely removed.

The most prominent improvements include:

*   Better support of opening HTML document from inner-BODY markup
*   Added support of BUTTON HTML element
*   Added support of MACROBUTTON field in WordProcessing documents
*   Added support of STRIKE HTML element

All these improvements are "internal", they do not affect public API.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1454 | Improve opening EditableDocument from inner-body markup by supporting a root BODY element | Improvement |
| EDITORNET-1460 | Add support of BUTTON element | Improvement |
| EDITORNET-1461 | Implement support of MACROBUTTON field | Improvement |
| EDITORNET-1464 | Fix bug and add complete support of obsolete STRIKE HTML element | Improvement |
| EDITORNET-1430 | Additional style sheet is not saved in embedded version in WordProcessing paginal mode | Bug |
| EDITORNET-1452 | Bug in HTML attribute parsing | Bug |
| EDITORNET-1457 | Exception while opening DOCX with specific field | Bug |
| EDITORNET-1458 | Exception in .NET Standard version of GD.Editor | Bug |
| EDITORNET-1450 | MSI package signature is not applied during release build | Bug |
| EDITORNET-1465 | Fix bug with locked HTML resources | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Editor for .NET 20.1. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Editor which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

1.  **GroupDocs.Editor.Legacy**
    
    Removed all public types form GroupDocs.Editor.Legacy namespace.
