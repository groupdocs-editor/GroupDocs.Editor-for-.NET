'ExStart:ConvertDocumentToHTMLDOMClass
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports GroupDocs.Editor
Imports GroupDocs.Editor.HtmlCss.Resources.Fonts
Imports GroupDocs.Editor.HtmlCss.Resources.Images
Imports GroupDocs.Editor.HtmlCss.Resources.Textual

Namespace GroupDocsEditor.Examples.VisualBasic
    ''' <summary>
    ''' Here are code samples to show how to convert document from source format to its HTML representation that can be edited in any WYSIWYG editor.
    ''' </summary>
    Public NotInheritable Class ConvertDocumentToHTMLDOM
        Private Sub New()
        End Sub
        'ExStart:GetHTMLContents
        ''' <summary>
        ''' Get HTML document content.
        ''' </summary>
        Public Shared Sub GetHTMLContents()
            ' Obtain document stream
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Using htmlDoc As InputHtmlDocument = EditorHandler.ToHtml(sourceStream)
                ' Obtain HTML document content
                Dim bodyContent As String = htmlDoc.GetContent()
                Console.WriteLine(bodyContent)
            End Using

            ' close stream object to release file for other methods.
            sourceStream.Close()
        End Sub
        'ExEnd:GetHTMLContents

        'ExStart:GetHTMLContentsWithExternalResources
        ''' <summary>
        ''' Get HTML document content with external resource prefix.
        ''' </summary>
        Public Shared Sub GetHTMLContentsWithExternalResources()
            ' Obtain document stream
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Using htmlDoc As InputHtmlDocument = EditorHandler.ToHtml(sourceStream)
                Dim externalResourcePrefix As String = "GetResource?htmlDocumentFolderName=" + Common.sourceResourcesFolder + "&resourceFilename=Picture 3.png"

                ' Obtain HTML document content   
                Dim bodyContent As String = htmlDoc.GetContent(externalResourcePrefix)
                Console.WriteLine(bodyContent)
            End Using

            ' close stream object to release file for other methods.
            sourceStream.Close()
        End Sub
        'ExEnd:GetHTMLContentsWithExternalResources

        'ExStart:GetHTMLContentsWithEmbeddedResources
        ''' <summary>
        ''' Get HTML document with embedded resources.
        ''' </summary>
        Public Shared Sub GetHTMLContentsWithEmbeddedResources()
            ' Obtain document stream
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Using htmlDoc As InputHtmlDocument = EditorHandler.ToHtml(sourceStream)
                '  Obtain HTML document with embedded resources
                Dim cssContent As String = htmlDoc.GetEmbeddedHtml()

                Console.WriteLine(cssContent)
            End Using

            ' close stream object to release file for other methods.
            sourceStream.Close()
        End Sub
        'ExEnd:GetHTMLContentsWithEmbeddedResources

        'ExStart:GetHTMLBodyTagContents
        ''' <summary>
        ''' Get HTML document BODY tag content.
        ''' </summary>
        Public Shared Sub GetHTMLBodyTagContents()
            ' Obtain document stream
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Using htmlDoc As InputHtmlDocument = EditorHandler.ToHtml(sourceStream)
                '  Obtain HTML document body content
                Dim bodyContent As String = htmlDoc.GetBodyContent()

                Console.WriteLine(bodyContent)
            End Using

            ' close stream object to release file for other methods.
            sourceStream.Close()
        End Sub
        'ExEnd:GetHTMLBodyTagContents

        'ExStart:GetHTMLBodyTagContentsWithExternalResources
        ''' <summary>
        ''' Get HTML document BODY tag content with external resource prefix.
        ''' </summary>
        Public Shared Sub GetHTMLBodyTagContentsWithExternalResources()
            ' Obtain document stream
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Using htmlDoc As InputHtmlDocument = EditorHandler.ToHtml(sourceStream)
                Dim externalResourcePrefix As String = "GetResource?htmlDocumentFolderName=" + Common.sourceResourcesFolder + "&resourceFilename=Picture 3.png"
                '  Obtain HTML document body content   
                Dim bodyContent As String = htmlDoc.GetBodyContent(externalResourcePrefix)

                Console.WriteLine(bodyContent)
            End Using

            ' close stream object to release file for other methods.
            sourceStream.Close()
        End Sub
        'ExEnd:GetHTMLBodyTagContentsWithExternalResources

        'ExStart:GetHTMLExternalCSSContents
        ''' <summary>
        ''' Get HTML document external CSS content.
        ''' </summary>
        Public Shared Sub GetHTMLExternalCSSContents()
            ' Obtain document stream
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Using htmlDoc As InputHtmlDocument = EditorHandler.ToHtml(sourceStream)
                '  Obtain CSS content
                Dim cssContent As String = htmlDoc.GetCssContent()

                Console.WriteLine(cssContent)
            End Using

            ' close stream object to release file for other methods.
            sourceStream.Close()
        End Sub
        'ExEnd:GetHTMLExternalCSSContents

        'ExStart:GetHTMLExternalCSSContentsWithExternalResources
        ''' <summary>
        ''' Get HTML document external CSS content with external resource prefix.
        ''' </summary>
        Public Shared Sub GetHTMLExternalCSSContentsWithExternalResources()
            ' Obtain document stream
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Using htmlDoc As InputHtmlDocument = EditorHandler.ToHtml(sourceStream)
                Dim externalResourcePrefix As String = "GetResource?htmlDocumentFolderName=" + Common.sourceResourcesFolder + "&resourceFilename=Picture 3.png"
                '  Obtain CSS content
                Dim cssContent As String = htmlDoc.GetCssContent(externalResourcePrefix)

                Console.WriteLine(cssContent)
            End Using

            ' close stream object to release file for other methods.
            sourceStream.Close()
        End Sub
        'ExEnd:GetHTMLExternalCSSContentsWithExternalResources

        'ExStart:SaveHTMLDocument
        ''' <summary>
        ''' Save HTML document.
        ''' </summary>
        Public Shared Sub SaveHTMLDocument()
            ' Obtain document stream
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Using htmlDoc As InputHtmlDocument = EditorHandler.ToHtml(sourceStream)
                htmlDoc.Save(Path.Combine(Common.resultPath, Common.resultFile))
            End Using

            ' close stream object to release file for other methods.
            sourceStream.Close()
        End Sub
        'ExEnd:SaveHTMLDocument

        'ExStart:SaveHTMLDocumentWithResourcesFolder
        ''' <summary>
        ''' Save HTML document specifying resource folder name.
        ''' </summary>
        Public Shared Sub SaveHTMLDocumentWithResourcesFolder()
            ' Obtain document stream
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Using htmlDoc As InputHtmlDocument = EditorHandler.ToHtml(sourceStream)
                ' saving output html file.
                htmlDoc.Save(Path.Combine(Common.resultPath, Common.resultFile), Path.Combine(Common.resultPath, Common.resultResourcesFolder))
            End Using

            ' close stream object to release file for other methods.
            sourceStream.Close()
        End Sub
        'ExEnd:SaveHTMLDocumentWithResourcesFolder

        'ExStart:TraverseHTMLResourcesAndCSS
        ''' <summary>
        ''' Traverse HTML document and save resources by specifying resource folder name.
        ''' </summary>
        Public Shared Sub TraverseHTMLResourcesAndCSS()
            ' Obtain document stream
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Using htmlDoc As InputHtmlDocument = EditorHandler.ToHtml(sourceStream)
                For Each fontResource As IFontResource In htmlDoc.FontResources
                    Console.WriteLine(fontResource.FilenameWithExtension)
                    Console.WriteLine(fontResource.Name)
                    Console.WriteLine(fontResource.ByteContent)
                    Console.WriteLine(fontResource.TextContent)

                    Dim pathToResource As String = String.Format(Path.Combine(Common.resultPath, Common.resultResourcesFolder) + "\{0}", fontResource.FilenameWithExtension)
                    fontResource.Save(pathToResource)
                Next

                For Each imageResource As RasterImageResourceBase In htmlDoc.ImageResources
                    Console.WriteLine(imageResource.FilenameWithExtension)
                    Console.WriteLine(imageResource.ByteContent)
                    Console.WriteLine(imageResource.Name)
                    Console.WriteLine(imageResource.TextContent)
                    Console.WriteLine(imageResource.LinearDimensions.Height)
                    Console.WriteLine(imageResource.LinearDimensions.Width)
                    Console.WriteLine(imageResource.LinearDimensions.IsSquare)

                    Dim pathToResource As String = String.Format(Path.Combine(Common.resultPath, Common.resultResourcesFolder) + "\{0}", imageResource.FilenameWithExtension)
                    imageResource.Save(pathToResource)
                Next

                Dim css As CssText = htmlDoc.Css
                Console.WriteLine(css.FilenameWithExtension)
                Console.WriteLine(css.ByteContent)
                Console.WriteLine(css.Name)
                Console.WriteLine(css.TextContent)
                Console.WriteLine(css.Encoding)

                Dim pathToCss As String = String.Format(Path.Combine(Common.resultPath, Common.resultResourcesFolder) + "\{0}", css.FilenameWithExtension)
                css.Save(pathToCss)

                ' saving output html file.
                htmlDoc.Save(Path.Combine(Common.resultPath, Common.resultFile), Path.Combine(Common.resultPath, Common.resultResourcesFolder))
            End Using

            ' close stream object to release file for other methods.
            sourceStream.Close()
        End Sub
        'ExEnd:TraverseHTMLResourcesAndCSS
    End Class
End Namespace
'ExEnd:ConvertDocumentToHTMLDOMClass