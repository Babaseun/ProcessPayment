using Moq;
using ProcessPayment.Domain.Entities;
using ProcessPayment.Domain.IServices;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PaymentProcess.Test
{
    public class UnitTest1
    {
        private Mock<ICheapPaymentGateway> _cheapPay;

        public UnitTest1()
        {
            _cheapPay = new Mock<ICheapPaymentGateway>();
        }

        [Fact]
        public async Task Should_Process_Cheap_Payment()
        {

            var mock = new Mock<IPaymentService>();

            var payment = new Payment()
            {
                Amount = 10,
                CardHolder = "James Smith",
                CreditCardNumber = "5141721053193595",
                ExpirationDate = DateTime.Now.AddYears(2),
                SecurityCode = "123",

            };

            mock.Setup(x => x.ProcessPayment(payment)).ReturnsAsync(new Response<Payment>());

            mock.Verify(x => x.ProcessPayment(payment), Times.Once);


        }
        //[Fact]
        //public void Should_Process_Expensive_Payment()
        //{
        //    var payment = new Payment
        //    {
        //        Amount = 10,
        //        CardHolder = "James Smith",
        //        CreditCardNumber = "5141721053193595",
        //        ExpirationDate = DateTime.Now.AddYears(2),
        //        SecurityCode = "123"
        //    };

        //    //_cheapPaymentGateway.Setup(x => x.ProcessPayment(payment));
        //    //_expensivePaymentGateway.Verify(x => x.ProcessPayment(payment), Times.Never);
        //}



    }
}
