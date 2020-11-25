using Exercise.DataTransferModel;
using Exercise.Interface.Repositroy;
using Exercise.Interface.Service;
using Exercise.Model;
using Microsoft.Extensions.Logging;

namespace Exercise.Repository
{
    public class PaymentRepository : ICheapPaymentGateway, IExpensivePaymentGateway, IPremiumPaymentService
    {
        private readonly IRepositoryBase<Payment> _repository;
        private readonly ILogger<PaymentRepository> _logger;

        public PaymentRepository(IRepositoryBase<Payment> repository,
            ILogger<PaymentRepository> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async System.Threading.Tasks.Task<OperationResult<Payment>> CheapPaymentAsync(Payment payment)
        {
            try
            {
                if (payment.Amount <= 20)
                {
                    if (await _repository.AddAsync(payment))
                    {
                        return new OperationResult<Payment>
                        {
                            Succeeded = true,
                            StatusCode = System.Net.HttpStatusCode.OK
                        };
                    }
                }

                return new OperationResult<Payment>
                {
                    Succeeded = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };

            }
            catch (System.Exception ex)
            {
                _logger.LogError("CheapPaymentAsync", ex.Message, ex.InnerException.Message, ex.StackTrace);
                return new OperationResult<Payment>
                {
                    Succeeded = true,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
         
        public async System.Threading.Tasks.Task<OperationResult<Payment>> ExpensivePaymentAsync(Payment payment)
        {
            try
            {
                if (payment.Amount > 20 && payment.Amount <=500)
                {
                    if (await _repository.AddAsync(payment))
                    {
                        return new OperationResult<Payment>
                        {
                            Succeeded = true,
                            StatusCode = System.Net.HttpStatusCode.OK
                        };
                    }
                }

                return new OperationResult<Payment>
                {
                    Succeeded = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };

            }
            catch (System.Exception ex)
            {
                _logger.LogError("CheapPaymentAsync", ex.Message, ex.InnerException.Message, ex.StackTrace);
                return new OperationResult<Payment>
                {
                    Succeeded = true,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
        
        public async System.Threading.Tasks.Task<OperationResult<Payment>> PremiumPaymentAsync(Payment payment)
        {
            try
            {
                if (payment.Amount > 500)
                {
                    if (await _repository.AddAsync(payment))
                    {
                        return new OperationResult<Payment>
                        {
                            Succeeded = true,
                            StatusCode = System.Net.HttpStatusCode.OK
                        };
                    }
                }

                return new OperationResult<Payment>
                {
                    Succeeded = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };

            }
            catch (System.Exception ex)
            {
                _logger.LogError("CheapPaymentAsync", ex.Message, ex.InnerException.Message, ex.StackTrace);
                return new OperationResult<Payment>
                {
                    Succeeded = true,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        } 
    }
}
