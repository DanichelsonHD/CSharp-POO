using Secao12.exercicio_01.entities;

namespace Secao12.exercicio_01.services
{
    class ContractService
    {
        public IOnlinePaymentService _paymentService { get; private set; }

        public ContractService(IOnlinePaymentService _paymentService) => this._paymentService = _paymentService;
        public void ProcessContract(Contract contract, int months)
        {
            double quota = contract.TotalValue / months;

            for (int index = 1; index <= months; index++)
            {
                DateTime newDate = contract.Date.AddMonths(index);
                double interest = _paymentService.Interest(quota, index) + quota;
                double paymentFee = _paymentService.PaymentFee(interest) + interest;
                contract.AddInstallment(new Installment(newDate, paymentFee));
            }
        }
    }
}