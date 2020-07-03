---
id: groupdocs-editor-for-net-19-10-1-release-notes
url: editor/net/groupdocs-editor-for-net-19-10-1-release-notes
title: GroupDocs.Editor for .NET 19.10.1 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 19.10.1{{< /alert >}}

## Major features

GroupDocs.Editor for .NET version 19.10.1 is a hot-fix for the previous release 19.10, which contains fixes for several critical bugs and also minor improvements.

### Bugs

1.  When performing full roundtrip without editing in Presentation document in trial mode, an exception is thrown.
2.  In some cases there are undisposed resources in the EditableDocument class even after calling the "Dispose()" method.
3.  Bindings for Aspose components are missed in 19.10.

### Improvements

Improved XML-comments for the GroupDocs.Editor.Editor main class.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1320 | Exception during roundtrip in Presentation module in trial mode | Bug |
| EDITORNET-1353 | Undisposed resources in EditableDocument class | Bug |
| EDITORNET-1354 | Missing bindings for Aspose components | Bug |
| EDITORNET-1355 | Improve XML-comments in the Editor class | Improvement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Editor for .NET 19.10.1. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Editor which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

*   None
