'ExStart:CommonClass
Imports System.IO
Imports System.Collections.Generic
Imports GroupDocs.Editor
Imports System.Reflection

Namespace GroupDocsEditor.Examples.VisualBasic
    Public NotInheritable Class Common
        Private Sub New()
        End Sub
        'ExStart:CommonProperties
        ' storagePath property to set source file/s directory
        Public Shared sourcePath As String = Path.Combine(Environment.CurrentDirectory, "../../../../Data/SourceFiles/")

        ' sourceResourcesPath property to set source resources directory
        Public Shared sourceResourcesPath As String = Path.Combine(Environment.CurrentDirectory, "../../../../Data/SourceFiles/")

        ' outputPath property to set output file/s directory
        Public Shared resultPath As String = Path.Combine(Environment.CurrentDirectory, "../../../../Data/OuputFiles")

        ' resultResourcesPath property to set output resources directory
        Public Shared resultResourcesPath As String = Path.Combine(Environment.CurrentDirectory, "../../../../Data/OuputFiles")

        ' licensePath property to set GroupDocs.Editor license file anme and path
        Public Shared licensePath As String = Path.Combine(Environment.CurrentDirectory, "GroupDocs.editor.lic")

        ' sourceFile property to set input source file
        Public Shared sourceFile As String = "source.docx"

        ' resultResourcesFolder property to set input resources folder name
        Public Shared sourceResourcesFolder As String = "Resources"

        ' resultResourcesFolder property to set output resources folder name
        Public Shared resultResourcesFolder As String = "Resources"

        ' sourceFilePassword property to set input source file password
        Public Shared sourceFilePassword As String = "SomePassword"

        ' targetFile property to set input target file
        Public Shared resultFile As String = "result.docx"

        'ExEnd:CommonProperties

        'ExStart:ApplyLicense
        ''' <summary>
        ''' Applies GroupDocs.Editor license
        ''' </summary>
        Public Shared Sub ApplyLicense(filepath As String)
            ' Instantiate GroupDocs.Editor license
            Dim license As New GroupDocs.Editor.License()

            ' Apply GroupDocs.Editor license using license path
            license.SetLicense(filepath)
        End Sub

        ''' <summary>
        ''' Applies GroupDocs.Editor license using stream input
        ''' </summary>
        Public Shared Sub ApplyLicense(licenseStream As Stream)
            ' Instantiate GroupDocs.Editor license
            Dim license As New GroupDocs.Editor.License()

            ' Apply GroupDocs.Editor license using license file stream
            license.SetLicense(licenseStream)
        End Sub
        'ExEnd:ApplyLicense
    End Class
End Namespace
'ExEnd:CommonClass