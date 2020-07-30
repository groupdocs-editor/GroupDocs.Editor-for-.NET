---
id: memory-optimization-option
url: editor/net/memory-optimization-option
title: Memory optimization option
weight: 9
description: "This article explains how to optimize memory utilization when editing large Word documents using GroupDocs.Editor for .NET API."
keywords: large document edit performance, memory optimization when edit document
productName: GroupDocs.Editor for .NET
hideChildren: False
---
By default [**GroupDocs.Editor**](https://products.groupdocs.com/editor/net) tries to perform computations and complete the task as fast as possible, and if this challenge requires a lot of memory to be used, GroupDocs.Editor does it. However, in some very specific cases, when processing document is very huge, and GroupDocs.Editor works in 32-bit application, which is limited to 2GiB per process, or user machine has very limited amount of free memory, the SystemOutOfMemoryException may occur. In order to solve such problem the [WordProcessingSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions) class contains the [`OptimizeMemoryUsage`](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions/properties/optimizememoryusage) property:

```csharp
public bool OptimizeMemoryUsage { get; set; }
```

By default it has a "*false*" value, which means that the memory optimization is disabled for the sake of the best possible performance. By setting a "*true*" user can enable another document generating mechanism, which can significantly decrease memory consumption while generating large documents at the cost of slower generation time while performing the [`editor.Save()](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/save) method.

## More resources
### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Editor for .NET examples, plugins, and showcase](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET)   
*   [GroupDocs.Editor for Java examples, plugins, and showcase](https://github.com/groupdocs-editor/GroupDocs.Editor-for-Java)    
*   [Document Editor for .NET MVC UI Example](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-MVC)     
*   [Document Editor for .NET App WebForms UI Modern Example](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-WebForms)    
*   [Document Editor for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-editor/GroupDocs.Editor-for-Java-Dropwizard)    
*   [Document Editor for Java Spring UI Example](https://github.com/groupdocs-editor/GroupDocs.Editor-for-Java-Spring)
    
### Free Online App
Along with full-featured .NET library we provide simple but powerful free Apps.  
You are welcome to edit your Microsoft Word (DOC, DOCX, RTF etc.), Microsoft Excel (XLS, XLSX, CSV etc.), Open Document (ODT, OTT, ODS) and other documents with free to use online **[GroupDocs Editor App](https://products.groupdocs.app/editor)**.