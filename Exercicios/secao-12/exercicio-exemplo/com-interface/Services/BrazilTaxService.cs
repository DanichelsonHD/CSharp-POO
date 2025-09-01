namespace Secao12.exercicio_exemplo.com_interface.Services
{
    class BrazilTaxService : ITaxService
    {
        public double Tax(double Amount)
        {
            if (Amount <= 100.0) return Amount * 0.2;
            return Amount * 0.15;
        }
    }
}