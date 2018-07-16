using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TESTB_API.Models;

namespace TESTB_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GlossaryController : ApiController
    {
        [HttpGet]
        public IEnumerable<TermViewModel> List()
        {
            return new TermViewModel[] { new TermViewModel() { Term =  "term", Definition = "definition" } };
        }

        [HttpPost]
        public void Create([FromBody] TermViewModel model)
        {
        }

        [HttpPut]
        public void Update(string term, [FromBody] TermViewModel model)
        {
        }

        [HttpDelete]
        public void Delete(string term)
        {
        }
    }
}