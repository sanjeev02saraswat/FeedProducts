using feed.products.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace feed.products.Domain
{
    public interface IFeedDomain
    {
        bool AddFeed(List<ThirdPartyDataModelDTOs> thirdPartyDataModelDTOs);
    }
}
