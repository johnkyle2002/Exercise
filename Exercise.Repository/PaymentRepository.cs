using Exercise.DataTransferModel;
using Exercise.Interface.Repository;
using Exercise.Interface.Service;
using Exercise.Model;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Exercise.Repository
{
    public class PaymentRepository :  IPaymentRepository
    {
        private readonly IRepositoryBase<Payment> _repository;
        private readonly ILogger<PaymentRepository> _logger;

        public PaymentRepository(IRepositoryBase<Payment> repository,
            ILogger<PaymentRepository> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<OperationResult<Payment>> PaymentAsync(Payment payment)
        {
            try
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
            catch (System.Exception ex)
            {
                _logger.LogError("CheapPaymentAsync", ex.Message, ex.InnerException.Message, ex.StackTrace);
            }

            return new OperationResult<Payment>
            {
                Succeeded = true,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }

    }
}
