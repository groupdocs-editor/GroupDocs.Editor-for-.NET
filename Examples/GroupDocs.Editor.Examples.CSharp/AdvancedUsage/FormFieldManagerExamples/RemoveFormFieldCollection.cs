using GroupDocs.Editor.Formats;
using GroupDocs.Editor.Options;
using GroupDocs.Editor.Words.FieldManagement;
using System.IO;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates loading, editing and saving Presentation documents with combination of different options and possibilities
    /// </summary>
    internal static class RemoveFormFieldCollection
    {
        internal static void Run()
        {
            //1. Get a path to the input file (or stream with file content).
            //In this case it is sample Docx with three slides.
            string inputFilePath = Constants.SampleLegacyFormFields_docx;

            //2. Create stream from this path
            using (FileStream fs = File.OpenRead(inputFilePath))
            {
                //3. Create load options for this document
                WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
                //3.1. In case if input document is password-protected, we can specify password for its opening...
                loadOptions.Password = "some_password_to_open_a_document";
                //3.2. ...but, because document is unprotected, this password will be ignored

                //4. Load document with options to the Editor instance
                using (Editor editor = new Editor(delegate { return fs; }, delegate { return loadOptions; }))
                {
                    //4.1. read FormFieldManager instance
                    FormFieldManager fieldManager = editor.FormFieldManager;
                    //4.1. read FormFieldCollection in the document.
                    FormFieldCollection collection = fieldManager.FormFieldCollection;

                    //4.2. Remove a specific text form field
                    TextFormField textField = collection.GetFormField<TextFormField>("Text1");
                    fieldManager.RemoveFormFiled(textField);
                    collection = fieldManager.FormFieldCollection;

                    //4.3. Remove multiple form fields
                    textField = collection.GetFormField<TextFormField>("Text7");
                    CheckBoxForm checkBoxForm = collection.GetFormField<CheckBoxForm>("Check2");
                    fieldManager.RemoveFormFields(new IFormField[] { textField, checkBoxForm });
                    collection = fieldManager.FormFieldCollection;

                    //5. Create document save options
                    WordProcessingFormats docFormat = WordProcessingFormats.Docx;
                    WordProcessingSaveOptions saveOptions = new WordProcessingSaveOptions(docFormat);

                    //5.1. If document is really huge and causes OutOfMemoryException, you can set memory optimization option
                    saveOptions.OptimizeMemoryUsage = true;

                    //5.2. You can protect document from writing (make it Allow Only FormFields) with password
                    saveOptions.Protection = new WordProcessingProtection(WordProcessingProtectionType.AllowOnlyFormFields, "write_password");

                    //6. Save it
                    //6.2. Prepare stream for saving
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        //6.3. Save
                        editor.Save(outputStream, saveOptions);
                    }
                }
            }
            System.Console.WriteLine("RemoveFormFieldCollection routine has successfully finished");
        }
    }
}