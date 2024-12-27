using GroupDocs.Editor.Options;
using GroupDocs.Editor.Words.FieldManagement;
using System.IO;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{/// <summary>
 /// This example demonstrates loading a FormFieldCollection and reading form fields.
 /// </summary>
    internal static class LegacyFormFieldCollection
    {
        /// <summary>
        /// Runs the example to demonstrate loading, editing, and reading form fields from a document.
        /// </summary>
        internal static void Run()
        {
            // 1. Get a path to the input file (or stream with file content).
            // In this case, it is a sample Docx with form fields.
            string inputFilePath = Constants.SampleLegacyFormFields_docx;

            // 2. Create a stream from this path
            using (FileStream fs = File.OpenRead(inputFilePath))
            {
                // 3. Create load options for this document
                WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
                // 3.1. In case the input document is password-protected, we can specify a password for its opening...
                loadOptions.Password = "some_password_to_open_a_document";
                // 3.2. ...but, because the document is unprotected, this password will be ignored

                // 4. Load the document with options to the Editor instance
                using (Editor editor = new Editor(fs, loadOptions))
                {
                    // 4.1. Read the FormFieldManager instance
                    FormFieldManager fieldManager = editor.FormFieldManager;
                    // 4.2. Read the FormFieldCollection in the document
                    FormFieldCollection collection = fieldManager.FormFieldCollection;
                    foreach (var formField in collection)
                    {
                        switch (formField.Type)
                        {
                            case FormFieldType.Text:
                                TextFormField textFormField = collection.GetFormField<TextFormField>(formField.Name);
                                System.Console.WriteLine("TextFormField detected, name: {0}, value: {1}", formField.Name, textFormField.Value);
                                break;
                            case FormFieldType.CheckBox:
                                CheckBoxForm checkBoxFormField = collection.GetFormField<CheckBoxForm>(formField.Name);
                                System.Console.WriteLine("CheckBoxForm detected, name: {0}, value: {1}", formField.Name, checkBoxFormField.Value);
                                break;
                            case FormFieldType.Date:
                                DateFormField dateFormField = collection.GetFormField<DateFormField>(formField.Name);
                                System.Console.WriteLine("DateFormField detected, name: {0}, value: {1}", formField.Name, dateFormField.Value);
                                break;
                            case FormFieldType.Number:
                                NumberFormField numberFormField = collection.GetFormField<NumberFormField>(formField.Name);
                                System.Console.WriteLine("NumberFormField detected, name: {0}, value: {1}", formField.Name, numberFormField.Value);
                                break;
                            case FormFieldType.DropDown:
                                DropDownFormField dropDownFormField = collection.GetFormField<DropDownFormField>(formField.Name);
                                System.Console.WriteLine("DropDownFormField detected, name: {0}, value selected: {1}", formField.Name, dropDownFormField.Value[dropDownFormField.SelectedIndex]);
                                break;
                        }
                    }
                }
            }
            System.Console.WriteLine("ReadFormFieldCollection routine has successfully finished");
        }
    }
}