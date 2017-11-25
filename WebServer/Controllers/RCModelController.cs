using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServer.Models;
namespace WebServer.Controllers
{
    public class RCModelController : ApiController
    {
        // GET: api/RCModel
        public IEnumerable<RCModel> Get()
        {
            return null;
        }

        // POST: api/RCModel
        public void Post([FromBody]RCModel value)
        {
        }

    }
}
