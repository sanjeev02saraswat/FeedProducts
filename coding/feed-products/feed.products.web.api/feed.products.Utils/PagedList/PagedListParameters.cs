using System;
using System.Collections.Generic;
using System.Text;

namespace feed.products.Utils
{
    public class PagedListParameters
    {
        public IList<Order> Orders { get; set; } = new List<Order>();

        public Page Page { get; set; } = new Page();
    }
}
