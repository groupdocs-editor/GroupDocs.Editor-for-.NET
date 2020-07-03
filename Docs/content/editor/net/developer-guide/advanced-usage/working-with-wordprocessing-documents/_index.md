---
id: working-with-wordprocessing-documents
url: editor/net/working-with-wordprocessing-documents
title: Working with WordProcessing documents
weight: 1
description: " This guide demonstrates how to edit DOC, DOT, DOCX, DOCM, DOTX, ODT, RTF documents with font extraction, different pagination modes and many other powerful features of GroupDocs.Editor for .NET."
keywords: Edit DOCX, Edit DOC, Edit RTF, Edit ODT, Edit Word document
productName: GroupDocs.Editor for .NET
hideChildren: False
---
> This example demonstrates standard open-edit-save cycle with WordProcessing documents, using different options on every step.

### Introduction

WordProcessing is the most used and known document family format, that includes DOC, DOT, DOCX, DOCM, DOTX, ODT, RTF and much more. All these formats are supported by the [**GroupDocs.Editor**](https://products.groupdocs.com/editor/net).   
There are two processing modes for WordProcessing documents:

*   *float* (default) 
*   *paged* (also known as *paginal*). 

In the float mode, when document is opened for editing and loaded into WYSIWYG client-side HTML-editor, it is represented without pages, like a single page text document.  
In counterpart to this, when paged mode is enabled, document content is divided onto pages. For proper usage paged mode, if enabled, should be enabled in both edit options and save options simultaneously (this is described below).

### Loading WordProcessing documents

First of all user must open a document by loading it into the [Editor](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor) class instance. This example demonstrates how to load the password-protected document from the stream. So, let's suppose we have an encoded DOCX, and user knows its password. First of all, you need to create a load options.

```csharp
Options.WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
loadOptions.Password = "some_password_to_open_a_document";
```

Please note that if document has no protection, the password will be ignored. However, if document is protected, but user has not specified a password, a [PasswordRequiredException](https://apireference.groupdocs.com/net/editor/groupdocs.editor/passwordrequiredexception) will be thrown during document editing.

Next step is to load the document from stream into the [Editor](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor) class. For loading documents from streams [Editor](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor) uses delegates. In other words, you need to pass the delegate instance, that points to the method, that returns a stream.   
Same with load options — they are passed via delegate.

```csharp
FileStream inputStream = File.OpenRead("C:\\input_path\\document.docx");
Editor editor = new Editor(delegate { return inputStream; }, delegate { return loadOptions; });
```

### Editing WordProcessing documents

When document is loaded, it can be edited (transformed to [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) class), and this process can be adjusted with edit options. Let's create them:

```csharp
Options.WordProcessingEditOptions editOptions = new WordProcessingEditOptions(); //#1
editOptions.FontExtraction = FontExtractionOptions.ExtractEmbeddedWithoutSystem; //#2
editOptions.EnableLanguageInformation = true; //#3
//5.3. Switch to pagination mode instead of default float mode
editOptions.EnablePagination = true; //#4
```

Let's describe the code above line by line.   
*Line #1* - every supported document family format has its own options class. So for all WordProcessing formats you need to apply the [WordProcessingEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions). The same for other formats — [SpreadsheetEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheeteditoptions) for all spreadsheet-based formats (like XLS, ODS etc.) and so on.   
*Line #2* - specifies font extraction options. By default no fonts are extracted from the document, but with this option user can specify, which fonts categories should be extracted and saved in the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance.   
*Line #3* - enables extracting language information for better subsequent spell-checking on client side. Finally, *line #4* switches document processing mode from float (default) to the paged.

After preparing options the previously loaded document can be edited:

```csharp
EditableDocument beforeEdit = editor.Edit(editOptions);
```

Unlike previous example let's extract HTML markup and resources separately:

```csharp
string originalContent = beforeEdit.GetContent();
List<IHtmlResource> allResources = beforeEdit.AllResources;
```

First string contains all HTML markup without resources, while second `List` contains all resources (images, fonts, and stylesheets).

### Modifying document content

Let's imagine that user passed HTML markup and resources, obtained from [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance, to the WYSIWYG-editor, edited the document on client-side and obtained back a modified HTML markup.   
Now user needs to create new [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance from this modified markup.

```csharp
string editedContent = originalContent.Replace("document", "edited document");
EditableDocument afterEdit = EditableDocument.FromMarkup(editedContent, allResources);
```

We passed the same `List` with resources to the edited [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument), however it can be a completely new `List` with other resources.

### Saving WordProcessing documents

Before saving the document user must create saving options.

```csharp
WordProcessingFormats docmFormat = WordProcessingFormats.Docm; //#1
Options.WordProcessingSaveOptions saveOptions = new WordProcessingSaveOptions(docmFormat); //#2
saveOptions.Password = "password"; //#3
saveOptions.EnablePagination = true; //#4
saveOptions.Locale = System.Globalization.CultureInfo.GetCultureInfo("en-US"); //#5
saveOptions.OptimizeMemoryUsage = true; //#6
saveOptions.Protection = new WordProcessingProtection(WordProcessingProtectionType.ReadOnly, "write_password"); //#7
```

Let's describe a piece of code above line by line:

1.  Creating a format of output document, in our case it is DOCM.
2.  Creating instance of [WordProcessingSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions) with previously prepared format.
3.  When user specifies a password, GroupDocs.Editor encrypts the document with this password. So, when document will be saved, it can be opened only with the password.
4.  Because pagination was previously enabled in [WordProcessingEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingeditoptions) (`editOptions` variable), for better output result it is highly recommended to enable it in [WordProcessingSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/wordprocessingsaveoptions).
5.  You can set locale for output WordProcessing document manually.
6.  If document is really huge and causes OutOfMemoryException, you can set memory optimization option
7.  You can protect document from writing (make it read-only) with password. Please note that this is write protection, and it is separate from opening protection, that was installed above.

Finally, user should save an edited document into the stream with prepared save options.

```csharp
MemoryStream outputStream = new memorySream();
editor.Save(afterEdit, outputStream, saveOptions);
```

And don't forget to dispose all resources:

```csharp
beforeEdit.Dispose();
afterEdit.Dispose();
editor.Dispose();
```

### Conclusion

This tutorial demonstrates basic scenario — opening document, editing it and saving, — but with detailed options on every step.
