using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Foragelab.Core.Services.Interfaces; 

namespace Foragelab.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Feedcode")]
    public class FeedcodeController : Controller
    {
        private readonly IFeedCodeServices _feedcodeService;

        public FeedcodeController(IFeedCodeServices feedCodeServices)
        {
            _feedcodeService = feedCodeServices;     
        }

        public IActionResult Get(int pageNumber, int pageSize)
        {
            var feedcodeList = _feedcodeService.GetAllFeedCodes();
            return Ok(feedcodeList); 
        }
    }
}