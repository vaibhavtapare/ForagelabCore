using Foragelab.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foragelab.Core.Services.Interfaces
{
    public interface IFeedCodeServices
    {
        FeedCodeEntity GetFeedCodeById(int feedcodeId);
        IEnumerable<FeedCodeEntity> GetAllFeedCodes();

    }
}
