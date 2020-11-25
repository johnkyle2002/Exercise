using Exercise.DataTransferModel;
using Exercise.Model;
using System.Threading.Tasks;

namespace Exercise.Interface.Service
{
    public interface IPremiumPaymentService
    {
        Task<OperationResult<Payment>> PremiumPaymentAsync(PaymentDTM paymentDTM);
    }
}
