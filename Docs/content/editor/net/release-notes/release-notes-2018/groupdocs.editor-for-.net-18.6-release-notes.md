---
id: groupdocs-editor-for-net-18-6-release-notes
url: editor/net/groupdocs-editor-for-net-18-6-release-notes
title: GroupDocs.Editor for .NET 18.6 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 18.6{{< /alert >}}

## Major Features

### Cells support

The main feature of the third version of GroupDocs.Editor for .NET is a Cells support. List of supported Cells formats:

*   XLSX
*   Excel97-2003 XLS
*   XLSM format, which enable macros
*   XLTX
*   XLTM format, which enable macros
*   CSV (Comma Separated Value) format
*   Tab delimited text file
*   ODS (OpenDocument Spreadsheet)
*   Excel 2003 XML format
*   XLSB (binary)

For text-based formats like CSV or tab-delimited GroupDocs.Editor allows to specify a separator, which can be a character or a string. For non-text-based formats GroupDocs.Editor allows to specify an opening password, if the input document is encrypted. Also it is possible to specify closing password during document saving; in that case output document will be password-protected.

With GroupDocs.Editor you need to specify, which tab should be edited; you cannot edit multiple tabs simultaneously. Tabs are specified via 0-based sequential index.

If GroupDocs.Editor works in a trial mode, you can select for edit only first two tabs. Also, there will be trial message on a top of the document and watermark on every single raster image within the document.

### Metered license

Second main feature in 18.6 is a Metered license support. Now you can use Metered license instead of standard one.

## Other Features

Along with Cells support we have slightly improved existing Words processing module.

*   Multiple consequent spaces are now processed much better in round-trip scenarios (open-edit-save cycle).
*   Improved space processing for bidirectional text.
*   Improved list processing in round-trip scenarios.
*   Other minor improvements.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-868 | Implement opening Cells documents and converting them to the HTML format | New Feature |
| EDITORNET-869 | Implement generating Cells documents from input HTML | New Feature |
| EDITORNET-870 | Add support of text-based Cells documents with ability to specify a separator | New Feature |
| EDITORNET-871 | Add support of opening encrypted documents with password | New Feature |
| EDITORNET-872 | Implement support of encrypting output Cells documents with setting a password | New Feature |
| EDITORNET-873 | Add support of Metered license system | New Feature |
| EDITORNET-874 | Improve processing of multiple consequent spaces in Words processing module for roundtrip scenarios | Improvement |
| EDITORNET-875 | Improve space processing for bidirectional text | Improvement |
| EDITORNET-876 | Improve list processing in roundtrip scenarios | Improvement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Editor for .NET 18.6. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Editor which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

1.  Now supports Metered license system along with usual licensing system from previous versions. This means that, instead of specifying license file, you can now switch GroupDocs.Editor from trial into licensing mode using Metered keys. Class *Metered* contains two methods and is responsible for setting keys.
    
    The first method allows to set a pair of public and private keys, while second allows you to obtain the quantity of already consumed data.
    
    
    
    ```csharp
    /// <summary>
    /// Provides methods to set metered key.
    /// </summary>
    public class Metered
    {
        /// <summary>
        /// Sets metered public and private key
        /// </summary>
        public void SetMeteredKey(string publicKey, string privateKey)
         
        /// <summary>
        /// Gets consumption quantity
        /// </summary>
        /// <returns>consumption quantity</returns>
        public static decimal GetConsumptionQuantity()
    }
    ```
    
2.  The main feature of GroupDocs.Editor 18.6 is a full support of all variety of Cells documents, which includes XLS, XLSX, CSV, ODS and others. The *EditorHandler*class supports new document formats automatically. This means that when you invoke *ToHtml* method with Cells document stream, GroupDocs.Editor will detect the type of the document properly. There are also option classes, which allow to tune up conversion process.  
      
    1\. The *CellsToHtmlOptions* class allows to specify opening password (in case if document is encrypted), worksheet index to open, and text options in case when input document is text-based (CSV, tab-delimited, semicolon-delimited etc.). There are several things that should be noted:  
    
    1.  Password is ignored, if iunput document isnot encrypted or is text-based.
    2.  Text options are ignored, if input document is not a text-based
    3.  Worksheet index is 0-based. If input Cells document contains only one tab, this option will be ignored. Default value is 0 (first tab). If specified index exceeds the number of all tabs, the exception will be thrown.
    4.  Text options class allows to specify a separator (delimiter), which can be an arbitrary character or string.  
          
        
    
    **CellsToHtmlOptions**
    
    ```csharp
    /// <summary>
    /// Allows to specify custom options for loading documents of all supportable Cells (Excel-compatible) formats
    /// </summary>
    public class CellsToHtmlOptions
    {
        public int WorksheetIndex { get; set; }
         
        public string Password { get; set; }
     
        public TextLoadOptions TextOptions { get; set; }
    }
    ```
    
      
    2. *TextLoadOptions* class contains only one string property, which allows to specify a separator (delimited) for text-based Cells documents. This may be a single character (like comma, semicolon, whitespace, tab, or anything else) or even a custom string. GroupDocs.Editor will apply this separator for representing the input text-based Cells document in a proper view.
    
    **TextLoadOptions**
    
    ```csharp
    /// <summary>
    /// Subclass for loading text-based Cells documents (CSV, Tab-based etc.)
    /// </summary>
    public class TextLoadOptions
    {
        /// <summary>
        /// Allows to specify a string separator for text-based Cells documents
        /// </summary>
        public string Separator { get; set; }
    }
    ```
    
      
    3\. Class CellsSaveOptions is designed for tuning the backward process of conversion from HTML to one of output Cells formats.
    
    **CellsSaveOptions**
    
    ```csharp
    /// <summary>
    /// Allows to specify custom options for generating and saving MS Excel-compliant documents
    /// </summary>
    public class CellsSaveOptions
    {
        public string Password { get; set; }
     
        public CellFormats OutputFormat { get; set; }
    }
    ```
    
    The *Password* property, if set to not-null and not-empty string, allows to protect the generated output document with the password. The *OutputFormat* property is an enumeration, which provides ability to specify output document format. The default value is XLSX. If output format is a text-based document (like CSV), then password, even being specified, will be ignored.
