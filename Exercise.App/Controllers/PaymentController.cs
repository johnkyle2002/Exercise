using Exercise.DataTransferModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Exercise.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public StatusCodeResult ProcessPayment(PaymentDTM paymentDTM)
        {
            return new StatusCodeResult(200);
        }
    }
}
