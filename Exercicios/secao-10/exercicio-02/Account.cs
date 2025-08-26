using System.Globalization;

namespace Secao10.exercicio_02
{
    class Account
    {
        public int Number { get; private set; }
        public string Holder { get; private set; }
        public double Balance { get; private set; }
        public double WithdrawLimit { get; private set; }

        public Account(string Number, string Holder, string Balance, string WithdrawLimit)
        {
            this.Number = int.Parse(Number);
            this.Holder = Holder;
            this.Balance = double.Parse(Balance, CultureInfo.InvariantCulture);
            this.WithdrawLimit = double.Parse(WithdrawLimit, CultureInfo.InvariantCulture);
        }
        public Account(int Number, string Holder, double Balance, double WithdrawLimit)
        {
            this.Number = Number;
            this.Holder = Holder;
            this.Balance = Balance;
            this.WithdrawLimit = WithdrawLimit;
        }
        public void Deposit(double Amount) => Balance += Amount;
        public void Deposit(string Amount) => Deposit(double.Parse(Amount, CultureInfo.InvariantCulture));
        public void Withdraw(double Amount)
        {
            if (Amount > WithdrawLimit) throw new WithdrawException("The amount exceeds withdraw limit");
            else if (Amount > Balance) throw new WithdrawException("Not enough balance");

            Balance -= Amount;
        }
        public void Withdraw(string Amount) => Withdraw(double.Parse(Amount, CultureInfo.InvariantCulture));
    }
}