using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalbeTest.Models
{
    public class PenjualanModel
    {
        public int intSalesOrderID { get; set; }

        public int? intCustomerID { get; set; }

        public int? intProductID { get; set; }

        public DateTime? dtSalesOrder { get; set; }

        public int? intQty { get; set; }

        public string txtCustomerName { get; set; }
        public string txtProductName
        {
            get; set;


        }
    }
}
