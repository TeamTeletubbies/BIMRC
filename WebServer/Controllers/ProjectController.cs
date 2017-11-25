using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServer.Models;
namespace WebServer.Controllers
{
    public class ProjectController : ApiController
    {
        // GET: api/Project
        public IEnumerable<Project> Get()
        {
            return null;
        }

        // POST: api/Project
        public void Post([FromBody]Project value)
        {
        }
    }
}
