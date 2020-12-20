---
id: groupdocs-editor-for-net-20-12-release-notes
url: editor/net/groupdocs-editor-for-net-20-12-release-notes
title: GroupDocs.Editor for .NET 20.12 Release Notes
weight: 50
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 20.12{{< /alert >}}

GroupDocs.Editor for .NET version 20.12 provides one new minor feature, which has an impact on public API, two improvements and a set of different bugfixes. It is worth to mention that this new feature _doesn't break a backward compatibility_, but only introduces one new public type, so existing client code is fully compatible for this release. All of these are described in detail below.

## New features

### New public class OtfFont

Before version 20.12 the GroupDocs.Editor was not able to process the OTF (Open Type Format) fonts: it was not able to obtain them from input documents and export into resultant documents. If occured, such fonts were ignored. Starting from version 20.12 there is a full support of Open Type fonts, including new public class `GroupDocs.Editor.HtmlCss.Resources.Fonts.OtfFont`. So now, if input Wordprocessing document contains an OTF font, this font will be properly exported to the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) and HTML, and finally properly imported back to the output WordProcessing document.

## Improvements

### Support of new HTML elements

In GroupDocs.Editor version 20.12 there was added a support of a _BASE_ HTML element as well as all Definition based elements:
* DL (Definition List)
* DT (Definition Term)
* DD (Definition Details)

Now they are fully supported and their presence in HTML markup will not cause an exception.


## Bugs

GroupDocs.Editor version 20.12 contains big amount of bugfixes, which address different exceptions in different modules of GroupDocs.Editor, including WordProcessing, Spreadsheet, and Presentation.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1944 | Investigate and implement OTF font | New feature |
| EDITORNET-1940 | Add support of BASE element | Improvement |
| EDITORNET-1945 | Add support of Description HTML elements | Improvement |
| EDITORNET-1778 | Parse error - end tag 'span', that is located on position '8591-8597', doesn't match the last unclosed start tag 'td' | Bug |
| EDITORNET-1807 | Node type of 'Aspose.Slides.xxx' currently are not supported | Bug |
| EDITORNET-1818 | Exception during table processing | Bug |
| EDITORNET-1856 | Only 'phrasing' content is permitted for the 'SPAN' element, while specified element 'DIV' has content category 'Flow' | Bug |
| EDITORNET-1910 | Exception when editing ODT files (empty image in Shape) | Bug |
| EDITORNET-1913 | Only 'phrasing' content is permitted for the 'heading (H1)' element | Bug |
| EDITORNET-1935 | Cannot find a Wingding code 8211 | Bug |
| EDITORNET-1904 | Incorrect page count | Bug |
| EDITORNET-1946 | SVG is not embedding into HTML during serialization | Bug |
| EDITORNET-1848 | Exception System.AccessViolationException in the GroupDocs.Editor.Cells.CellsToHtml while iterate Worksheets | Bug |
| EDITORNET-1948 | Failed converting to Word images with base64 SVG | Bug |

## Public API and Backward Incompatible Changes

As it was described in "New Features" section above, there is one completely new public class in the GroupDocs.Editor API, which don't break a backward compatibility.

* `GroupDocs.Editor.HtmlCss.Resources.Fonts.OtfFont` class.
