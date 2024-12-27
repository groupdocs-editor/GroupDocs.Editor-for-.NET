using GroupDocs.Editor.Formats;
using GroupDocs.Editor.Options;
using GroupDocs.Editor.Words.FieldManagement;
using System.IO;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates how to edit form fields in a Word document using GroupDocs.Editor for .NET.
    /// </summary>
    internal static class EditFormFieldCollection
    {
        /// <summary>
        /// Runs the example to demonstrate loading, editing, and saving form fields in a document.
        /// </summary>
        internal static void Run()
        {
            // 1. Get a path to the input file (or stream with file content).
            // In this case, it is a sample DOCX with form fields.
            string inputFilePath = Constants.SampleLegacyFormFields_docx;

            // 2. Create a stream from this path
            using (FileStream fs = File.OpenRead(inputFilePath))
            {
                // 3. Create load options for this document
                WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
                // 3.1. If the input document is password-protected, specify the password for its opening...
                loadOptions.Password = "some_password_to_open_a_document";
                // 3.2. ...but, because the document is unprotected, this password will be ignored

                // 4. Load the document with options into the Editor instance
                using (Editor editor = new Editor(fs, loadOptions))
                {
                    // 4.1. Read the FormFieldManager instance
                    FormFieldManager fieldManager = editor.FormFieldManager;
                    // 4.2. Read the FormFieldCollection in the document
                    FormFieldCollection collection = fieldManager.FormFieldCollection;

                    // 4.3. Update a specific text form field
                    TextFormField textField = collection.GetFormField<TextFormField>("Text1");
                    textField.LocaleId = 1029;
                    textField.Value = "new Value";
                    fieldManager.UpdateFormFiled(collection);

                    // 5. Create document save options
                    WordProcessingFormats docFormat = WordProcessingFormats.Docx;
                    WordProcessingSaveOptions saveOptions = new WordProcessingSaveOptions(docFormat);

                    // 5.1. If the document is large and causes OutOfMemoryException, set the memory optimization option
                    saveOptions.OptimizeMemoryUsage = true;

                    // 5.2. Protect the document from writing (allow only form fields) with a password
                    saveOptions.Protection = new WordProcessingProtection(WordProcessingProtectionType.AllowOnlyFormFields, "write_password");

                    // 6. Save the document
                    // 6.1. Prepare a stream for saving
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        // 6.2. Save the document
                        editor.Save(outputStream, saveOptions);
                    }
                }
            }
            System.Console.WriteLine("EditFormFieldCollection routine has successfully finished");
        }
    }

}