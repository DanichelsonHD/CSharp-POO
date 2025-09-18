namespace Secao12.exercicio_01.services
{
    class PaypalService : IOnlinePaymentService
    {
        public const double MonthInterest = 0.01;
        public const double Fee = 0.02;
        
        public double PaymentFee(double Amount) => Amount * Fee;
        public double Interest(double Amount, int Months) => Amount * MonthInterest * Months;
    }
}