namespace Secao12.exercicio_exemplo.sem_interface.Services
{
    class BrazilTaxService
    {
        public double Tax(double Amount)
        {
            if (Amount <= 100.0) return Amount * 0.2;
            return Amount * 0.15;
        }
    }
}