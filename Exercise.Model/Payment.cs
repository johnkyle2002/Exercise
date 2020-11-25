using Exercise.Common.Attribute;
using Exercise.Common.Enumerator;
using System;
using System.ComponentModel.DataAnnotations;
namespace Exercise.Model
{
    public class Payment
    {
        public int PaymentID { get; set; }
        
        [CreditCard]
        public string CreditCarNumber { get; set; }
        public string CardHolder { get; set; }
        [CheckDateRange]
        public DateTime ExpiratioinDate { get; set; }
        [StringLength(3)]
        public string SecurityCode { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)] 
        public decimal Amount { get; set; }

        public PaymentEnum.State Status { get; set; }
    }
}
