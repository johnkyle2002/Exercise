using Exercise.DataTransferModel;
using Exercise.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercise.Payment.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly ICheapPaymentGateway _cheapPaymentGateway;

        public PaymentController(IExpensivePaymentGateway expensivePaymentGateway,
            ICheapPaymentGateway cheapPaymentGateway)
        {
            _expensivePaymentGateway = expensivePaymentGateway;
            _cheapPaymentGateway = cheapPaymentGateway;
        }

        public IActionResult Index()
        {
            return new OkResult();
        }

        public IActionResult ProcessPayment(Model.Payment payment)
        {
            return new OkResult();
        }
    }
}
