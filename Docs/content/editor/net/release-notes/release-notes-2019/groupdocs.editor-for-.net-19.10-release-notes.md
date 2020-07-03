---
id: groupdocs-editor-for-net-19-10-release-notes
url: editor/net/groupdocs-editor-for-net-19-10-release-notes
title: GroupDocs.Editor for .NET 19.10 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 19.10{{< /alert >}}

## Major features

This release contains one major feature - full support of Presentation format family, that includes PPT, PPTX, PPTM, POT, PPS, and more Presentation formats. Presentation support came with a set of new load/edit/save option classes, formats, its support was also added to the GetDocumentInfo method.

## Other features

Along with new Presentation module, GroupDocs.Editor now contains binding redirects for Aspose components. This means that now GroupDocs.Editor for .NET can successfully work together with any of Aspose libraries without any incompatibilities.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1317 | Add Presentations editing support | Feature |
| EDITORNET-1318 | Add Presentation support into GetDocumentInfo method | Feature |
| EDITORNET-1308 | Setup binding redirects for third-party components | Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Editor for .NET 19.10. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Editor which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

*   Presentation module - ability to load, open for editing, edit and save Presentation documents. This feature is represented in public API by the next new public types.
    
    | Type name | Responsibility |
    | --- | --- |
    | PresentationLoadOptions | Allows to specify custom options for loading documents of all supportable Presentation formats like PPT(X), PPTM, PPS(X) etc. |
    | PresentationEditOptions | Allows to specify custom options for editing documents of all supportable Presentation (PowerPoint-compatible) formats |
    | PresentationSaveOptions | Allows to specify custom options for generating and saving Presentation (PowerPoint-compatible) documents |
    | PresentationDocumentInfo | Represents metadata of one Presentation document |
    | PresentationFormats | Encapsulates all Presentation formats |
