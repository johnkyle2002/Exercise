using Exercise.DataTransferModel;
using Exercise.Model;
using System.Threading.Tasks;

namespace Exercise.Interface.Service
{
    public interface ICheapPaymentGateway
    {
        Task<OperationResult<Payment>> CheapPaymentAsync(PaymentDTM payment);
    }
}
