using System;
using System.Collections.Generic;
using feed.products.Database.UnitOfWork;
using feed.products.Model.Entities;
using feed.products.Model.Models;

namespace feed.products.Domain
{
    public class FeedDomain : IFeedDomain
    {
        public FeedDomain(IDatabaseUnitOfWork database)
        {
            Database = database;

        }
        private  IDatabaseUnitOfWork Database { get; }
        public bool AddFeed(List<ThirdPartyDataModelDTOs> thirdPartyDataModelDTOs)
        {
            foreach (var item in thirdPartyDataModelDTOs)
            {
                var feedEntity = new FeedEntity();
                feedEntity.price = item.ProductPricePerUnit;
                feedEntity.ProductId = item.ProductId;
                feedEntity.ProductName = item.ProductName;
                feedEntity.Quantity = item.Quantity;
                Database.Feed.Add(feedEntity);
            }
            Database.SaveChanges();
            return true;
        }
    }
}
