namespace Secao5
{
    class Account
    {
        public static int AccountNumber { get; private set; }
        public string HoldersName { get; set; }
        public float Balance { get; private set; }
        private const float TAX = 5.0f;

        public Account(int number, string holdersName)
        {
            AccountNumber = number;
            HoldersName = holdersName;
        }

        public Account(int number, string holdersName, float initialDeposit) : this(number, holdersName)
        {
            Deposit(initialDeposit);
        }

        public void Deposit(float amount) { if (amount > 0) Balance += amount; }
        public void WithDraw(float amount) { if (amount > 0) Balance -= amount + TAX; }
        public void ChangeHoldersName(string newName) => HoldersName = newName;

        public override string ToString()
        {
            return $"Conta: {AccountNumber}, Titular: {HoldersName}, Saldo: R$ {Balance:F2}";
        }
    }
}