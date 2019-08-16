using System;

namespace GroupDocs.Editor.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to set Metered license.
    /// Learn more about Metered license at https://purchase.groupdocs.com/faqs/licensing/metered.
    /// </summary>
    internal static class MeteredLicenseSetter
    {
        internal static void Run()
        {
            string publicKey = "*****";
            string privateKey = "*****";

            Metered metered = new Metered();
            metered.SetMeteredKey(publicKey, privateKey);

            Console.WriteLine("License set successfully.");
        }
    }
}