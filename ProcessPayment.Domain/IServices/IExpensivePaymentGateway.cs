using ProcessPayment.Domain.Entities;
using System.Threading.Tasks;

namespace ProcessPayment.Domain.IServices
{
    public interface IExpensivePaymentGateway
    {
        Task<Response<Payment>> ProcessPayment(Payment payment);
    }
}
