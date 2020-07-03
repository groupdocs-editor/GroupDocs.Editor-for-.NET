---
id: groupdocs-editor-for-net-19-5-release-notes
url: editor/net/groupdocs-editor-for-net-19-5-release-notes
title: GroupDocs.Editor for .NET 19.5 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 19.5{{< /alert >}}

## Major features

The 19.5 release contains three major features - credits support in Metered license, new paginal mode in WordProcessing module and improved rendering quality of WordProcessing format family.

## Other features

Minor internal improvements and fixes.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1189 | Implement various text effects | New Feature |
| EDITORNET-1185 | Implement new Metered support | New Feature |
| EDITORNET-1208 | Develop paginal mode in WordProcessing module | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Editor for .NET 19.5. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Editor which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Metered credits

GroupDocs.Editor already supports Metered licensing system, that allows customers to buy amount of processed bytes, that are counted when documents are processed. Now, with new Metered system, it was added a new credits concept: each document operation, along with consumed bytes, also consumes one credit. The amount of already used credits can be retrieved through new static method "GetConsumptionCredit" in the *Metered* class:

```csharp
/// <summary>
/// Retrieves amount of used credits
/// </summary>
/// <returns>Number of already used credits</returns>
public static decimal GetConsumptionCredit()
```

## Support of complex text effects in WordProcessing module

Now, when working with WordProcessing format family (DOCX, RTF, ODT etc.), GroupDocs.Editor supports complex text effects, that includes text with next applied effects:

*   Shadow
*   3D effect
*   Outline
*   Glow
*   Engrave
*   Emboss

This feature doesn't require any of actions from user side, it is always enabled and can be observed, when the document with such text effects is processed.

## Paged mode in WordProcessing module

Before 19.5 release, there was only one mode in WordProcessing module — float mode, when WordProcessing documents were converted to the pageless HTML, where page division was absent. Starting from 19.5 version, WordProcessing options class contains new *paged* (also called *paginal*) mode, which, if enabled, produces HTML markup, optimized and adjusted for per-page edit. When document is converted to HTML and this mode is enabled, then it is much more ease to enable paged edit in any of WYSIWYG-editors like CKEditor or TinyMCE.

In order to enable this mode (by default it is disabled), need to set a boolean flag to *true* in the "WordProcessingToHtmlOptions" options:

```csharp
/// <summary>
/// Allows to enable or disable pagination in the resultant HTML document. By default is disabled (false).
/// </summary>
public bool EnablePagination { get; set; }
```

When document was edited in the WYSIWYG-editor and is passed back to the GroupDocs.Editor for converting from HTML to the output format, it also required to set boolean flag to *true* (by default it is disabled) in the "WordProcessingSaveOptions":

```csharp
/// <summary>
/// Allows to enable or disable pagination which will be used for saving the document. 
/// If the original document was opened and edited in pagination mode, this option also should be enabled. By default is disabled.
/// </summary>
public bool EnablePagination { get; set; }
```

## XML Highlight Options

There is one significant public API change in the "XmlToHtmlOptions" class. Set of all options, related to XML highlighting (font and color settings for each entity in XML document) was moved from "XmlToHtmlOptions" class to the distinct "XmlHighlightOptions" class. In turn, "XmlToHtmlOptions" class now contains new property "HighlightOptions":

```csharp
/// <summary>
/// Allows to adjust the highlighting, that will be applied to the XML structure, when it is represented in HTML.
/// By default is NULL — default highlighting is applied.
/// </summary>
public XmlHighlightOptions HighlightOptions { get; set; }
```
