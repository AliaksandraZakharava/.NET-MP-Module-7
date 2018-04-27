using System;
using System.ComponentModel.DataAnnotations;

namespace NETMP.Module7.EFMapping.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }

        [StringLength(50)]
        public string CardHolder { get; set; }

        public DateTime ValidThru { get; set; }

        public int EmployeeID { get; set; }

        [StringLength(150)]
        public string BankAddress { get; set; }

        public Employee Employee { get; set; }
    }
}
