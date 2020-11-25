using AutoMapper;
using Exercise.Common.Enumerator;
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

        MapperConfiguration cpmfig = new MapperConfiguration(c => c.CreateMap<PaymentDTM, Payment>());

        public async System.Threading.Tasks.Task<OperationResult<Payment>> CheapPaymentAsync(PaymentDTM paymentDTM)
        {
            if (paymentDTM.Amount <= 20)
            {
                var mapper = new Mapper(cpmfig);
                var payment = mapper.Map<Payment>(paymentDTM);

                return await _paymentRepository.PaymentAsync(payment);
            }

            return new OperationResult<Payment>
            {
                Succeeded = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

        public async System.Threading.Tasks.Task<OperationResult<Payment>> ExpensivePaymentAsync(PaymentDTM paymentDTM)
        {
            if (paymentDTM.Amount > 20 && paymentDTM.Amount <= 500)
            {
                var mapper = new Mapper(cpmfig);
                var payment = mapper.Map<Payment>(paymentDTM);

                return await _paymentRepository.PaymentAsync(payment);
            }

            return new OperationResult<Payment>
            {
                Succeeded = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

        public async System.Threading.Tasks.Task<OperationResult<Payment>> PremiumPaymentAsync(PaymentDTM paymentDTM)
        { 
            if (paymentDTM.Amount > 500)
            {
                var mapper = new Mapper(cpmfig);
                var payment = mapper.Map<Payment>(paymentDTM);
                return await _paymentRepository.PaymentAsync(payment);
            }
            
            return new OperationResult<Payment>
            {
                Succeeded = false,
                StatusCode =  System.Net.HttpStatusCode.BadRequest
            };
        }
    }
}
