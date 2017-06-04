'ExStart:ConvertHTMLDOMToDocumentClass
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports GroupDocs.Editor
Imports GroupDocs.Editor.Words.HtmlToWords

Namespace GroupDocsEditor.Examples.VisualBasic
    ''' <summary>
    ''' Here are code samples to show how to convert HTML DOM to document.
    ''' </summary>
    Public NotInheritable Class ConvertHTMLDOMToDocument
        Private Sub New()
        End Sub
        'ExStart:GetHTMLDOMContentsToDocument
        ''' <summary>
        ''' Get HTML DOM from string content with resources and save to document.
        ''' </summary>
        Public Shared Sub GetHTMLDOMContentsToDocument()
            ' Obtain document stream
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Using htmlDoc As InputHtmlDocument = EditorHandler.ToHtml(sourceStream)
                ' Obtain HTML document content
                Dim htmlContent As String = htmlDoc.GetContent()

                Using editedHtmlDoc As OutputHtmlDocument = OutputHtmlDocument.FromMarkup(htmlContent, Path.Combine(Common.sourcePath, Common.resultResourcesFolder))
                    Using outputStream As System.IO.FileStream = System.IO.File.Create(Path.Combine(Common.resultPath, Common.resultFile))
                        Dim saveOptions As New WordsSaveOptions()
                        EditorHandler.ToDocument(editedHtmlDoc, outputStream, saveOptions)
                    End Using
                End Using
            End Using

            ' close stream object to release file for other methods.
            sourceStream.Close()
        End Sub
        'ExEnd:GetHTMLDOMContentsToDocument
    End Class
End Namespace
'ExEnd:ConvertHTMLDOMToDocumentClass