---
id: groupdocs-editor-for-net-20-9-release-notes
url: editor/net/groupdocs-editor-for-net-20-9-release-notes
title: GroupDocs.Editor for .NET 20.9 Release Notes
weight: 55
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 20.9{{< /alert >}}

GroupDocs.Editor for .NET version 20.9 contains mostly bug fixes, but also a list of different improvements, which, however, don't alter the public API. All of them are described below.

## Improvements

### Added new list item numeric markers

Microsoft Word and Office Open XML format support a lot of different list item numeric markers, not only usual Arabic or Roman numbers and Latin letters. GroupDocs.Editor supports only a subset of these markers. However, starting from 20.9, this list of supported markers was expanded. In particular, 3 new numeric markers are now supported:
1. Devanagari, also known as Hindi
2. Hindi
3. Hebrew

### Support of citation blocks

Office Open XML documents can contain such elements as citation blocks, which can have different adjustable appearance and behavior. Prior version 20.9 their presence in the document caused an exception; now they are fully supported.

### Support of several new fields

Started from version 20.9 the GroupDocs.Editor fully supports PAGEREF and BIBLIOGRAPHY fields, while before this version their presence in the document caused an exception. Also now are supported multi-paragraph FORMTEXT and REF fields, while previously they were supported only in single-paragraph configuration (when field spans inside some particular paragraph).

## Bugs

GroupDocs.Editor version 20.9 contains lots of bug-fixes, related mostly to exception during editing documents of different formats by transforming them to the EditableDocument instance.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1801 | Add support of a Devanagari Hindi ordered list markers | Improvement |
| EDITORNET-1810 | Add support of a PAGEREF field | Improvement |
| EDITORNET-1811 | Add support of Citation SDT node and corresponding field | Improvement |
| EDITORNET-1815 | Add support of BIBLIOGRAPHY field | Improvement |
| EDITORNET-1816 | Add support of Kanji and Hebrew list markers | Improvement |
| EDITORNET-1802 | Fix ArgumentException with sample file | Bug |
| EDITORNET-1803 | Fix InvalidCastException with sample file | Bug |
| EDITORNET-1804 | NullReferenceException occurs on empty footnote | Bug |
| EDITORNET-1805 | Internal error - Node type 'StructuredDocumentTag' is not supported in the 'ProcessUnknownSdt' method of SdtProcessor at this moment | Bug |
| EDITORNET-1806 | Invalid format | Bug |
| EDITORNET-1808 | This operation is permitted - SELECT element cannot have child text nodes | Bug |
| EDITORNET-1809 | An item with the same key has already been added. | Bug |
| EDITORNET-1813 | Object reference not set to an instance of an object. | Bug |
| EDITORNET-1814 | Xml file type fails to edit | Bug |
| EDITORNET-1817 | Multi-paragraph FORMTEXT fields are not supported | Bug |
| EDITORNET-1820 | Multi-paragraph REF fields are not supported | Bug |

## Public API and Backward Incompatible Changes

No new types members or changes in existing types/members in public API.


