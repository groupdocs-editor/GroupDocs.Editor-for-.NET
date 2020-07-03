---
id: groupdocs-editor-for-net-19-4-release-notes
url: editor/net/groupdocs-editor-for-net-19-4-release-notes
title: GroupDocs.Editor for .NET 19.4 Release Notes
weight: 8
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 19.4{{< /alert >}}

## Major features

This release contains one major feature - heavily expanded XML processing with new features and options.

## Other features

Improvement in existing WordProcessing module — support of double slanted diagonal borders in table cells.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1126 | Develop URI detection mechanism | New Feature |
| EDITORNET-1125 | Implement XML correctness algorithm | New Feature |
| EDITORNET-1124 | Implement quote type option | New Feature |
| EDITORNET-1123 | Implement email and URI validation in XML attributes | New Feature |
| EDITORNET-1122 | Fix detected issues in XML module | Bug |
| EDITORNET-1150 | Implement double slanted diagonal lines in table cell | Improvement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Editor for .NET 19.4. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Editor which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Improved and expanded XML module

New XML module was the main feature of the previous 19.3 release of GroupDocs.Editor. Now, with 19.4 version, this module was heavily expanded and improved. We have added 4 new features along with corresponding public options to the public API. They are listed below.

#### XML Correctness Option

XML format has strict rules, and every XML document should follow them. However not all XML documents are well-formed. Some documents may be broken in different way:

*   Missing XML declaration
*   Missing of single root tag
*   Missing opening tags
*   Missing closing tags
*   Overlapping tags
*   Unclosed brackets
*   And much more...

From its first release in 19.3 version the XML converter was able to show any XML document with any kind of errors (unlike most of XML parsers, that throw an exception on first occurred error). However, with 19.4 release, GroupDocs.Editor is able not only to show broken XML document, but also to fix it! It is possible to fix all previously listed errors: close unclosed tags, remove unopened tags, fix overlapped tags and so on.

This feature is represented as an option, which is located in the `XmlToHtmlOptions` class. It has the next form:

```csharp
/// <summary>
/// Allows to enable or disable mechanism for fixing corrupted XML structure. By default is disabled (false).
/// </summary>
/// <remarks>By default only proper valid well-formed XML documents are acceptable. When this option is enabled, GroupDocs.Editor will try to fix corrupted XML structure if possible.</remarks>
public bool FixIncorrectStructure { get; set; }
```

By default it is disabled — XML correctness algorithm is not applied.

#### URI recognition and processing

In previous version XML converter processed any URIs as an ordinary text. It was not able to recognize the URI in text block and process it accordingly. So, when converted to HTML, such links were represented as a usual text, and you were not able to edit or follow them. But with 19.4 release we're introducing a new feature: URI recognizer. This mechanism scans every piece of text between XML tags and also every value of every attribute, searching for URIs. If found, links are processed in specific way, and in the resultant HTML they are present inside the A tag, so you can follow them and edit as a link, not as a text.

This feature is represented as an option, which is located in the `XmlToHtmlOptions` class. It has the next form:

```csharp
/// <summary>
/// Allows to enable URI recognition algorithm
/// </summary>
public bool RecognizeUris { get; set; }
```

By default it is disabled — URIs will not be recognized. But take a note, that enabling URI detection will significantly decrease the performance, because the detection algorithm should check every piece of text over all of the document.

#### Email recognition in attribute values

Along with URI recognition, 19.4 release also contains a mechanism for detection and processing of the email addresses. However, unlike the URI detection, it scans only values of XML attributes, which are parts of XML elements. Like with URI detection, once valid email address is found, in the resultant HTML markup it will be present as a usual link (with A tag), which you can follow or edit.

This feature is represented as an option, which is located in the `XmlToHtmlOptions` class. It has the next form:

```csharp
/// <summary>
/// Allows to enable recognition algorithm for email addresses in attribute values
/// </summary>
public bool RecognizeEmails { get; set; }
```

And, as in all previous cases, this option is disabled by default.

#### Quote type selection

XML standard defines two quote types, that can be used for delimiting attribute values from surrounding content: single quote (U+0027 APOSTROPHE character) and double quote (U+0022 QUOTATION MARK character). With 19.4 release it is possible to forcibly apply specific quote type, that will be present in resultant HTML. So it is no matter, which exact quotes are present in the input XML — resultant HTML will contain unified quotes of a single type.

This feature is represented as an option, which is located in the `XmlToHtmlOptions` class. It has the next form:

```csharp
/// <summary>
/// Allows to specify quote type (single or double quotes) for attribute values. Double quotes are default.
/// </summary>
public HtmlCss.Serialization.QuoteType AttributeValuesQuoteType { get; set; }
```

By default double quotes will be apllied.

### Double slanted lines in table cells

Word Processing format along with MS Word allow to draw slanted diagonal lines in table cells. Previously GroupDocs.Editor supported such lines, but only when there is only one diagonal line in table cell, and was unable to process a situation, when two lines are present in one cell simultaneously. Now the Word Processing module was improved, and double slanted lines are converted to the HTML fully correct. This improvement doesn't require any code change and has no affect on any of options or API.
