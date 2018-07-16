using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TESTB_API.Models;

namespace TESTB_API.Controllers
{
    public class GlossaryController : ApiController
    {
        public IEnumerable<TermViewModel> Get()
        {
            return new TermViewModel[] { new TermViewModel() { Term =  "term", Definition = "definition" } };
        }

        public void Post([FromBody] TermViewModel model)
        {
        }

        public void Put(string oldTerm, [FromBody] TermViewModel model)
        {
        }

        public void Delete(string term)
        {
        }
    }
}