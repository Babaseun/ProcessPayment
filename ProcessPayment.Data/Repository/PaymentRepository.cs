using ProcessPayment.Domain.Entities;
using ProcessPayment.Domain.IRepository;
using System.Threading.Tasks;

namespace ProcessPayment.Data.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentContext _ctx;

        public PaymentRepository(PaymentContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Save(Payment payment)
        {
            await _ctx.Payments.AddAsync(payment);
            await _ctx.SaveChangesAsync();
        }
    }
}
