'ExStart:WorkingWithWordDocumentsClass
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports GroupDocs.Editor
Imports GroupDocs.Editor.Words.HtmlToWords

Namespace GroupDocsEditor.Examples.VisualBasic
    ''' <summary>
    ''' Here are code samples to show how to convert HTML DOM to word document.
    ''' </summary>
    Public NotInheritable Class WorkingWithWordDocuments
        Private Sub New()
        End Sub
        'ExStart:SaveToWordsDocument
        ''' <summary>
        ''' Save to Words document.
        ''' </summary>
        Public Shared Sub SaveToWordsDocument()
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
        'ExEnd:SaveToWordsDocument

        'ExStart:SaveToWordsDocumentWithOptions
        ''' <summary>
        ''' Save to Words document with options.
        ''' </summary>
        Public Shared Sub SaveToWordsDocumentWithOptions()
            ' Obtain document stream
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Using htmlDoc As InputHtmlDocument = EditorHandler.ToHtml(sourceStream)
                ' Obtain HTML document content
                Dim htmlContent As String = htmlDoc.GetContent()

                Using editedHtmlDoc As OutputHtmlDocument = OutputHtmlDocument.FromMarkup(htmlContent, Path.Combine(Common.sourcePath, Common.resultResourcesFolder))
                    Using outputStream As System.IO.FileStream = System.IO.File.Create(Path.Combine(Common.resultPath, Common.resultFile))
                        Dim saveOptions As New WordsSaveOptions(WordFormats.Docx, Common.sourceFilePassword)
                        saveOptions.Locale = CultureInfo.GetCultureInfo(1)
                        saveOptions.LocaleBi = CultureInfo.GetCultureInfo(1)
                        saveOptions.LocaleFarEast = CultureInfo.GetCultureInfo(2)
                        EditorHandler.ToDocument(editedHtmlDoc, outputStream, saveOptions)
                    End Using
                End Using
            End Using

            ' close stream object to release file for other methods.
            sourceStream.Close()
        End Sub
        'ExEnd:SaveToWordsDocumentWithOptions
    End Class
End Namespace
'ExEnd:WorkingWithWordDocumentsClass