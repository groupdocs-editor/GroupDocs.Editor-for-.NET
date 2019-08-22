using System;
using System.IO;

namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates how to set license from file and stream.
    /// </summary>
    /// <remarks>
    /// The SetLicense method overload, that accepts string, attempts to set a license from several locations relative to the executable and GroupDocs.Editor.dll.
    /// You can also use the additional overload to load a license from a stream, this is useful for instance when the 
    /// License is stored as an embedded resource. 
    /// </remarks>
    internal static class LicenseSetter
    {
        internal static void Run()
        {
            /*
             We do not ship any license with this example.
             Visit the GroupDocs site to obtain either a temporary or permanent license.
             Learn more about licensing at https://purchase.groupdocs.com/faqs/licensing.
             Learn how to request temporary license at https://purchase.groupdocs.com/temporary-license
            */


            GroupDocs.Editor.License license = new License();

            //For setting license from file through file path:
            string licensePath = "D:/Some path/to license/file.lic";
            if (File.Exists(licensePath))
            {
                license.SetLicense(licensePath);
            }
            else
            {
                Console.WriteLine("Cannot find license file '{0}'", licensePath);
            }

            
            //For setting license from stream
            try
            {
                using (FileStream stream = File.OpenRead(licensePath))
                {
                    license.SetLicense(stream);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Cannot find license file. {0}", ex.Message);
            }
        }
    }
}