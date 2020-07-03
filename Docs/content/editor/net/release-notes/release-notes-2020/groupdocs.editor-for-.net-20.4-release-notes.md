---
id: groupdocs-editor-for-net-20-4-release-notes
url: editor/net/groupdocs-editor-for-net-20-4-release-notes
title: GroupDocs.Editor for .NET 20.4 Release Notes
weight: 70
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 20.4{{< /alert >}}

## Major Features

GroupDocs.Editor for .NET version 20.4 contains a lot of new features, improvements, bug fixes and performance speed-up in different tasks and scenarios. It also includes new public members and options, which are described below.

### New ability to insert edited slide into existing presentation

Starting from version 20.4, GroupDocs.Editor is able not only to generate a presentation with single slide, but insert new edited slide into existing presentation. In order to make this feature public the two new properties were added to the [`PresentationSaveOptions`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions) class: integer [`SlideNumber`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/slidenumber) and boolean flag [InsertAsNewSlide](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/insertasnewslide).

There is a special article "[Inserting edited slide into existing presentation]({{< ref "editor/net/developer-guide/advanced-usage/working-with-presentations/inserting-edited-slide-into-existing-presentation.md" >}})", which explains exactly this specific feature.

### Paginal mode for PDF

Starting from version 20.4 a paginal mode becomes available for PDF conversion, which means that input WordProcessing document, which was edited in paginal mode, can be saved in PDF format in paginal mode too. Corresponding boolean flag [EnablePagination](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/pdfsaveoptions/properties/enablepagination) was added to the [PdfSaveOptions](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/pdfsaveoptions) class. Section "Paginal mode in PDF" in the "[Float and paginal modes]({{< ref "editor/net/developer-guide/advanced-usage/working-with-wordprocessing-documents/float-and-paginal-modes.md" >}})" article describes this new feature.

### Support of TIFF images

In very rare cases WordProcessing documents can contain raster images in TIFF format. Prior version 20.4 such images were unsupported and, when encountered, exception was thrown. Now GroupDocs.Editor supports TIFF format, and not only for WordProcessing documents, but also for public API too: corresponding class `TiffImage` was added to the `GroupDocs.Editor.HtmlCss.Resources.Images.Raster` namespace, along with the new enum value '`Tiff`' in the `GroupDocs.Editor.HtmlCss.Resources.Images.ImageType` enum.

### Support of repeatable table header

WordProcessing format supports a table-related feature called "*Repeatable table header*" — when table is so huge that it spans across several pages, it is possible to mark its header as repeatable, so it duplicates on top of every page, which is occupied by the table. Before version 20.4 GroupDocs.Editor hasn't supported this feature: when opening document for edit and saving back to the WordProcessing such header was lost. However, starting from version 20.4 it is fully supported. This improvement works by default and has no any public options.

### Support ActiveX checkbox

ActiveX is an obsolete technology, which is however still supported in new OOXML (\*.DOCX) and old Microsoft Word Binary File Format (\*.DOC), and thus may be present in WordProcessing documents in extremely rare cases. In version before 20.4 all ActiveX components were rasterized and presented in HTML as PNG images. Started from version 20.4 we've improved support of ActiveX checkbox — now it, if occurred, will be rendered as fully functional valid HTML checkbox, with name, value, initial state and ability to set or unset it. This improvement doesn't touch public API.

### Support of user-installed fonts in .NET Standard 2.0 assembly on Windows 10/Server 2016

Previous version 20.3 contained a new feature — extended support of fonts, with new public option and ability to extract fonts from user-installed fonts folder on Windows 10/Server 2016. However, there was a known issue — .NET Standard 2.0 assembly of GroupDocs.Editor for .NET version 20.3 was not able to extract user fonts. In this new version 20.4 this issue is eliminated.

### Highly increased performance in several scenarios

For some specific scenarios, which includes working with fonts and processing specific documents with complex table content, the GroupDocs.Editor performance was increased up to 10-1000 times, depending on specific scenario and document.

### Plenty of fixed bugs

GroupDocs.Editor for .NET version 20.4 contains a lot of fixed serious bugs, which caused different exceptions, lack of features and improper rendering in different use-cases.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1541 | Ability to insert edited slide into existing presentation with substitution or injection by index | New feature |
| EDITORNET-1591 | Add support of paginal mode in backward HTML-to-PDF converter | New feature |
| EDITORNET-1609 | Add support of TIFF images | New feature |
| EDITORNET-1597 | Support repeat table header in HTML and backward converter | Improvement |
| EDITORNET-1607 | Implement ActiveX checkbox | Improvement |
| EDITORNET-1476 | Cannot convert HTML to WordProcessing with embedded PaginalStyle.css | Bug |
| EDITORNET-1530 | Error While Creating Edior instance with filepath Aurgument | Bug |
| EDITORNET-1581 | Opening a DOCX file throws Argument Exception | Bug |
| EDITORNET-1582 | Hanging while trying to open ODP document while detecting file format | Bug |
| EDITORNET-1583 | Small icons are always embedded into HTML as base64 when editing Spreadsheet document | Bug |
| EDITORNET-1584 | Fix bug in HTML parser when input HTML markup starts from empty string | Bug |
| EDITORNET-1588 | Fix performance degradation in font resource processor | Bug |
| EDITORNET-1589 | Fix bug with negative margin in tables | Bug |
| EDITORNET-1592 | 'Aspose.Words.Drawing.Shape' is not supported | Bug |
| EDITORNET-1596 | Name of the INPUT element cannot be NULL | Bug |
| EDITORNET-1598 | Only 'phrasing' content is permitted for the heading H2 | Bug |
| EDITORNET-1599 | Internal error - cannot find a 'FormField' node | Bug |
| EDITORNET-1602 | Content of the run is not represented by any of HTML elements | Bug |
| EDITORNET-1604 | Some controls missing in the output HTML and DOCX files | Bug |
| EDITORNET-1605 | Processing a particular DOCX file takes long time | Bug |
| EDITORNET-1640 | Add support of user-installed font with .NET Standard 2.0 assembly on Windows 10/Server 2016 | Bug |

## Public API and Backward Incompatible Changes

#### Two new properties in PresentationSaveOptions class

Implementing a EDITORNET-1541 ticket has a result in form of a two new public properties in the ``GroupDocs.Editor.Options.[`PresentationSaveOptions`](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions)` class:

```csharp
public int SlideNumber { get; set; }
public bool InsertAsNewSlide { get; set; }
```

#### One new property in PdfSaveOptions class

Implementing a EDITORNET-1591 ticket has a result in form of a one new public property in the `GroupDocs.Editor.Options.[PdfSaveOptions](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/pdfsaveoptions) class:

```csharp
public bool EnablePagination { get; set; }
```

#### New class TiffImage

As a result of EDITORNET-1609 ticket, the new class ``GroupDocs.Editor.HtmlCss.Resources.Images.Raster.`TiffImage` `` was added. It implements abstract class `RasterImageResourceBase`, like all other image types.

#### New value Tiff in ImageType enum

As a result of EDITORNET-1609 ticket, the `GroupDocs.Editor.HtmlCss.Resources.Images.ImageType` enum now contains a new '`Tiff`' value.
