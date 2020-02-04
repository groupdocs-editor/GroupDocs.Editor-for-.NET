using System;
using System.IO;
using GroupDocs.Editor.Formats;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates loading, editing and saving a password-protected encoded Spreadsheet document,
    /// including setting opening and write protection on output document
    /// </summary>
    internal static class WorkingWithSpreadsheetPasswordProtected
    {
        internal static void Run()
        {
            //1. Get a path to the input file (or stream with file content).
            //In this case it is sample XLS (pre-OOXML) with one tab, and it is encoded with password. Let's try to open it.
            string inputFilePath = Constants.SAMPLE_XLS_PROTECTED;

            //1.1. First of all let's try to open document without password at all
            Editor editor = new Editor(inputFilePath);
            try
            {
                editor.Edit();
            }
            catch (GroupDocs.Editor.PasswordRequiredException)
            {
                Console.WriteLine("Cannot edit a document, because it is password-protected, so the password is required");
            }
            editor.Dispose();

            //1.2. Now let's try to specify incorrect password
            Options.SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            loadOptions.Password = "incorrect_password";
            editor = new Editor(inputFilePath, delegate { return loadOptions; });
            try
            {
                editor.Edit();
            }
            catch (GroupDocs.Editor.IncorrectPasswordException)
            {
                Console.WriteLine("Cannot edit a document, because it is password-protected, and password was specified, but it is incorrect");
            }
            editor.Dispose();

            //1.3. Finally, let's open file with valid password
            loadOptions.Password = "excel_password";
            
            //1.4. Also let's specify memory optimization option
            loadOptions.OptimizeMemoryUsage = true;

            editor = new Editor(inputFilePath, delegate { return loadOptions; });
            
            //2. Create and adjust editing options
            Options.SpreadsheetEditOptions editOptions = new SpreadsheetEditOptions();

            //3. Create intermediate EditableDocument
            using (EditableDocument beforeEdit = editor.Edit(editOptions))
            {
                //4. Create save options
                SpreadsheetFormats xlsmFormat = SpreadsheetFormats.Xlsm;
                Options.SpreadsheetSaveOptions saveOptions = new SpreadsheetSaveOptions(SpreadsheetFormats.Xlsm);
                
                //4.1. Set new opening password
                saveOptions.Password = "new password";

                //4.2. Set write protection
                saveOptions.WorksheetProtection = new WorksheetProtection(WorksheetProtectionType.All, "write password");

                //5. Save document without modification
                //5.1. Prepare output filename and path
                string outputFilename = Path.GetFileNameWithoutExtension(inputFilePath) + "." + xlsmFormat.Extension;
                string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), outputFilename);
                
                //5.2. Create output stream
                using (FileStream outputStream = File.Create(outputPath))
                {//5.3. Save
                    editor.Save(beforeEdit, outputStream, saveOptions);
                }
            }

            //6. Dispose Editor instance
            editor.Dispose();

            Console.WriteLine("WorkingWithSpreadsheetPasswordProtected routine has successfully finished. Editor instance was manually {0}", 
                editor.IsDisposed ? "disposed" : "NOT disposed");
        }
    }
}