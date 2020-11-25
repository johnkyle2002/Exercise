using Exercise.Interface.Repositroy;
using Exercise.Interface.Service;
using Exercise.Model;

namespace Exercise.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepositoryBase<Payment> _repository;

        public PaymentService(IRepositoryBase<Payment> repository)
        {
            _repository = repository;
        }


    }
}
