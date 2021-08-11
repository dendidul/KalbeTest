using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalbeTest.Models
{
    public class ProdukModel
    {
        public int intProductId { get; set; }

        public string txtProductCode { get; set; }

        public string txtProductName { get; set; }

        public int? intQuantity { get; set; }

        public decimal? decPrice { get; set; }

        public DateTime? dtinserted { get; set; }
    }
}
