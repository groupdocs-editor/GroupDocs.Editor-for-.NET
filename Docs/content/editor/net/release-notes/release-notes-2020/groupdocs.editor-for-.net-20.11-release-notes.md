---
id: groupdocs-editor-for-net-20-11-release-notes
url: editor/net/groupdocs-editor-for-net-20-11-release-notes
title: GroupDocs.Editor for .NET 20.11 Release Notes
weight: 52
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 20.11{{< /alert >}}

GroupDocs.Editor for .NET version 20.11 provides one new minor feature, which has an impact on public API, two improvements and a set of different bugfixes. It is worth to mention that this new feature _doesn't break a backward compatibility_, but only introduces one new public type, so existing client code is fully compatible for this release. All of these are described in detail below.

## New features

### New public class EmfImage

Before version 20.10 the GroupDocs.Editor was not able to process EMF (Enhanced MetaFile) vector images internally, so when such image was present in some input document like DOCX or PPTX, the exception was thrown. Starting from the version 20.11 a support of EMF format was added, and an appropriate public class `GroupDocs.Editor.HtmlCss.Resources.Images.Vector.EmfImage` was introduced. So now EMF is fully supported in input documents.

## Improvements

### Passing correct border parameters through roundtrip

WordProcessing documents can contain variety of different borders with very different parameters. Borders may have different colors, line type, width, they may be composed of several different lines, nested into each other, and so on. Borders may be present in tables (between cells), around whole paragraphs, around specific words and sentences inside paragraphs, as the dividing lines between consecutive paragraphs, and so on. The problem is that WordProcessing format describes a much higher variety of borders compared to HTML and CSS. So there is a very common situation when input document (let's say, DOCX) with complex borders is converted to HTML (in order to edit it inside WYSIWYG-editor), but then it is unable to reproduce the original borders in output DOCX, because they were lost during DOCX->HTML/CSS->DOCX conversion (also called a _roundtrip_), because HTML/CSS doesn't support such borders.

Before version 20.11 it was a known and inevitable problem. However, in version 20.11 GroupDocs.Editor exports detailed border metadata into the HTML/CSS markup during forward conversion and then reproduces the exact border parameters during backward conversion. So this problem is finally solved.

### Passing correct padding parameters through roundtrip

Same as the passing, preserving, and restoring the correct border parameters through roundtrip, the same problem was present also with paddings, which is a distance from the border line to the content (text in most cases). Starting from version 20.11 a GroupDocs.Editor passes correct padding values during forward conversion from input WordProcessing to the HTML/CSS and then restores these padding values during backward conversion from HTML/CSS to the output WordProcessing.

## Bugs

GroupDocs.Editor version 20.11 contains lots of bugfixes, which address different exceptions in different modules of GroupDocs.Editor, including WordProcessing, Spreadsheet, and Presentation.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1893 | Implement support of EMF resource with appropriate class EmfImage | New feature |
| EDITORNET-1906 | Passing correct border parameters through roundtrip | Improvement |
| EDITORNET-1912 | Passing correct padding parameters through roundtrip | Improvement |
| EDITORNET-1603 | Fix issue with incorrect border width | Bug |
| EDITORNET-1855 | An attempt was made to place the file pointer before the beginning of the file. | Bug |
| EDITORNET-1859 | Invalid column index. | Bug |
| EDITORNET-1889 | Internal error - 'Inherit' field is NULL for the '' type | Bug |
| EDITORNET-1897 | Exception while converting previously reconverted DOC to HTML | Bug |
| EDITORNET-1898 | Image is not JPEG | Bug |
| EDITORNET-1900 | Object reference not set to an instance of an object. | Bug |
| EDITORNET-1905 | An entry with the same key already exists | Bug |
| EDITORNET-1911 | Unable to cast object of type 'Aspose.Words.EditableRangeStart' to type 'Aspose.Words.Run'. | Bug |

## Public API and Backward Incompatible Changes

As it was described in "New Features" section above, there is one completely new public class in the GroupDocs.Editor API, which don't break a backward compatibility.

* `GroupDocs.Editor.HtmlCss.Resources.Images.Vector.EmfImage` class.
