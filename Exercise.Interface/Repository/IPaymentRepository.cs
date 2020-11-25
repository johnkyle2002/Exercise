using Exercise.DataTransferModel;
using Exercise.Model;
using System.Threading.Tasks;

namespace Exercise.Interface.Repository
{
    public interface IPaymentRepository
    {
        Task<OperationResult<Payment>> PaymentAsync(Payment payment);
    }
}