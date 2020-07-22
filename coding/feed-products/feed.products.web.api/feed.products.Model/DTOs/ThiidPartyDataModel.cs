using System;
using System.Collections.Generic;
using System.Text;

namespace feed.products.Model.Models
{
    public class ThirdPartyDataModelDTOs
    {
        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPricePerUnit { get; set; }

        public int Quantity { get; set; }
    }
}
