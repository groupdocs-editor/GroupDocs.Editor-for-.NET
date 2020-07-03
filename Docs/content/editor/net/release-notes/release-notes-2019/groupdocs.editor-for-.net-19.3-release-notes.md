---
id: groupdocs-editor-for-net-19-3-release-notes
url: editor/net/groupdocs-editor-for-net-19-3-release-notes
title: GroupDocs.Editor for .NET 19.3 Release Notes
weight: 9
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 19.3{{< /alert >}}

## Major features

This release contains two major features - support of XML format (import and editing only) and extended properties for processing plain text documents.

## Other features

Massive renaming in public API.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1109 | Develop XML module for opening, viewing and editing XML documents in GroupDocs.Editor | New Feature |
| EDITORNET-1110 | Implement ability to customize font settings and color for every distinct entity in XML structure | New Feature |
| EDITORNET-1111 | Develop option for specifying and applying the proper encoding | New Feature |
| EDITORNET-1112 | Develop mechanism for proper converting textual content into HTML | New Feature |
| EDITORNET-1080 | Implement extended text properties | New Feature |
| EDITORNET-1113 | Perform renaming of public API in accordance with new naming convention | Improvement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Editor for .NET 19.3. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Editor which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### XML support

From this version GroupDocs.Editor introduces support of XML format — ability to open, view and edit XML documents like any other previously supported. This includes special support and recognition of XML tags, attributes with their values, XML declarations, CDATA sections, DOCTYPE definitions, and some other XML-specific entities. Users are able to customize formatting for every part and entity of XML structure.

In order to open XML document simply pass it to the EditorHadler class as a stream, and also pass an instance of XmlToHtmlOptions class. It has the next structure:

```csharp
/// <summary>
/// Allows to specify custom options for loading XML (eXtensible Markup Language) documents
/// </summary>
public sealed class XmlToHtmlOptions : IDocumentLoadOptions
{
    /// <summary>
    /// Character encoding of the text document, which will be applied for its opening. By default is null - internal document encoding will be applied.
    /// </summary>
    public System.Text.Encoding Encoding { get; set; }
 
    /// <summary>
    /// Allows to enable the truncation of trailing whitespaces in the inner-tag text. 
    /// By default is disabled (false) - trailing whitespaces will be preserved.
    /// </summary>
    public bool TrimTrailingWhitespaces { get; set; }
     
    /// <summary>
    /// Responsible for representing the font of XML tags (angle brackets with tag names)
    /// </summary>
    public System.Drawing.Font XmlTagsFontSettings { get; set; }
 
    /// <summary>
    /// Defines color for the font of XML tags (angle brackets with tag names)
    /// </summary>
    public System.Drawing.Color XmlTagsFontColor { get; set; }
 
    /// <summary>
    /// Responsible for representing the font of attribute names
    /// </summary>
    public System.Drawing.Font AttributeNamesFontSettings { get; set; }
 
    /// <summary>
    /// Defines color for the font of attribute names
    /// </summary>
    public System.Drawing.Color AttributeNamesFontColor { get; set; }
 
    /// <summary>
    /// Responsible for representing the font of attribute values
    /// </summary>
    public System.Drawing.Font AttributeValuesFontSettings { get; set; }
 
    /// <summary>
    /// Defines color for the font of attribute values
    /// </summary>
    public System.Drawing.Color AttributeValuesFontColor { get; set; }
 
    /// <summary>
    /// Responsible for representing the font of inner-tag text
    /// </summary>
    public System.Drawing.Font InnerTextFontSettings { get; set; }
 
    /// <summary>
    /// Defines color for the font of inner-tag text
    /// </summary>
    public System.Drawing.Color InnerTextFontColor { get; set; }
 
    /// <summary>
    /// Responsible for representing the font of HTML comments (including pair of opening and closing tags)
    /// </summary>
    public System.Drawing.Font HtmlCommentsFontSettings { get; set; }
 
    /// <summary>
    /// Defines color for the font of HTML comments (including pair of opening and closing tags)
    /// </summary>
    public System.Drawing.Color HtmlCommentsFontColor { get; set; }
 
    /// <summary>
    /// Responsible for representing the font of CDATA sections (including pair of opening and closing tags)
    /// </summary>
    public System.Drawing.Font CDataFontSettings { get; set; }
 
    /// <summary>
    /// Defines color for the font of CDATA sections (including pair of opening and closing tags)
    /// </summary>
    public System.Drawing.Color CDataFontColor { get; set; }
}
```

Let's review all these properties step-by-step:

1.  First property - *Encoding* - allows users to specify the character encoding of XML document as a System.Text.Encoding instance. Being not specified, the default encoding - UTF8 - will be applied.
2.  The *TrimTrailingWhitespaces* property, which is disabled by default, can apply mechanism for truncating the trailing whitespaces in the inner-tag textual content. Trailing spaces are invisible in HTML and in most cases are useless, so with this option you can easily eliminate them.
3.  The *XmlTagsFontSettings* option allows to specify font settings for the opening, closing and self-closed XML tags (including opening/closing brackets). If set to NULL, the default font settings will be applied.
4.  The *XmlTagsFontColor* option allows to specify font color for XML tags. If not set, the default color will be applied.
5.  The *AttributeNamesFontSettings* option allows to specify font settings for the attribute names within XML tags. If set to NULL, the default font settings will be applied.
6.  The **AttributeNamesFon*Color* option allows to specify font color for attribute names. If not set, the default color will be applied.
7.  The *AttributeValuesFontSettings* option allows to specify font settings for the attribute values within XML tags. If set to NULL, the default font settings will be applied.
8.  The **Attribute*Values*Fon*Color* option allows to specify font color for attribute values. If not set, the default color will be applied.
9.  The *InnerTextFontSettings* option allows to specify font settings for the inner text, which is inside and between XML tags. If set to NULL, the default font settings will be applied.
10.  The ***InnerText*Font*Color* option allows to specify font color for inner text. If not set, the default color will be applied.
11.  The *HtmlCommentsFontSettings* option allows to specify font settings for the HTML comments. If set to NULL, the default font settings will be applied.
12.  The ***HtmlComments**FontColor* option allows to specify font color for HTML comments. If not set, the default color will be applied.
13.  The *CDataFontSettings* option allows to specify font settings for the CDATA sections. If set to NULL, the default font settings will be applied.
14.  The **CData*FontColor* option allows to specify font color for CDATA sections. If not set, the default color will be applied.

Need to emphasize, that in this version of GroupDocs.Editor only import of XML documents is supported. You can open, view and edit them, but not save the edited document to the XML format. Alternatively, you can save it to one of WordProcessing formats, PDF, HTML or plain text (TXT). Support of export to XML will be present in future versions of GroupDocs.Editor.

### Enhanced text options

This version contains new advanced options for opening plain text (TXT) documents. The TextToHtmlOptions class now contains 3 new properties:

```csharp
/// <summary>
/// Allows to specify how numbered list items are recognized when document is imported from plain text format. The default value is true.
/// </summary>
/// <remarks>
/// If this option is set to false, lists recognition algorithm detects list paragraphs, when list numbers ends with either dot, right bracket or bullet symbols (such as "•", "*", "-" or "o").
/// If this option is set to true, whitespaces are also used as list number delimeters: list recognition algorithm for Arabic style numbering (1., 1.1.2.) uses both whitespaces and dot (".") symbols.
/// </remarks>
public bool DetectNumberingWithWhitespaces { get; set; }
 
/// <summary>
/// Gets or sets preferred option of a leading space handling. By default converts leading spaces to the left indent.
/// </summary>
public TextLeadingSpacesOptions LeadingSpacesOptions { get; set; }
 
/// <summary>
/// Gets or sets preferred option of a trailing space handling. By default truncates all trailing spaces.
/// </summary>
public TextTrailingSpacesOptions TrailingSpacesOptions { get; set; }
```

1.  *DetectNumberingWithWhitespaces*. By default GroupDocs.Editor tries to recognize lists in the content of the plain text files by several specific templates of list formatting. For example, several line breaks, which start with consecutive numbering or same bullet characters, will be recognized as lists, and output HTML will have the corresponding list structure. However, in several scenarios, it is hard to determine whether some text configuration implies list or not. This option enables list recognition, when list item marks are succeeded not only by special bullet marks, but also with whitespaces.
2.  *LeadingSpacesOptions*. This option allows to choose one of three available strategies of processing leading spaces in text lines. By default leading whitespaces are converted to the text indent in the resultant HTML document. Other options are: preserve these spaces without touching them or completely remove this.
3.  *TrailingSpacesOptions*. This option is almost same as previous one with one exception — there are no indents for trailing whitespaces in text lines. So, by default, all trailing whitespaces are completely truncated, as they are invisible and almost useless in the resultant HTML. However, there is an ability to preserve them by selecting the corresponding value of *TextTrailingSpacesOptions* enum.

## Public API changes

There were two major changes in the public API.

First of all, there was a massive renaming of namespaces and types to meet new GroupDocs naming convention. In general, now Words is transformed to WordProcessing, and Cells to Spreadsheet.

Secondly, all options were moved to the GroupDocs.Editor.Options namespace.

1.  GroupDocs.Editor.Words.HtmlToWords.DocumentProtection -> GroupDocs.Editor.Options.DocumentProtection
2.  GroupDocs.Editor.Words.HtmlToWords.WordProcessingSaveOptions -> GroupDocs.Editor.Options.WordProcessingSaveOptions
3.  GroupDocs.Editor.Words.HtmlToWords.DocumentProtectionType -> GroupDocs.Editor.Options.DocumentProtectionType
4.  GroupDocs.Editor.Words.HtmlToWords.WordFormats-> GroupDocs.Editor.Options.WordProcessingFormats
5.  GroupDocs.Editor.Words.WordsToHtml.WordToHtmlOptions-> GroupDocs.Editor.Options.WordProcessingToHtmlOptions
6.  GroupDocs.Editor.Cells.CellsToHtml CellsToHtmlOptions -> GroupDocs.Editor.Options.SpreadsheetToHtmlOptions
7.  GroupDocs.Editor.Cells.HtmlToCells.CellsSaveOptions \-> GroupDocs.Editor.Options.SpreadsheetSaveOptions
8.  GroupDocs.Editor.Cells.HtmlToCells.WorksheetProtection -> GroupDocs.Editor.Options.WorksheetProtection
9.  GroupDocs.Editor.Cells.HtmlToCells.CellFormats -> GroupDocs.Editor.Options.SpreadsheetFormats
10.  GroupDocs.Editor.Cells.HtmlToCells.WorksheetProtectionType -> GroupDocs.Editor.Options.WorksheetProtectionType
