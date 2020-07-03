---
id: groupdocs-editor-for-net-19-12-release-notes
url: editor/net/groupdocs-editor-for-net-19-12-release-notes
title: GroupDocs.Editor for .NET 19.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 19.12{{< /alert >}}

## Major Features

GroupDocs.Editor for .NET version 19.12 contains two main features:

*   Expanded features in the Format-representing structs, which includes parsing from file extension and enumerating over all formats within given format family.
*   New static factory in EditableDocument class, that allows to open EditableDocument from inner content of HTML->BODY element and corresponding resource folder.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-1448 | Implement extension parsing for all formats | Feature |
| EDITORNET-1449 | Implement possibility to enumerate over all formats | Feature |
| EDITORNET-1422 | Implement parsing of inner content from HTML BODY element | Feature |
| EDITORNET-1423 | Implement resource fetching and parsing for HTML BODY content | Feature |
| EDITORNET-1420 | Improve formats-representing types | Improvement |
| EDITORNET-1421 | Implement better support of truncated markup | Improvement |
| EDITORNET-1419 | Bug with duplicated images in EditableDocument | Bug |
| EDITORNET-1418 | Internal error in Bookmark processor | Bug |
| EDITORNET-1414 | Fix bug with locked HTML resources | Bug |
| EDITORNET-1380 | Exception while getting DOCX document HTML | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Editor for .NET 19.12. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Editor which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

*   Two main features of GroupDocs.Editor for .NET version 19.12 are extended formats support and ability to create an EditableDocument instance from inner content of HTML->BODY element and corresponding resource folder.
    
    First feature is represented in public API by the next new public types and methods.
    
    | Type name | Member name | Responsibility |
    | --- | --- | --- |
    | WordProcessingFormats.AllEnumerable | N/A | Internal class, that enables enumeration over all formats within WordProcessingFormats  |
    | SpreadsheetFormats.AllEnumerable | N/A | Internal class, that enables enumeration over all formats within SpreadsheetFormats |
    | PresentationFormats.AllEnumerable | N/A | Internal class, that enables enumeration over all formats within PresentationFormats |
    | TextualFormats.AllEnumerable | N/A | Internal class, that enables enumeration over all formats within TextualFormats |
    | WordProcessingFormats  | All | Static readonly field, that returns an WordProcessingFormats.AllEnumerable instance |
    | SpreadsheetFormats  | All | Static readonly field, that returns an SpreadsheetFormats .AllEnumerable instance |
    | PresentationFormats  | All | Static readonly field, that returns an PresentationFormats .AllEnumerable instance |
    | TextualFormats  | All | Static readonly field, that returns an TextualFormats .AllEnumerable instance |
    | WordProcessingFormats | FromExtension | Static method, that parses a string and returns appropriate WordProcessing format |
    | SpreadsheetFormats | FromExtension | Static method, that parses a string and returns appropriate Spreadsheet format |
    | PresentationFormats | FromExtension | Static method, that parses a string and returns appropriate Presentation format |
    | TextualFormats | FromExtension | Static method, that parses a string and returns appropriate Textual format |
    
      
    Second feature is representing by only one new method in the EditableDocument class:
    
    ```csharp
    /// <summary>
    /// Static factory, that creates an instance of EditableDocument from a specified HTML markup,
    /// that doesn't contain an HTML header, but only inner markup of HTML BODY element, and from resources, located in the folder, specified by the full path
    /// </summary>
    /// <param name="htmlBodyContent">String, that contains raw HTML markup, which is located inside HTML->BODY element (without BODY itself),
    /// that should be parsed. Cannot be NULL, empty or invalid.</param>
    /// <param name="resourceFolderPath">Mandatory path to the folder with resources. All stylesheets, which are located in this folder, will be used.</param>
    /// <returns>New non-null instance of EditableDocument</returns>
    public static EditableDocument FromBodyMarkupAndResourceFolder(string htmlBodyContent, string resourceFolderPath)
    ```
