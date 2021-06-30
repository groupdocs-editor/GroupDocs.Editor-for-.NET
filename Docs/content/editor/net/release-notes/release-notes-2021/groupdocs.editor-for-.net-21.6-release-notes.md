---
id: groupdocs-editor-for-net-21-6-release-notes
url: editor/net/groupdocs-editor-for-net-21-6-release-notes
title: GroupDocs.Editor for .NET 20.6 Release Notes
weight: 70
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 21.6{{< /alert >}}

GroupDocs.Editor for .NET version 21.6 presents several small but useful new features, several improvements and a lot of different bugfixes; all of these are described below. As in most of previous releases, these new features, which touch a public API, do not break a backward compatibility.

## New features

Version 21.6 of GroupDocs.Editor contains three new features, which are described below

#### New Mime property in IDocumentFormat inheritors

Now a public interface [Formats.IDocumentFormat](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/idocumentformat) contains a new public property: `string Mime`.

All implementing types — [WordProcessingFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/wordprocessingformats), [SpreadsheetFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/spreadsheetformats), [PresentationFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/presentationformats), [TextualFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/textualformats), and [EBookFormats](https://apireference.groupdocs.com/editor/net/groupdocs.editor.formats/ebookformats), — also contain this property. With this property users can easily obtain a MIME-code for a particular format. This may be very useful in web-applications, where it is required to write a MIME-code to the response along with document content.

#### New XmlContent property in SvgImage class

SVG image is in fact a text document in XML format. Before this moment it was not possible to obtain this XML content, because a [TextContent](https://apireference.groupdocs.com/editor/net/groupdocs.editor.htmlcss.resources.images.vector/svgimage/properties/textcontent) property of [GroupDocs.Editor.HtmlCss.Resources.Images.Vector.SvgImage](https://apireference.groupdocs.com/editor/net/groupdocs.editor.htmlcss.resources.images.vector/svgimage) class returns a base64-encoded content. Now we introduced a new property [XmlContent](https://apireference.groupdocs.com/editor/net/groupdocs.editor.htmlcss.resources.images.vector/svgimage/properties/xmlcontent), which returns exactly a described XML content of a particular SVG image.

#### Extended conversion methods for all vector images

Starting from version 21.6 the [VectorImageResourceBase](https://apireference.groupdocs.com/editor/net/groupdocs.editor.htmlcss.resources.images.vector/vectorimageresourcebase) class has a new abstract method `void SaveToPng(System.IO.Stream outputPngContent)`, so now all implementing types ([SvgImage](https://apireference.groupdocs.com/editor/net/groupdocs.editor.htmlcss.resources.images.vector/svgimage), [WmfImage](https://apireference.groupdocs.com/editor/net/groupdocs.editor.htmlcss.resources.images.vector/wmfimage) and [EmfImage](https://apireference.groupdocs.com/editor/net/groupdocs.editor.htmlcss.resources.images.vector/emfimage)) support conversion and saving to the PNG raster format.

Also [MetaImageBase](https://apireference.groupdocs.com/editor/net/groupdocs.editor.htmlcss.resources.images.vector/metaimagebase) abstract class has a new abstract method `void SaveToSvg(System.IO.Stream outputSvgContent`), which allows to save WMF or EMF to SVG. This is very useful, because WMF and EMF formats are commonly used in WordProcessing documents, but are not supported by the browsers; on the other hand, only SVG is supported in the Web.

## Improvements

GroupDocs.Editor for .NET version 21.6 contains several important improvements, which may be divided onto two parts: improvements related to SVG and to the Presentation module.

#### Presentation module

Now Presentation module preserves and supports some basic text formatting features when converrting document to and from HTML. This includes:
* Bold text
* Italic text
* Underline text
* Subscript
* Superscript
* Strikethrough text

Now, if some slide contains such text formatting, this formatting will be present in HTML and then in the resultant Presentation document.

#### Better SVG support

First of all, starting from version 21.6, HTML/CSS module supports an SVG content, inlined inside HTML markup. This means that if given HTML document contains SVG images, which are inlined directly inside HTML using SVG elements, GroupDocs.Editor will correctly process such markup with SVG images without throwing an exception.

Another improvement is related to the serialization: now, when [EditableDocument.GetEmbeddedHtml()](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editabledocument/methods/getembeddedhtml) method is invoked, all SVG files will not be encoded to the base64 and placed inside the values of "src" attributes of corresponding IMG elements, but rather will be stored in their native XML-compliant form, with SVG elements and so on.

## Bugs

GroupDocs.Editor version 21.3 contains big amount of bugfixes and performance improvements, which address different issues in different modules of GroupDocs.Editor, including WordProcessing, Spreadsheet, Presentation, and HTML processing.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-2092 | Add new property with MIME code for all supportable document formats | New feature |
| EDITORNET-2106 | Add ability to save SVG as PNG and improve public API in vector images | New feature |
| EDITORNET-2129 | Add new public property to obtain XML-content of SVG image | New feature |
| EDITORNET-2093 | Preserve most common text formatting features during roundtrip in Presentation module | Improvement |
| EDITORNET-2103 | SVG is not supported if is inlined into HTML markup as HTML element | Improvement |
| EDITORNET-2128 | Implement SVG inlining instead of base64 embedding | Improvement |
| EDITORNET-1989 | Images are not correctly transfered during conversion Markdown to Docx | Bug |
| EDITORNET-2066 | HTML-markup loose styles after file open and saving without changes | Bug |
| EDITORNET-2086 | OutOfMemoryException while converting specific Cells file to HTML | Bug |
| EDITORNET-2089 | Presentation: convert html to presentation without stylesheet | Bug |
| EDITORNET-2090 | Exception while import Presentation with missing load options | Bug |
| EDITORNET-2094 | Exception with message Font name cannot be NULL, empty or whitespaces\r\nParameter name: fontName during call editor.Edit() for RTF-file	 | Bug |
| EDITORNET-2096 | Unknown field is improperly processed | Bug |
| EDITORNET-2100 | Editor hang on PowerPoint files | Bug |
| EDITORNET-2101 | Image is not JPEG exception in Presentation | Bug |
| EDITORNET-2127 | Fix bug in markup parser | Bug |

## Public API and Backward Incompatible Changes

New public methods:

1. void VectorImageResourceBase.SaveToPng(System.IO.Stream outputPngContent)
2. void SvgImage.SaveToPng(System.IO.Stream outputPngContent)
3. void WmfImage.SaveToPng(System.IO.Stream outputPngContent)
4. void EmfImage.SaveToPng(System.IO.Stream outputPngContent)
5. void MetaImageBase.SaveToSvg(System.IO.Stream outputSvgContent)
6. void WmfImage.SaveToSvg(System.IO.Stream outputSvgContent)
7. void EmfImage.SaveToSvg(System.IO.Stream outputSvgContent)

New public properties:

1. string Formats.IDocumentFormat.Mime
2. string Formats.WordProcessingFormats.Mime
3. string Formats.SpreadsheetFormats.Mime
4. string Formats.PresentationFormats.Mime
5. string Formats.TextualFormats.Mime
6. string Formats.EBookFormats.Mime
7. string SvgImage.XmlContent
