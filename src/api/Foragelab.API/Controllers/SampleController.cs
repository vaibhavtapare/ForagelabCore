using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Foragelab.Core.Data;

namespace Foragelab.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Samples/{pageNumber}/{pageSize}")]
    public class SampleController : Controller
    {
        private CVASContext _context;

        public SampleController(CVASContext context)
        {
            _context = context;
        }

        public IActionResult Get(int pageNumber, int pageSize)
        {
            var model = _context.Samples
                .Join(_context.Feedcodes, s => s.FeedCodeId, f => f.FeedCodeId, (s, f) => new { s, f })
                .Join(_context.Account, a => a.s.AccountCode, f => f.AccountCode, (a, f) => new { a, f })
            .Select(m => new
            {
                m.a.s.Batch,
                m.a.s.Code,
                m.a.s.AccountCode,
                m.a.s.FeedType,
                m.a.s.FarmName,
                m.a.s.CreatedDate,
                m.a.s.NirClassId,
                m.a.s.ChemClassId,
                m.a.f.Designator,
                m.f.BusinessName
            })

            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);



            if (model == null)
                return NotFound();
            return Ok(model);
        }

    }
}