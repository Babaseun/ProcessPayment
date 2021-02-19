using ProcessPayment.Domain.Entities;
using ProcessPayment.Domain.IServices;
using System.Threading.Tasks;

namespace ProcessPayment.Domain.Services
{
    public class PaymentService
    {
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IPremiumPaymentGateway _premiumPaymentGateway;


        public PaymentService(ICheapPaymentGateway cheapPaymentGateway,
                              IExpensivePaymentGateway expensivePaymentGateway,
                              IPremiumPaymentGateway premiumPaymentGateway)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _premiumPaymentGateway = premiumPaymentGateway;
        }
        public async Task<Response<Payment>> ProcessPayment(Payment payment)
        {
            var response = new Response<Payment>();
            if (payment.Amount < 20)
            {
                response = await _cheapPaymentGateway.ProcessPayment(payment);

                return response;
            }

            if (payment.Amount < 21 && payment.Amount > 500)
            {
                if (_expensivePaymentGateway != null)
                {
                    response = await _expensivePaymentGateway.ProcessPayment(payment);
                    return response;
                }
                response = await _cheapPaymentGateway.ProcessPayment(payment);
                return response;
            }

            if (payment.Amount > 500)
            {
                const int numberOfTimes = 3;
                var i = 0;
                while (i++ < numberOfTimes)
                {
                    response = await _premiumPaymentGateway.ProcessPayment(payment);

                    if (response.State == "Processed")
                    {
                        return response;
                    }

                }
            }

            return response;

        }
    }
}
