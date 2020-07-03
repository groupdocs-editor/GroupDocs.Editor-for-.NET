---
id: groupdocs-editor-for-net-17-9-0-release-notes
url: editor/net/groupdocs-editor-for-net-17-9-0-release-notes
title: GroupDocs.Editor for .NET 17.9.0 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 17.9.0{{< /alert >}}

## Major Features

This is the second version of GroupDocs.Editorfor .NET. There are 6 major new features and 4 big improvements in existing features:

*   Support of bidirectional (right-to-left) content in paragraphs, tables and lists.
*   Ability for user to export language (locale) metadata into the HTML document for spellcheck support during backward conversion.
*   Ability for user to extract font resources into the HTML document with different options, which allow to adjust, which font resources should be extracted.
*   Now it is possible for user to save the output document to the PDF format.
*   Support of background textures and shadings in paragraphs and table cells.
*   SVG raster image format as new supportable TML resource along with raster images.
*   Significantly improved footnotes and endnotes processing and preserving their state after backward conversion.
*   Greatly improved field processing.
*   Improved processing of paragraph styles and formatting, added support of words underlining.
*   Added support of nested SDT nodes, improved their processing in general.  
      
    

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-698 | Implement saving into PDF | New Feature |
| EDITORNET-707 | Implement ability to set password on output PDF | New Feature |
| EDITORNET-680 | Add support of spell check in GroupDocs.Editor | New Feature |
| EDITORNET-671 | Implement support of bidirectional text | New Feature |
| EDITORNET-697 | Implement bidirectional support of tables | New Feature |
| EDITORNET-695 | Implement bidirectional support for lists | New Feature |
| EDITORNET-622 | Support font extraction from Words document | New Feature |
| EDITORNET-551 | Add support of table textures | Improvement |
| EDITORNET-670 | Implement shading textures and color in text runs | Improvement |
| EDITORNET-604 | Implement new types of fields | Improvement |
| EDITORNET-605 | Implement support of paragraph foreground and background color | Improvement |
| EDITORNET-606 | Implement Underline.Words feature | Improvement |
| EDITORNET-650 | Completely rework the recognition and validation of TTF font resources | Improvement |
| EDITORNET-673 | Fill missing xml-doc comments for public namespaces, classes, properties and methods | Bug |
| EDITORNET-601 | Fix bug in FontProcessor | Bug |
| EDITORNET-608 | Fix bug with duplicate CSS declarations | Bug |
| EDITORNET-607 | Fix issue with single-child SDTs | Bug |
| EDITORNET-632 | Fix bug in font parser | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Editor for .NET 17.9.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Editor which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Support of bidirectional (Right-to-Left) content

Now GroupDocs.Editor supports bidirectional content: paragraphs, lists and tables. Mixed content is also supported and properly handled. In general, GroupDocs.Editor tries to mimic behavior of MS Word and forces right alignment for all RTL content, this also affects columns order in tables, alignment in table cells, indents in lists, etc. This feature works as it is and doesn’t require user involvement.

### Export language metadata

Now GroupDocs.Editor has a new option in the "WordToHtmlOptions" class: ExportLanguageInformation. By default it is disabled, but if enabled, GroupDocs.Editor extracts information about locale for each piece of the document and exports it to the resultant HTML markup in a form of "lang" HTML attributes. This is especially useful for multi-language documents, where different paragraphs or even text in one sentence may contain words on different languages.

When saving such HTML-document back to the Words format, this metadata will be written to the output document. As a result, when opening in the MS Word or other software, all languages will be preserved and properly handled; otherwise, the MS Word tries to recognize the language by itself and often fails to do this 100% correct.

This option also may be useful for some spell-checking plugins for HTML editors, which can handle multi-language documents through "lang" HTML attributes.

### Export fonts

Now the "WordToHtmlOptions" class contains a new "ExtractFontOption" member, which allows to extract font regarding specified option. By default GroupDocs.Editor doesn’t extract any font resources from input Words document. But with this option it is possible to specify, which font resources should be extracted:

1.  Only those, which are embedded inside input document, regardless of what they are: custom or system. In other words, all font resources, which are embedded inside Words document, will be extracted.
2.   Only embedded, but excluding the system. As in previous case, GroupDocs.Editor extracts embedded fonts. But at this time it analyzes each font and tries to figure out, is it a system font or not, and extracts font, only if it is not a system. GroupDocs.Editor obtains a list of system fonts by looking into Windows Registry and system folders on the machine, where it is launched. 
3.  Extract all fonts, which are used in the input Words document. First of all GroupDocs.Editor extracts all embedded fonts from the document. Then it analyzes, which fonts are used by the document. If this set of embedded font resources doesn't cover all used fonts in the document, or is empty, converter tries to extract these font resources from system, by using Windows Registry and system folders. 

Along with this feature a support of different font types was also improved.

### Export to PDF

In the previous version users were able to select the type of saved document only in range of Words format family (DOC, DOCX, RTF, ODT etc.). Now it is possible to save the document in the PDF format. In order to do this user needs to pass the "PdfSaveOptions" instance into the "EditorHandler.ToDocument" method. Users are also able to specify the password: if it is set, the output PDF will be password-protected and encoded with RC4 encryption algorithm.

### Support of background textures and shadings

With Words format and MS Word it is possible to apply a texture of specified type, shading and color to every piece of text or distinct table cell. Now GroupDocs.Editor supports this feature and appropriately represents these text effects in HTML document by using background colors and gradients.

### Support of SVG image format

Previous version of GroupDocs.Editor supported only raster image formats: JPEG, PNG, BMP, GIF, ICO. Now it also supports a vector format SVG. As a result, the public API was slightly modified. All types, which represent raster formats, were moved from "GroupDocs.Editor.HtmlCss.Resources.Images" namespace into the "GroupDocs.Editor.HtmlCss.Resources.Images.Raster" namespace, while "SvgImage" class is located in the "GroupDocs.Editor.HtmlCss.Resources.Images.Vector" namespace.

### Other features and improvements

A lot of smaller features and improvements also were implemented in the 17.9.0 version of GroupDocs.Editor. All of them are "internal", i.e. they don’t affect the public API:

1.  Significantly improved footnote, endnote processing and preserving their state, when converting back from HTML to Words. 
2.  Greatly improved the field processing and conversion algorithms. 
3.  Improved processing of the paragraph styling, including backgrounds, words underlining, etc. 
4.  Implemented handling of nested SDT nodes, improving SDT processing in general. 
5.  A lot of other bug fixes.

### Other public API changes

Along with listed above, we replaced an interface "GroupDocs.Editor.HtmlCss.Resources.Fonts.IFontResource" with abstract class "GroupDocs.Editor.HtmlCss.Resources.Fonts.FontResourceBase".

### New demo project, which utilizes CKEditor

We prepared a completely new demo project, which uses CKEditor as GUI for GroupDocs.Editor library. This project is much more feature-rich and mature, than our previous one, which has used TinyMCE.
