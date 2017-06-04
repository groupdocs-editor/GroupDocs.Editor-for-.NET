Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace GroupDocsEditor.Examples.VisualBasic
    Module Module1
        Sub Main(args As String())

            '#Region "Common properties"

            ''' you can set source and resources file/folder paths and output and resources file/folders paths
            Common.sourcePath = Path.Combine(Environment.CurrentDirectory, "../../../Data/SourceFiles")
            Common.sourceResourcesPath = Path.Combine(Environment.CurrentDirectory, "../../../Data/SourceFiles")
            Common.sourceResourcesFolder = "Resources"
            Common.resultPath = Path.Combine(Environment.CurrentDirectory, "../../../Data/OutputFiles")
            Common.resultResourcesPath = Path.Combine(Environment.CurrentDirectory, "../../../Data/OutputFiles")
            Common.resultResourcesFolder = "Resources"

            ' set source and resources file/folder
            Common.sourceFile = "source.html"
            'Common.sourceFile = "source.docx";

            '#End Region

            '#Region "Set GroupDocs License File"

            ' Uncomment following lines and specify the licence file to embed product licence using file path.
            'Common.licensePath = Path.Combine(Environment.CurrentDirectory, @"GroupDocs.Editor.lic"); //"D:/License/GroupDocs.Editor.lic";
            'Common.ApplyLicense(Common.licensePath);

            ' Uncomment following lines and specify the licence file to embed product licence using stream.
            'Stream licenseStream = File.Open(Path.Combine(Environment.CurrentDirectory, @"GroupDocs.Editor.lic"), FileMode.Open, FileAccess.Read);
            'Common.ApplyLicense(licenseStream);
            'licenseStream.Close();

            '#End Region

            '''/// *** Documents Editor Examples (Un-Comment to run each example demo methods) ***

            '#Region "Here are the sample methods call, how to convert document to HTML DOM."

            ' Get HTML document content.
            Common.sourceFile = "source.html"
            ConvertDocumentToHTMLDOM.GetHTMLContents()

            ' Get HTML document content with external resource prefix.
            Common.sourceFile = "source.html"
            ConvertDocumentToHTMLDOM.GetHTMLContentsWithExternalResources()

            ' Get HTML document with embedded resources.
            Common.sourceFile = "source.html"
            ConvertDocumentToHTMLDOM.GetHTMLContentsWithEmbeddedResources()

            ' Get HTML document BODY tag content.
            Common.sourceFile = "source.html"
            ConvertDocumentToHTMLDOM.GetHTMLBodyTagContents()

            ' Get HTML document BODY tag content with external resource prefix.
            Common.sourceFile = "source.html"
            ConvertDocumentToHTMLDOM.GetHTMLBodyTagContentsWithExternalResources()

            ' Get HTML document external CSS content.
            Common.sourceFile = "source.html"
            ConvertDocumentToHTMLDOM.GetHTMLExternalCSSContents()

            ' Get HTML document external CSS content with external resource prefix.
            Common.sourceFile = "source.html"
            ConvertDocumentToHTMLDOM.GetHTMLExternalCSSContentsWithExternalResources()

            ' Save HTML document specifying resource folder name.
            Common.sourceFile = "source.html"
            Common.resultFile = "result-SaveHTMLDocumentWithResourcesFolder.html"
            ConvertDocumentToHTMLDOM.SaveHTMLDocumentWithResourcesFolder()

            ' Traverse HTML document and save resources by specifying resource folder name.
            Common.sourceFile = "source.html"
            Common.resultFile = "result-TraverseHTMLResourcesAndCSS.html"
            ConvertDocumentToHTMLDOM.TraverseHTMLResourcesAndCSS()

            '#End Region

            '#Region "Here are the sample methods call, how to convert HTML DOM to document."

            ' Get HTML DOM from string content with resources and save to document.
            Common.sourceFile = "source.html"
            Common.resultFile = "result-GetHTMLDOMContentsToDocument.docx"
            ConvertHTMLDOMToDocument.GetHTMLDOMContentsToDocument()

            '#End Region

            '#Region "Here are the sample methods call, how to convert HTML DOM to Word document."

            ' Save to Words document.
            Common.sourceFile = "source.html"
            Common.resultFile = "result-SaveToWordsDocument.docx"
            WorkingWithWordDocuments.SaveToWordsDocument()

            ' Save to Words document with options.
            Common.sourceFile = "source.html"
            ' using this propert to set password for output file.
            Common.sourceFilePassword = "password"
            Common.resultFile = "result-SaveToWordsDocumentWithOptions.docx"
            WorkingWithWordDocuments.SaveToWordsDocumentWithOptions()

            '#End Region

            Console.WriteLine("*** All Methods Executed (Press any key to exit). ***")
            ' On consol hit enter to exit.
            Console.ReadKey()
        End Sub
    End Module
End Namespace