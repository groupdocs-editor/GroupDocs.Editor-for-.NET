## GroupDocs.Editor for .NET

[GroupDocs.Editor](https://products.groupdocs.com/editor/net) is an on-premise .NET library that provides the ability to edit Word, Excel, PowerPoint, TXT, HTML, XML & other popular document formats using front-end WYSIWYG editor - all without any additional applications.

This package contains [Examples](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET/tree/master/Examples) for [GroupDocs.Editor for .NET](https://products.groupdocs.com/editor/net) that will help you understand API's working and write your own applications.

<p align="center">

  <a title="Download complete GroupDocs.Editor for .NET source code" href="https://codeload.github.com/groupdocs-editor/GroupDocs.Editor-for-.NET/zip/master">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Docs](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET/tree/master/Docs)  | Product documentation containing Developer's Guide, Release Notes & more.
[Examples](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET/tree/master/Examples)  | Package contains C# example projects and sample files used in the examples.
[Showcases](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET/tree/master/Showcases)  | Frontend examples to help you learn how to Implement product features in a Web-UI based application.
[Plugins](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET/tree/master/Plugins)  | Visual Studio Plugins related to GroupDocs.Editor.

## Document Editing Features

- Support for [40+ document formats](https://docs.groupdocs.com/editor/net/supported-document-formats/).
- [Edit word processing documents](https://docs.groupdocs.com/editor/net/working-with-wordprocessing-documents/) in a flow or paged mode.
- Fetch language information for multi-lingual document editing.
- Extract font information to provide consistent editing and appearance behavior.
- [Edit multi-tabbed Excel files](https://docs.groupdocs.com/editor/net/working-with-spreadsheets/).
- Specify separator, flexible numeric and data conversion for CSV & TSV files.
- Fix incorrect XML document structure.
- Recognize URIs and email addresses in XML files.
- Extract basic information about the edited document.
- Set character encoding of the input text document.
- [Grab document metadata information](https://docs.groupdocs.com/editor/net/extracting-document-metainfo/).
- Get HTML document along with all its resources (stylesheets, images).
- Open any supported format file in HTML format and save to disk.
- Fetch HTML markup from DB or remote storage.

## Editable File Formats

**Word Processing:** DOC, DOCX, DOCM, DOT, DOTM, DOTX, FlatOPC, ODT, OTT, RTF, WordML\
**Spreadsheet:** XLS, XLT, XLSX, XLSM, XLTX, XLTM, XLSB, XLAM, SXC, SpreadsheetML, ODS, FODS, DIF, DSV, CSV, TSV\
**Presentation:** PPT, PPTX, PPTM, PPS, PPSX, PPSM, POT, POTX, ODP, OTP\
**Other:** TXT, HTML, XML

## Develop & Deploy GroupDocs.Editor Anywhere

**Microsoft Windows:** Windows Desktop & Server (x86, x64), Windows Azure\
**macOS:** Mac OS X\
**Linux:** Ubuntu, OpenSUSE, CentOS, and others\
**Development Environments:** Microsoft Visual Studio, Xamarin.Android, Xamarin.IOS, Xamarin.Mac, MonoDevelop 2.4 or later\
**Supported Frameworks:** .NET Framework 2.0 & above, Mono Framework 1.2 & above

## Getting Started with GroupDocs.Editor for .NET

Are you ready to give GroupDocs.Editor for .NET a try? Simply execute `Install-Package GroupDocs.Editor` from Package Manager Console in Visual Studio to fetch & reference GroupDocs.Editor assembly in your project. If you already have GroupDocs.Editor for .NET and want to upgrade it, please execute `Update-Package GroupDocs.Editor` to get the latest version.

## Load, Edit & Save Excel Spreadsheet as HTML

```csharp
using (FileStream inputStream = File.OpenRead(inputFilePath))
{
    using (Editor editor = new Editor(delegate { return inputStream;}, delegate { return new SpreadsheetLoadOptions();}))
    {
        //3. Let's create an intermediate EditableDocument from 1st tab
        SpreadsheetEditOptions editOptions1 = new SpreadsheetEditOptions();
        editOptions1.WorksheetIndex = 0;//index is 0-based
        EditableDocument firstTabBeforeEdit = editor.Edit(editOptions1);

        //4. Let's create an intermediate EditableDocument from 2nd tab
        SpreadsheetEditOptions editOptions2 = new SpreadsheetEditOptions();
        editOptions2.WorksheetIndex = 1;//index is 0-based
        EditableDocument secondTabBeforeEdit = editor.Edit(editOptions2);

        //5. Save first tab from EditableDocument #1 to separate document
        SpreadsheetSaveOptions saveOptions1 = new SpreadsheetSaveOptions(SpreadsheetFormats.Xlsm);
        string outputFilename1 = Path.GetFileNameWithoutExtension(inputFilePath) + "_tab1.xlsm";
        string outputPath1 = Path.Combine(Constants.GetOutputDirectoryPath(), outputFilename1);
        editor.Save(firstTabBeforeEdit, outputPath1, saveOptions1);

        //6. Save second tab from EditableDocument #2 to separate document
        SpreadsheetSaveOptions saveOptions2 = new SpreadsheetSaveOptions(SpreadsheetFormats.Xlsb);
        string outputFilename2 = Path.GetFileNameWithoutExtension(inputFilePath) + "_tab2.xlsb";
        string outputPath2 = Path.Combine(Constants.GetOutputDirectoryPath(), outputFilename2);
        editor.Save(secondTabBeforeEdit, outputPath2, saveOptions2);

        //7. Dispose both EditableDocument instances
        firstTabBeforeEdit.Dispose();
        secondTabBeforeEdit.Dispose();
    }
}
```

[Product Page](https://products.groupdocs.com/editor/net) | [Documentation](https://docs.groupdocs.com/editor/net/) | [Demo](https://products.groupdocs.app/editor/family) | [API Reference](https://apireference.groupdocs.com/net/editor) | [Examples](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET) | [Blog](https://blog.groupdocs.com/category/editor/) | [Free Support](https://blog.groupdocs.com/category/editor/) | [Temporary License](https://purchase.groupdocs.com/temporary-license)
