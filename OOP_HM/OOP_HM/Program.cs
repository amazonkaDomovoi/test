using OOP_HM.BankSystem;
using OOP_HM.BankSystem.Accounts;
using OOP_HM.Loggers;
using System;

namespace OOP_HM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test currency__________________________________________________________");
            TestCurrency();

            Console.WriteLine($"{Environment.NewLine}Test bank system_______________________________________________________");
            TestBank();

            Console.WriteLine($"{Environment.NewLine}Test loggers_______________________________________________________");
            TestLogger();

            Console.ReadKey();
        }

        public static void TestCurrency() {
            var emptyCurrency = new Currency();
            Console.WriteLine("An empty currency is created! " +
                Environment.NewLine +
                $"Dollars: {emptyCurrency._dollars}, Cents: {emptyCurrency._cents}"+
                Environment.NewLine);

            var currency1 = new Currency(2.55);
            var currency2 = new Currency(2,55);

            Console.WriteLine("Two currency classes are created with the same value and diffrent constructors: " +
                Environment.NewLine +
                $"Cyrrency 1 - {currency1.ToString()}" + Environment.NewLine +
                $"Cyrrency 2 - {currency2.ToString()}" + Environment.NewLine);

            var currencySum = currency1.Add(currency2);
            Console.WriteLine($"Sum of previously created currency values: {currencySum.ToString()}");

            var increaedCurrency = currency1.Myltiply(2);
            Console.WriteLine($"Increased currency {currency1.ToString()} value in 2 times: {increaedCurrency.ToString()}");
        }

        public static void TestBank() {
            var citizenAccount = new Citizen() { Name = "Petro", Age = 23 };
            var legalPersonAccount = new LegalPerson() { FirmName = "Zimaletto" };

            Console.WriteLine();

            var bank = new Bank();           
            bank.PutMoneyToAccount(citizenAccount, 1000);
            bank.PutMoneyToAccount(legalPersonAccount, 100000);            
            bank.GetMoneyFromAccount(citizenAccount, 500);

            Console.WriteLine();

            Console.WriteLine($"Citizen balance: {bank.GetAccountBalance(citizenAccount)}");
            Console.WriteLine($"Legalperson balance: {bank.GetAccountBalance(legalPersonAccount)}");
        }

        public static void TestLogger() {
            var consoleLogger = new ConsoleLogger();
            var fileLogger = new FileLogger("D:\\log.txt");

            var agregator = new AggregateLogger();
            agregator.RegisterLoggers(consoleLogger, fileLogger);

            agregator.Log("log message 1");
            agregator.Log("log message 2");
            agregator.Log("log message 3");
        }
    }
}
