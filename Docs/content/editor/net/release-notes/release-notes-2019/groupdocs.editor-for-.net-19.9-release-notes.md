---
id: groupdocs-editor-for-net-19-9-release-notes
url: editor/net/groupdocs-editor-for-net-19-9-release-notes
title: GroupDocs.Editor for .NET 19.9 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 19.9{{< /alert >}}

## Major Features

{{< alert style="danger" >}}In this version we're introducing new public API which was designed to be simple and easy to use. For more details about new API please check Public Docs section. The legacy API have been moved into Legacy namespace so after update to this version it is required to make project-wide replacement of namespace usages from GroupDocs.Editor. to GroupDocs.Editor.Legacy. to resolve build issues.{{< /alert >}}

#### New GetDocumentInfo method

Along with new API, GroupDocs.Editor contains new GetDocumentInfo method, that allows to get metainfo about the input document without editing it:

*   Family format and exact document format.
*   Encryption flag.
*   Number of pages/tabs.
*   Size.

#### New text save options

All previous versions of GroupDocs.Editor don't contain specialized options, responsible for saving edited document in plain text format — in order to do this user should use WordProcessing save options, which don't allow to configure parameters while saving into text. This 19.9 version of GroupDocs.Editor contains new `TextSaveOptions` class, that is responsible especially for saving edited document to the plain text format. `TextSaveOptions` class contains the next new settings:

*   Ability to specify whether to add bi-directional marks before each BiDi run when exporting in plain text format.
*   Ability to specify whether the program should attempt to preserve layout of tables when saving in the plain text format.

## Other features

Lot of minor and major bug fixes and improvements over all code base.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1286 | New public API | Feature |
| EDITORNET-1287 | Implement GetDocumentInfo method | Feature |
| EDITORNET-1288 | New TextSaveOptions | Feature |

# Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Editor for .NET 19.9. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Editor which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

## New GetDocumentInfo method

The new `Editor` class, which supersedes deprecated `EditorHandler`, contains a new instance method `GetDocumentInfo` with the next signature:

```csharp
public IDocumentInfo GetDocumentInfo(string password)
```

  
Once the document was loaded into the `Editor` class, this method can be called to obtain metainfo about the loaded document without actual opening it for editing.

## New TextSaveOptions class

The `Options` namespace now contains a new `TextSaveOptions` class, that is responsible for saving `EditableDocument` with edited document content to the plain text format. It has the next signature:

```csharp
/// <summary>
/// Allows to specify custom options for generating and saving plain text (TXT) documents
/// </summary>
public sealed class TextSaveOptions : ISaveOptions
{
    /// <summary>
    /// Character encoding of the text document, which will be applied for its saving
    /// </summary>
    public System.Text.Encoding Encoding { get; set; }
 
    /// <summary>
    /// Specifies whether to add bi-directional marks before each BiDi run when exporting in plain text format
    /// </summary>
    public bool AddBidiMarks { get; set; }
 
    /// <summary>
    /// Specifies whether the program should attempt to preserve layout of tables when saving in the plain text format. The default value is false.
    /// </summary>
    public bool PreserveTableLayout { get; set; }
}
```

## Old API is moved to Legacy namespace

#### All public types from GroupDocs.Editor namespace 

1.  Have been moved into **GroupDocs.Editor.Legacy** namespace
2.  Marked as **Obsolete** with message: *This class is obsolete and will be available till January 2020 (v20.1).*

#### Full list of types that have been moved and marked as obsolete:

1.  GroupDocs.Editor.EditorHandler => GroupDocs.Editor.Legacy.EditorHandler
2.  GroupDocs.Editor.InputHtmlDocument => GroupDocs.Editor.Legacy.InputHtmlDocument
3.  GroupDocs.Editor.OutputHtmlDocument => GroupDocs.Editor.Legacy.OutputHtmlDocument
4.  GroupDocs.Editor.Options.DocumentProtectionOptions => GroupDocs.Editor.Legacy.Options.DocumentProtectionOptions
5.  GroupDocs.Editor.Options.DocumentProtectionType => GroupDocs.Editor.Legacy.Options.DocumentProtectionType
6.  GroupDocs.Editor.Options.FontExtractionOptions => GroupDocs.Editor.Legacy.Options.FontExtractionOptions
7.  GroupDocs.Editor.Options.IDocumentLoadOptions => GroupDocs.Editor.Legacy.Options.IDocumentLoadOptions
8.  GroupDocs.Editor.Options.IDocumentSaveOptions => GroupDocs.Editor.Legacy.Options.IDocumentSaveOptions
9.  GroupDocs.Editor.Options.PdfCompliance => GroupDocs.Editor.Legacy.Options.PdfCompliance
10.  GroupDocs.Editor.Options.PdfSaveOptions => GroupDocs.Editor.Legacy.Options.PdfSaveOptions
11.  GroupDocs.Editor.Options.SpreadsheetFormats => GroupDocs.Editor.Legacy.Options.SpreadsheetFormats
12.  GroupDocs.Editor.Options.SpreadsheetSaveOptions => GroupDocs.Editor.Legacy.Options.SpreadsheetSaveOptions
13.  GroupDocs.Editor.Options.SpreadsheetToHtmlOptions => GroupDocs.Editor.Legacy.Options.SpreadsheetToHtmlOptions
14.  GroupDocs.Editor.Options.TextLeadingSpacesOptions => GroupDocs.Editor.Legacy.Options.TextLeadingSpacesOptions
15.  GroupDocs.Editor.Options.TextToHtmlOptions => GroupDocs.Editor.Legacy.Options.TextToHtmlOptions
16.  GroupDocs.Editor.Options.TextTrailingSpacesOptions => GroupDocs.Editor.Legacy.Options.TextTrailingSpacesOptions
17.  GroupDocs.Editor.Options.WordProcessingFormats => GroupDocs.Editor.Legacy.Options.WordProcessingFormats
18.  GroupDocs.Editor.Options.WordProcessingSaveOptions => GroupDocs.Editor.Legacy.Options.WordProcessingSaveOptions
19.  GroupDocs.Editor.Options.WordProcessingToHtmlOptions => GroupDocs.Editor.Legacy.Options.WordProcessingToHtmlOptions
20.  GroupDocs.Editor.Options.WorksheetProtection => GroupDocs.Editor.Legacy.Options.WorksheetProtection
21.  GroupDocs.Editor.Options.WorksheetProtectionType => GroupDocs.Editor.Legacy.Options.WorksheetProtectionType
22.  GroupDocs.Editor.Options.XmlHighlightOptions => GroupDocs.Editor.Legacy.Options.XmlHighlightOptions
23.  GroupDocs.Editor.Options.XmlToHtmlOptions => GroupDocs.Editor.Legacy.Options.XmlToHtmlOptions
