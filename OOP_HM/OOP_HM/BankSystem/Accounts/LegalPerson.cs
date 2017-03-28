using System;

namespace OOP_HM.BankSystem.Accounts
{
    public class LegalPerson : IHasId
    {
        public LegalPerson()
        {
            Console.WriteLine($"LegalPerson is created");
        }
        public string FirmName { get; set; }
        public string Id => $"{FirmName}";
    }
}
