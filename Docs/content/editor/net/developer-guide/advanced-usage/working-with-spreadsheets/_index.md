---
id: working-with-spreadsheets
url: editor/net/working-with-spreadsheets
title: Working with Spreadsheets
weight: 2
description: "This guide demonstrates how to edit XLS, XLSX, XLSM, XLSB, ODS, SXC spreadsheets with hidden worksheets, protect edited spreadsheet with password and many other powerful features of GroupDocs.Editor for .NET."
keywords: Edit Excel, Edit spreadsheet, Edit XLS, Edit XLSX, Edit XLSM, Edit XLSB, Edit ODS, Edit SXC
productName: GroupDocs.Editor for .NET
hideChildren: False
---
> This demonstration shows and explains all necessary moments and options regarding processing the Spreadsheet documents.

#### Introduction

Spreadsheet documents are presented by many formats: XLS, XLSX, XLSM, XLSB, ODS, SXC and other, which are supported by **[GroupDocs.Editor](https://products.groupdocs.com/editor/net)**. There are separate load options, edit options and save options for all Spreadsheet documents. Please note that GroupDocs.Editor distinguish Spreadsheet documents from textual Delimiter-Separated documents (DSV) like CSV, TSV, semicolon-separated, whitespace-separated and so on. Such document types have a distinct set of options and are not reviewed in this article.

Spreadsheet documents have one critically important distinction compared to WordProcessing or textual documents — they have tabs (also called worksheets) instead of pages, and these tabs are separate and independent from each other. Tabs have no valid and correct representation in HTML markup. This means that WYSIWYG HTML-editors don't allow to edit multi-tabbed spreadsheet at one moment, — it is allowed to edit only one tab per time. Save edited tab, and only then switch to another one. Because GroupDocs.Editor is designed for editing documents on client-side, it should be consistent with such approach. As a result, multi-tabbed Spreadsheet document can be loaded to the [Editor](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor) class, but [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance stores a content of only one tab. In other words, user loads multi-tabbed spreadsheet to the [Editor](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor) class, but for editing two tabs, for example, he should call the [Editor](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor).[Edit](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor/methods/edit) method two times: first one for the first tab and second invoke for the second tab. As a result, with these two calls user obtains two [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instances — first one contains first tab, and the second one — second.

As WordProcessing documents, Spreadsheet documents can have password-protection and can be protected from editing; GroupDocs.Editor supports all these features.

#### Loading Spreadsheet documents

In order to load spreadsheet to the [Editor](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editor) class, user should use the [SpreadsheetLoadOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetloadoptions) class. It is not necessary in some general cases — even without [SpreadsheetLoadOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetloadoptions) the GroupDocs.Editor is able to recognize spreadsheet format and apply appropriate default load options automatically. But when spreadsheet is encoded, the [SpreadsheetLoadOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetloadoptions) is the only way to set a password and load the document properly.   
Example below shows such situation: loading the password-protected spreadsheet:

```csharp
string inputXlsxPath = "C://input/spreadsheet.xlsx";
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
loadOptions.Password = "password";
Editor editor = new Editor(inputXlsxPath, delegate { return loadOptions; });
```

There can be several scenarios here:

1.  If password is specified, but document is not password-protected, the password will be ignored.
2.  If document is password-protected, but password is not specified, the [PasswordRequiredException](https://apireference.groupdocs.com/net/editor/groupdocs.editor/passwordrequiredexception) will be thrown later during editing.
3.  If document is password-protected,and password is specified, but is incorrect, the [IncorrectPasswordException](https://apireference.groupdocs.com/net/editor/groupdocs.editor/incorrectpasswordexception) will be thrown later during editing.

#### Editing Spreadsheet documents

[SpreadsheetEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheeteditoptions) should be used for editing Spreadsheet documents. If parameterless overload of the `Editor.Edit` method is used, the first tab will be opened for editing. [SpreadsheetEditOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheeteditoptions) allows to specify the tab for opening by 0-based index and a boolean flag that indicates whether it is necessary to process hidden worksheets. This is demonstrated below:

```csharp
SpreadsheetEditOptions editOptions1 = new SpreadsheetEditOptions();
editOptions1.WorksheetIndex = 0;//index is 0-based, so this is 1st tab
editOptions1.ExcludeHiddenWorksheets = true;

SpreadsheetEditOptions editOptions2 = new SpreadsheetEditOptions();
editOptions2.WorksheetIndex = 1;//index is 0-based, so this is 2nd tab
editOptions2.ExcludeHiddenWorksheets = false;

EditableDocument firstTab = editor.Edit(editOptions1);
EditableDocument secondTab = editor.Edit(editOptions2);
```

#### Saving Spreadsheet documents

[SpreadsheetSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetsaveoptions) class is designed for saving the Spreadsheet documents. Its constructor contains one mandatory parameter: document type, that is represented by the [SpreadsheetFormats](https://apireference.groupdocs.com/net/editor/groupdocs.editor.formats/spreadsheetformats) struct. With this option class user can also specify password; in such case output document will be encoded. Another possibility — to set the write protection for the edited tab (worksheet), also with the password. All these features are shown in the code below:

```csharp
SpreadsheetSaveOptions saveOptions = new SpreadsheetSaveOptions(SpreadsheetFormats.Xlsm);
saveOptions.Password = "new password";//after setting this password the output XLSM will be encoded and thus cannot be opened without password anymore
saveOptions.WorksheetProtection = new WorksheetProtection(WorksheetProtectionType.All, "write password");//this is a write-protection; even after opening user should specify password for editing

System.IO.Stream outputStream = /* obtain it from somewhere */;
 
//saving 2nd edited tab to specified stream in XLSM format with additional parameters
editor.Save(secondTab, outputStream, saveOptions);
```

As it can be seen from the fragment of the source code above, a secondTab variable contains a reference to the [EditableDocument](https://apireference.groupdocs.com/net/editor/groupdocs.editor/editabledocument) instance, which represents a second tab. This means that the output XLSM document will have only one tab, which was initially opened for edit, passed to the WYSIWYG-editor, edited there by the user, then passed back and saved. This is a default and initial behavior, which was introduced at the very beginning of the GroupDocs.Editor, at the same time, when Spreadsheets module was released.

However, starting from version 20.10 a new possibility was introduced — now GroupDocs.Editor can make a full copy of the initial Spreadsheet document and inject the edited tab into it, instead of the original tab or along with it. In order to achieve this the two new parameters were introduced in the [SpreadsheetSaveOptions](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetsaveoptions) class: integer [WorksheetNumber](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetsaveoptions/properties/WorksheetNumber) and boolean [InsertAsNewWorksheet](https://apireference.groupdocs.com/net/editor/groupdocs.editor.options/spreadsheetsaveoptions/properties/InsertAsNewWorksheet). This feature is explained in detail in [separate article]({{< ref "editor/net/developer-guide/advanced-usage/working-with-spreadsheets/inserting-edited-worksheet-into-existing-spreadsheet.md" >}}).

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