---
id: groupdocs-editor-for-net-20-2-release-notes
url: editor/net/groupdocs-editor-for-net-20-2-release-notes
title: GroupDocs.Editor for .NET 20.2 Release Notes
weight: 90
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 20.2{{< /alert >}}

## Major Features

GroupDocs.Editor for .NET version 20.2 contains several new features, improvements and bug fixes, which are briefly listed below:

*   New feature, that allows to set custom class name for all form-fields with corresponding public options.
*   New option, which allows to specify a text direction for the input plain text document (TXT) before its editing.
*   Added support of PDF 1.7 standard while saving edited document to PDF.
*   Fixed bug with a document, that was incorrectly rendered to HTML in paginal mode and then incorrectly converted back to WordProcessing.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1467 | Add ability to set custom class name for all form-fields with corresponding public options | New feature |
| EDITORNET-1512 | Add support of text direction in input plain text document | New feature |
| EDITORNET-1505 | Add support of PDf 1.7 | Improvement |
| EDITORNET-1504 | WordProcessing document is incorrectly rendered in paginal mode | Bug |

## Public API and Backward Incompatible Changes

#### New property in WordProcessingEditOptions

Implementing a EDITORNET-1467 ticket has a result in form of a new public property in the `GroupDocs.Editor.Options.WordProcessingEditOptions` class:

```csharp
public string InputControlsClassName {get; set;}
```

You can find more info about this feature in the article "[Adding class name to input controls]({{< ref "editor/net/developer-guide/advanced-usage/working-with-wordprocessing-documents/adding-class-name-to-input-controls.md" >}})".

#### New enum and property in TextEditOptions

Implementing a EDITORNET-1512 ticket caused a new enum `GroupDocs.Editor.Options.TextDirection`:

```csharp
public enum TextDirection
{
	LeftToRight,
	RightToLeft,
	Auto
}
```

This enum is now used in the `GroupDocs.Editor.Options.TextEditOptions` class:

```csharp
public TextDirection Direction {get; set;}
```

#### New enum value in PdfCompliance enum

The EDITORNET-1505 improvement is represented by a new value in the `GroupDocs.Editor.Options.PdfCompliance`:

```csharp
public enum PdfCompliance
{
	...
	Pdf17,
	...
}
```
