---
id: migration-notes
url: editor/net/migration-notes
title: Migration Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
### Why To Migrate?

Here are the key reasons to use the new updated API provided by GroupDocs.Editor for .NET since version 19.9:

*   **Editor** class introduced as a **single entry point** to manage the document editing process to any supported file format (instead of **EditorHander** class from previous versions).     
*   Product architecture was redesigned from scratch in order to **decreased memory usage** (from 10% to 400% approx. depending on document type).    
*   Document **editing** and **saving options simplified** so it’s easy to instantiate proper options class and control over document editing and saving processes.  
    

### How To Migrate?

Here is a brief comparison of how to edit document in HTML form using old and new API.  

**Old coding style**

```csharp
			string documentPath = @"C:\sample.docx"; 
     		// Obtain document stream
            Stream sourceStream = File.Open(documentPath, FileMode.Open, FileAccess.Read);

            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
            {
                // Obtain HTML document content
                string htmlContent = htmlDoc.GetContent();
				
				// Edit html in WYSIWYG-editor...
				// ...
 
				// Save edited html to original document format
                using (OutputHtmlDocument editedHtmlDoc = OutputHtmlDocument.FromMarkup(htmlContent, Path.Combine(Common.sourcePath, Common.resultResourcesFolder)))
                {
                    using (System.IO.FileStream outputStream = System.IO.File.Create(@"C:\output\edited.docx"))
                    {
                        WordProcessingSaveOptions  saveOptions = new WordProcessingSaveOptions();
                        EditorHandler.ToDocument(editedHtmlDoc, outputStream, saveOptions);
                    }
                }
            }

            // close stream object to release file for other methods.
            sourceStream.Close();
```

**New coding style**

```csharp
string documentPath = @"C:\sample.docx"; 
using (Editor editor = new Editor(documentPath))
{
    // Obtain editable document from original DOCX document
    EditableDocument editableDocument = editor.Edit();
	string htmlContent = editableDocument.GetEmbeddedHtml();
    // Pass htmlContent to WYSIWYG editor and edit there...
    // ...
 
    // Save edited EditableDocument object to some WordProcessing format - DOC for example
    WordProcessingSaveOptions saveOptions = new WordProcessingSaveOptions(Formats.WordProcessingFormats.Docx);
    editor.Save(editableDocument, @"C:\output\edited.docx", saveOptions);
}
```

For more code examples and specific use cases please refer to our [Developer Guide]({{< ref "editor/net/developer-guide/_index.md" >}}) documentation or [GitHub](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET) samples and showcases.
