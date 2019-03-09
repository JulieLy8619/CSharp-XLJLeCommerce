using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace XLJLeCommerce.Models.ViewModels
{
    public class PaymentViewModel      
    {
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Cvv { get; set; }

        [Required]
        public string ExpDate { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
