﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace feed.products.Utils
{
    public class PagedList<T>
    {
        public PagedList(IQueryable<T> queryable, PagedListParameters parameters)
        {
            if (queryable == null)
            {
                return;
            }

            Count = queryable.LongCount();

            parameters?.Orders?.ToList().ForEach(order => queryable = queryable.Order(order.Property, order.IsAscending));

            if (parameters?.Page != null)
            {
                queryable = queryable?.Page(parameters.Page.Index, parameters.Page.Size);
            }

            List = queryable.AsEnumerable();
        }

        public long Count { get; }

        public IEnumerable<T> List { get; }
    }
}
