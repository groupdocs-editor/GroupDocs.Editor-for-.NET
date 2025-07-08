using GroupDocs.Editor.Examples.CSharp;
using GroupDocs.Editor.Examples.CSharp.AdvancedUsage;
using GroupDocs.Editor.Examples.CSharp.AdvancedUsage.EditableDocumentExamples;
using GroupDocs.Editor.Examples.CSharp.BasicUsage;

Console.WriteLine("Using GroupDocs.Editor for .NET version {0}", typeof(GroupDocs.Editor.Editor).Assembly.GetName().Version.ToString());
Console.WriteLine("Open Program.cs. \nIn Main() method uncomment the example that you want to run.");
Console.WriteLine("Output folder is '{0}'", Constants.OutputPath);
Console.WriteLine("=====================================================");
#region Quick Start

GroupDocs.Editor.Examples.CSharp.QuickStart.SetLicenseFromFile.Run();
GroupDocs.Editor.Examples.CSharp.QuickStart.HelloWorld.Run();
#endregion

//// *** Documents Editor Examples (Un-Comment to run each example demo methods) ***

#region Here are basic examples

Introduction.Run();

LoadDocument.Run();

EditDocument.Run();

SaveDocument.Run();

CreateDocument.Run();

#endregion

#region Advanced usage

WorkingWithWordProcessing.Run();
EditNewDocument.Run();

WorkingWithPdf.Run();
EditPdf.Run(true);
EditPdf.Run(false);

WorkingWithSpreadsheetPasswordProtected.Run();

WorkingWithSpreadsheetMultiTab.Run();

WorkingWithDsv.Run();

WorkingWithPresentations.Run();

WorkingWithPlainTextDocuments.Run();

WorkingWithXml.Run();

ExtractingDocumentInfo.Run();

SavingEditedDocumentToAllFormats.Run();

WorkingWithFormats.Run();

#endregion

#region Working with EditableDocument

CreateEditableDocumentFromHtmlFile.Run();

CreateEditableDocumentFromInnerBody.Run();

GetHtmlContent.Run();

GetHtmlContentWithPrefix.Run();

GetHtmlBodyContent.Run();

GetHtmlBodyContentWithPrefix.Run();

GetAllEmbeddedHtmlContent.Run();

GetExternalCssContent.Run();

GetExternalCssContentWithPrefix.Run();

SaveHtmlToFolder.Run();

SaveHtmlResourcesToFolder.Run();

WorkingWithResources.Run();

EditableDocumentAdvancedUsage.Run();

#endregion

#region Working with FormFieldManager

LegacyFormFieldCollection.Run();
FixInvalidFormFieldCollectionAndSave.Run();
EditFormFieldCollection.Run();
RemoveFormFieldCollection.Run();

#endregion

Console.WriteLine("\r\n\r\n__________________________\r\nAll done. Press any key to exit.");
