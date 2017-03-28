using OOP_HM.BankSystem;
using System;
using System.Collections.Generic;

namespace OOP_HM.BankSystem
{
    public class Bank : IBank
    {
       private Dictionary<string, int> accounts = new Dictionary<string, int>();

        public Bank() {
            Console.WriteLine("A bank is created.");
        }

       public void PutMoneyToAccount(IHasId accountHolder, int quantity) {
            if (accounts.ContainsKey(accountHolder.Id))
            {
                accounts[accountHolder.Id] += quantity;
            }
            else {
                accounts.Add(accountHolder.Id, quantity);
            }
            Console.WriteLine($"{accountHolder.Id} put {quantity} money to account.");
        }

       public void GetMoneyFromAccount(IHasId accountHolder, int quantity)
        {
            if (accounts.ContainsKey(accountHolder.Id))
            {
                accounts[accountHolder.Id]-= quantity;
                Console.WriteLine($"{accountHolder.Id} get {quantity} money from account.");
            }
            else
            {
                throw new ArgumentException("There is no account with such Id!");
            }
        }

        public int GetAccountBalance(IHasId accountHolder) {
            if (accounts.ContainsKey(accountHolder.Id))
            {
               return accounts[accountHolder.Id];
            }
            else
            {
                throw new ArgumentException("There is no account with such Id!");
            }
        }
    }
}
