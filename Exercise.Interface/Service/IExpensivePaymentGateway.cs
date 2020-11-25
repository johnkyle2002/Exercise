using Exercise.DataTransferModel;
using Exercise.Model;
using System.Threading.Tasks;

namespace Exercise.Interface.Service
{
    public interface IExpensivePaymentGateway
    {
        Task<OperationResult<Payment>> ExpensivePaymentAsync(Payment payment);
    }
}
