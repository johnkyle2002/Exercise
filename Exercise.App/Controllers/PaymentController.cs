using Exercise.DataTransferModel;
using Exercise.Interface.Service;
using Exercise.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Exercise.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IPremiumPaymentService _premiumPaymentService;

        public PaymentController(ILogger<PaymentController> logger,
            ICheapPaymentGateway cheapPaymentGateway,
            IExpensivePaymentGateway expensivePaymentGateway,
            IPremiumPaymentService premiumPaymentService)
        {
            _logger = logger;
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _premiumPaymentService = premiumPaymentService;
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public StatusCodeResult ProcessPayment(PaymentDTM paymentDTM)
        {
            var result = new OperationResult<Payment>();
            switch (paymentDTM.Amount)
            {
                case > 500:
                    result = _premiumPaymentService.PremiumPaymentAsync(paymentDTM)
                    break;
                case > 21: break;
                default: break;
            }



            return new StatusCodeResult(200);
        }
    }
}
