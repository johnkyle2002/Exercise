using Exercise.Common.Attribute;
using System;
using System.ComponentModel.DataAnnotations;

namespace Exercise.DataTransferModel
{
    public class PaymentDTM
    { 
        [CreditCard]
        public string CreditCarNumber { get; set; }
        public string CardHolder { get; set; }
        [CheckDateRange]
        public DateTime ExpiratioinDate { get; set; }
        [StringLength(3)]
        public string SecurityCode { get; set; }
         
        [Range(0, 9999999999999999.99)] 
        public decimal Amount { get; set; } 
    }
}
