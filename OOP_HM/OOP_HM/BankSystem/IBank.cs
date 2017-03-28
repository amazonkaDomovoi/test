namespace OOP_HM.BankSystem
{
    public interface IBank
    {
        int GetAccountBalance(IHasId accountHolder);
        void GetMoneyFromAccount(IHasId accountHolder, int quantity);
        void PutMoneyToAccount(IHasId accountHolder, int quantity);
    }
}