using ProcessPayment.Domain.Entities;
using System.Threading.Tasks;

namespace ProcessPayment.Domain.IRepository
{
    public interface IPaymentRepository
    {
        Task Save(Payment payment);
    }
}
