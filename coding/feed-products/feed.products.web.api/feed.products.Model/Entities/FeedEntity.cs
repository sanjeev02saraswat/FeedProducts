using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace feed.products.Model.Entities
{
    public class FeedEntity
    {
        [Key]
        public long ID { get; set; }

        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal price { get; set; }

        public int Quantity { get; set; }
    }
}
