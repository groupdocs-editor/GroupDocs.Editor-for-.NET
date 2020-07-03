---
id: groupdocs-editor-for-net-18-9-release-notes
url: editor/net/groupdocs-editor-for-net-18-9-release-notes
title: GroupDocs.Editor for .NET 18.9 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 18.9{{< /alert >}}

## Major features

#### Cells module

1.  New properties in TextLoadOptions
2.  New option to optimize memory usage
3.  New option to exclude hidden worksheets
4.  Worksheet protection

#### Words module

1.  Document protection
2.  Reply comments and statuses
3.  New option to optimize memory usage
4.  PDF compliance

## Other features

Fixed several bugs and security improvements update.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-911 | Implement support of generating the password-protected sheets in spreadsheet documents | New Feature |
| EDITORNET-927 | Implement support of additional parameters when processing text-based spreadsheet | New Feature |
| EDITORNET-928 | Implement ability to adjust memory usage during opening input Cells document | New Feature |
| EDITORNET-929 | Implement the ExcludeHiddenWorksheets option | New Feature |
| EDITORNET-930 | Implement ability to adjust memory usage during Words processing | New Feature |
| EDITORNET-931 | Add support of document protection during Words document generation | New Feature |
| EDITORNET-933 | Implement Reply comments and Done status | New Feature |
| EDITORNET-935 | Implement ability to select PDF standards compliance level when generating PDF from HTML | New Feature |
| EDITORNET-946 | Security improvements update | Improvement |
| EDITORNET-914 | Fix common bug in length and Resolution parsing modules | Bug |
| EDITORNET-895 | Fix ArgumentException with pages15.docx sample document | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Editor for .NET 18.9. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Editor which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Improvements and new features in Cells module

1.  #### New properties in TextLoadOptions
    
    **GroupDocs.Editor** supports different Cells formats when converting document to HTML. Some of Cells formats are binary, like XLSX, while some have textual nature, like CSV, TabDelimited and some other. CellsToHtmlOptions class contains an inner class TextLoadOptions, which is designed especially for such text-based Cells formats. In v18.9 version we have added two new public options to this class: *ConvertDateTimeData* and *ConvertNumericData*. Both options are boolean and are *false* by default.
    
    ```csharp
    /// <summary>
    /// Gets or sets a value that indicates whether the string in text file is converted to the date data. Default is false.
    /// </summary>
    public bool ConvertDateTimeData { get; set; }
    
    /// <summary>
    /// Gets or sets a value that indicates whether the string in text file is converted to numeric data. Default is false.
    /// </summary>
    public bool ConvertNumericData { get; set; }
    ```
    
    By default the GroupDocs.Editor, when opening text-based Cells document, interpret all content from any cell as textual. With this option users can specify, whether GroupDocs.Editor needs to parse such content and tries to convert it to the numeric or datetime data.
    
2.  #### New option to optimize memory usage
    
    By default GroupDocs.Editor works with Cells document with maximum performance; in other words, it tries to perform the work in the least possible time. The drawback of such approach is that in some cases, especially when processed document is huge, memory consumption may be a problem. In such cases, when you're facing OutOfMemoryException, you big memory consumption is unacceptable, you may turn on the *OptimizeMemoryUsage* option by setting it to *true*. In this case GroupDocs.Editor will significantly decrease memory usage, but this will degrade performance. The *OptimizeMemoryUsage *boolean option is disabled by default and is located in the *CellsToHtmlOptions* class.
    
    ```csharp
    /// <summary>
    /// Enables memory optimization mechanisms during input document processing, which may degrade performance in some special cases, 
    /// but on the other hand decrease memory usage. Useful when processing huge documents and facing OutOfMemoryException. 
    /// Default is false (memory optimization is disabled for the sake of better performance).
    /// </summary>
    public bool OptimizeMemoryUsage { get; set; }
    ```
    
3.  #### New option to exclude hidden worksheets
    
    Almost any Cells document (excluding the text-based) along with any spreadsheet-processing software (like MS Excel) supports multiple worksheets (tabs). GroupDocs.Editor can process only single tab at once, the *WorksheetIndex* option is responsible for selecting such tab. Several binary Cells formats (like XLSX) support hidden worksheets (tabs) concept. Hidden worksheet means that when opening document with such tabs, you will not see them usually unless you manually will make them visible (normal). GroupDocs.Editor by default completely ignores visibility status of worksheets, i.e. it processes all tabs usually. But now, with the new option *ExcludeHiddenWorksheets*, it is allowed to exclude hidden tabs from processing. When enabled, GroupDocs.Editor will completely ignore them, like they are not existing. In such scenario the *WorksheetIndex* option "covers" only visible tabs. For example, when document has three tabs, where first tab is hidden, while two consequent (second and third) are visible, the *ExcludeHiddenWorksheets* = 1 will select the last (third) tabs, because it is second visible. So, we may say that *ExcludeHiddenWorksheets* option, when turned on, modifies the behavior of the *WorksheetIndex* option.
    
    ```csharp
    /// <summary>
    /// Allows to exclude hidden worksheets in the input Cells document, so they will be totally ignored. 
    /// Default is false - hidden worksheets are available and processed as normal.
    /// </summary>
    /// <remarks>
    /// Several binary Cells formats (like XLSX) support hidden worksheets (tabs) concept. 
    /// Document of such format, if it has more then one worksheet, may contain additional hidden worksheets. 
    /// By default such hidden worksheets are available for processing, but with this option it is able to ignore them, 
    /// like these hidden worksheets are absent and don't exist. When this option is enabled, you cannot select hidden workseet with the 
    /// '<see cref="WorksheetIndex"/>' property.
    /// </remarks>
    public bool ExcludeHiddenWorksheets { get; set; }
    ```
    
    ExcludeHiddenWorksheets is a boolean property, which is disabled (false) by default, and is located in the *CellsToHtmlOptions* class.
    
4.  #### Worksheet protection
    
    Most of binary Cells formats support the document protection feature — when the document is protected from modifications of specific type with the password. Most of spreadsheet-processing software (like MS Excel) also supports this feature. And now, with the v18.9, such feature is also supported by the GroupDocs.Editor. When saving edited document in HTML format into Cells format, you are able to apply a document protection. Of course, it will not work in case when you select Cells format, which doesn't support this feature; for example, any of text-based, like CSV.
    
    ```csharp
    /// <summary>
    /// Allows to enable a worksheet protection for the output document. By default is NULL - protection is not applied.
    /// </summary>
    public WorksheetProtection WorksheetProtection { get; set; }
    ```
    
    Document protection is regulated by the *WorksheetProtection* property in the *CellsSaveOptions* class. By default it is NULL — document protection is disabled. In order to apply the protection you need to create an instance of the *WorksheetProtection* class, fill it with necessary values, and set to the *WorksheetProtection*property.
    
    The *WorksheetProtection* class is listed below:
    
    ```csharp
    /// <summary>
    /// Encapsulates worksheet protection options, which allow to protect a worksheet in the output Cells document from modification of specified type 
    /// with a specified password.
    /// </summary>
    /// <remarks>Most of Cells formats like XLSX allows to protect a worksheet from editing with password. 
    /// This class allows to enable such protection and specify its options.</remarks>
    public sealed class WorksheetProtection
    {
        /// <summary>
        /// Allows to specify a type of worksheet protection. By default is 'None' - protection is not applied.
        /// </summary>
        public WorksheetProtectionType ProtectionType { get; set; }
    
        /// <summary>
        /// Password, which is used for protecting a worksheet. If NULL or empty string, the protection will not be applied.
        /// </summary>
        public string Password { get; set; }
    }
    ```
    
    It has two properties — protection type (level) and password. By default the *ProtectionType* property is set to *None* — protection is not applied (default value). *Password* is set to NULL — protection is not applied too. So in order to truly apply the document protection, you need to create an instance of the *WorksheetProtection* class, set non-null and non-empty password, select valid *ProtectionType*, and assign this instance to the *CellsSaveOptions*.WorksheetProtection* *property.
    
    The *WorksheetProtectionType* is an enumeration, which contains all possible levels of document protection. They are listed below.
    
    1.  None  — Protection is not applied (default value)
    2.  All — User cannot modify anything on the worksheet
    3.  Contents — User cannot enter data in the worksheet
    4.  Objects — User cannot modify drawing objects
    5.  Scenarios — User cannot modify saved scenarios
    6.  Structure — User cannot modify the structure
    7.  Window — User cannot modify the window

### Improvements and new features in Words module

1.  #### Document protection
    
    Most of Words formats, like DOCX and ODT, support a document protection; when user can protect the document from modification of specific type with a password. GroupDocs.Editor, starting from v18.9, also supports this feature. When saving edited document to some of Words formats, you are able to apply a some level of protection to the resultant document with the *Protection* property in the *WordsSaveOptions* class.
    
    ```csharp
    /// <summary>
    /// Allows to control and apply the document protection options for the Words document of any format, which supports document protection. 
    /// By default is NULL - document protection will not be used.
    /// </summary>
    public DocumentProtection Protection { get; set; }
    ```
    
    By default this property is NULL — no protection is applied. In order to apply the protection, you need to create an instance of the *DocumentProtection* class and assign it to this property.
    
    ```csharp
    /// <summary>
    /// Encapsulates document protection options for the Words document, which is generated from HTML
    /// </summary>
    public sealed class DocumentProtection
    {
        /// <summary>
        /// Parameterless constructor - all parameters have default values
        /// </summary>
        public DocumentProtection()
        {
        }
     
        /// <summary>
        /// Allows to set all parameters during class instantiation
        /// </summary>
        /// <param name="protectionType">Set the protection type of the document</param>
        /// <param name="password">Set the protection password</param>
        public DocumentProtection(DocumentProtectionType protectionType, string password)
        {
            this.ProtectionType = protectionType;
            this.Password = password;
        }
        /// <summary>
        /// Allows to set a protection type of the document. By default is set to not protect the document at all.
        /// </summary>
        public DocumentProtectionType ProtectionType { get; set; }
     
        /// <summary>
        /// The password to protect the document with. If null or empty string - the protection will not be applied to the document.
        /// </summary>
        public string Password { get; set; }
    }
    ```
    
    The *DocumentProtection* class contains two properties, which both are vital for protecting the document — *Password *and *ProtectionType*. By default the *ProtectionType* property is set to *NoProtection *— protection is not applied (default value). *Password* is set to NULL — protection is not applied too. So in order to truly apply the document protection, you need to create an instance of the *DocumentProtection* class, set non-null and non-empty password, select valid *ProtectionType*, and assign this instance to the **WordsSaveOptions*.**Protection* property.
    
    The *DocumentProtectionType* is an enumeration, which contains all possible levels of document protection. They are listed below.
    
    1.  NoProtection — The document is not protected. Default value.
    2.  AllowOnlyRevisions — User can only add revision marks to the document
    3.  AllowOnlyComments — User can only modify comments in the document
    4.  AllowOnlyFormFields — User can only enter data in the form fields in the document
    5.  ReadOnly — No changes are allowed to the document
2.  #### Reply comments and statuses
    
    GroupDocs.Editor supports comments in documents from the first release. However in the newest versions of Office Open XML was introduced a concept of comments hierarchy, where there are root comments and reply comments, which may be treated as descendants (or children) for the root comments. Starting from v18.9, GroupDocs.Editor recognizes and supports such comments. When opening document in HTML for editing, GroupDocs.Editor preserves comment hierarchy and renews it when saving edited document in some of Words formats. Along with this, GroupDocs.Editor now supports the "Done" status for the comments. Again, this is supported also for the backward conversion.
3.  #### New option to optimize memory usage
    
    When saving edited documents in HTML to some of Words formats, GroupDocs.Editor works with maximum performance, trying to save the document during the least possible time. But such approach may require a huge amount of memory when the document is big. When high memory consumption is not suitable for you, or you're facing the OutOfMemoryException, you can enable the option *OptimizeMemoryUsage* from the *WordsSaveOptions* class. By default this boolean option is set to *false* — memory optimization is turned off for the sake of the best performance. When turning on, this will significantly decrease memory consumption while generating large documents at the cost of slower saving time.
    
    ```csharp
    /// <summary>
    /// Enables memory optimization mechanisms during document generation from HTML, which degrades performance in as a cost of decreasing memory usage. 
    /// Setting this option to true can significantly decrease memory consumption while generating large documents at the cost of slower saving time.
    /// Default is false (memory optimization is disabled for the sake of better performance).
    /// </summary>
    public bool OptimizeMemoryUsage { get; set; }
    ```
    
4.  #### PDF compliance
    
    When opening Words document, editing it in HTML editor and saving back to some of formats, you may select not only the Words formats, but also PDF using the *PdfSaveOptions* class. Now we added a new option *Compliance *into this class, which is responsible for the PDF compliance of generated PDF document.
    
    ```csharp
    /// <summary>
    /// Specifies the PDF standards compliance level for output documents. Default is PdfCompliance.Pdf15.
    /// </summary>
    public PdfCompliance Compliance { get; set; }
    ```
    
    This property is of *PdfCompliance* type, which is enumeration. By default all documents are generated in PDF 1.5 standard. However, with this new option you also may select:
    
    1.  PDF/A-1a standard. This level includes all the requirements of PDF/A-1b and additionally requires that document structure be included (also known as being "tagged"), with the objective of ensuring that document content can be searched and repurposed. Please note that exporting the document structure significantly increases the memory consumption, especially for the large documents.
        
    2.  PDF/A-1b standard. PDF/A-1b has the objective of ensuring reliable reproduction of the visual appearance of the document.
