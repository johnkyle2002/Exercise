using Exercise.DataTransferModel;
using Exercise.Interface.Repository;
using Exercise.Interface.Service;
using Exercise.Model;
using Microsoft.Extensions.Logging;

namespace Exercise.Service
{
    public class PaymentService : ICheapPaymentGateway, IExpensivePaymentGateway, IPremiumPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IPaymentRepository paymentRepository,
            ILogger<PaymentService> logger)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
        }

        public async System.Threading.Tasks.Task<OperationResult<Payment>> CheapPaymentAsync(Payment payment)
        {
            if (payment.Amount <= 20)
                return await _paymentRepository.PaymentAsync(payment);

            return new OperationResult<Payment>
            {
                Succeeded = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

        public async System.Threading.Tasks.Task<OperationResult<Payment>> ExpensivePaymentAsync(Payment payment)
        {
            if (payment.Amount > 20 && payment.Amount <= 500)
                return await _paymentRepository.PaymentAsync(payment);

            return new OperationResult<Payment>
            {
                Succeeded = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

        public async System.Threading.Tasks.Task<OperationResult<Payment>> PremiumPaymentAsync(Payment payment)
        {
            if (payment.Amount > 500)
                return await _paymentRepository.PaymentAsync(payment);

            return new OperationResult<Payment>
            {
                Succeeded = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }
}
