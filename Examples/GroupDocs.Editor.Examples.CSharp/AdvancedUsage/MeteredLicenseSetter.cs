namespace GroupDocs.Editor.Examples.CSharp.AdvancedUsage
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
            try
            {
                metered.SetMeteredKey(publicKey, privateKey);
                System.Console.WriteLine("Metered license was set successfully.");
                decimal consumedQuantity = Metered.GetConsumptionQuantity();
                System.Console.WriteLine("Consumed bytes quantity is {0}.", consumedQuantity);
                decimal consumedCredits = Metered.GetConsumptionCredit();
                System.Console.WriteLine("Consumed credits count is {0}.", consumedCredits);
            }
            catch
            {
                System.Console.WriteLine("Authentication failed with specified credentials.");
            }
        }
    }
}