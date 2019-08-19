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

            System.Console.WriteLine("Metered license was set successfully.");

            decimal consumedQuantity = Metered.GetConsumptionQuantity();
            decimal consumedCredits =  Metered.GetConsumptionCredit();
            System.Console.WriteLine(string.Format("Consumed quantity is {0} bytes, and {1} credits are consumed", consumedQuantity, consumedCredits));
        }
    }
}