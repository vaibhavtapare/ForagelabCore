using Foragelab.Core.DataModel.Repository;
using Foragelab.Core.Entities;
using Foragelab.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace Foragelab.Core.Services.Services
{
    public class FeedCodeServices : IFeedCodeServices
    {
        private readonly IRepository<DataModel.Feedcodes> _feedcodeRepository;

        public FeedCodeServices(IRepository<DataModel.Feedcodes> feedcodeRepository)
        {
            _feedcodeRepository = feedcodeRepository;
        }      

        public IEnumerable<FeedCodeEntity> GetAllFeedCodes()
        {
            var feedcodes = _feedcodeRepository.GetAll();
            return feedcodes.Select(Map);
        }

        FeedCodeEntity IFeedCodeServices.GetFeedCodeById(int feedcodeId)
        {
            var feedcode = _feedcodeRepository.Get(feedcodeId);
            return Map(feedcode); 
        } 

        private static FeedCodeEntity Map(DataModel.Feedcodes feedcode)
        {
            return new FeedCodeEntity
            {
                FeedCodeId = feedcode.FeedCodeId,
                Designator = feedcode.Designator,
                FeedCode = feedcode.FeedCode,
                FeedType = feedcode.FeedType,
                GeneralClass = feedcode.GeneralClass                
                //IsQuickFeedType = (bool)feedcode.IsQuickFeedType
            };
        }     
      
    }
}
