using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalbeTest.Models
{
    public class CustomerModel
    {
        public int intCustomerId { get; set; }

        public string txtCustomerName { get; set; }

        public string txtCustAddress { get; set; }

        public bool? bitGender { get; set; }

        public DateTime? dtmBirthDate { get; set; }

        public DateTime? dtminserted { get; set; }

    }
}
