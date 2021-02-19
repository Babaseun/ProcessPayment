using ProcessPayment.Domain.Entities;
using ProcessPayment.Domain.IRepository;
using ProcessPayment.Domain.IServices;
using System.Threading.Tasks;

namespace ProcessPayment.Domain.Services
{
    public class PremiumPaymentService : IPremiumPaymentGateway
    {
        private readonly IPaymentRepository _paymentRepository;
        //private readonly IPaymentStateRepo _paymentState;

        public PremiumPaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<Response<Payment>> ProcessPayment(Payment payment)
        {
            var response = new Response<Payment>();

            await _paymentRepository.Save(payment);

            response.Success = true;
            response.Data = payment;
            return response;
        }
    }
}
