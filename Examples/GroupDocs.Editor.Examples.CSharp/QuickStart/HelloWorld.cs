using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.QuickStart
{
    internal static class HelloWorld
    {
        internal static void Run()
        {
            string documentPath = Constants.SAMPLE_DOCX;

            System.Console.WriteLine(documentPath);
            using (Editor editor = new Editor(documentPath))//Load document into the Editor instance
            {
                // Obtain editable document from original DOCX document
                WordProcessingEditOptions editOptions = new WordProcessingEditOptions();
                EditableDocument editableDocument = editor.Edit(editOptions);//Open document for editing

                // Pass EditableDocument object to WYSIWYG editor and edit there...
                // ...
                
                //Prepare saving path
                string savePath = System.IO.Path.Combine(Constants.GetOutputDirectoryPath(), "HelloWorldOutput.doc");
                //Prepare save options for some WordProcessing format - DOC for example
                WordProcessingSaveOptions saveOptions = new WordProcessingSaveOptions(Formats.WordProcessingFormats.Doc);
                // Save edited EditableDocument object to specified path with specified options
                editor.Save(editableDocument, savePath, saveOptions);
            }
        }
    }
}