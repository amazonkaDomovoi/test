using System;

namespace OOP_HM.BankSystem.Accounts
{
    public class Citizen : Person, IHasId
    {
        public Citizen()
        {
            Console.WriteLine($"Citizen is created");
        }

        public string Id => $"{Name}{Age}";
    }
}
