namespace Secao12.exercicio_01.services
{
    interface IOnlinePaymentService
    {
        double PaymentFee(double Amount);
        double Interest(double Amount, int Months);
    }
}