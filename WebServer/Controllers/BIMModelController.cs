using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServer.Models;
namespace WebServer.Controllers
{
    public class BIMModelController : ApiController
    {

        // POST: api/BIMModel
        public void Post([FromBody]BIMModel value)
        {
            if (WebApiApplication.Projects[value.ProjectId].BIMModel == null)
            {
                WebApiApplication.Projects[value.ProjectId].BIMModel = value;
            }
            if (value.SVFUrn == null) value.SVFUrn = "前端没有SVFUrn";
            if (value.SourceName == null) value.SourceName = "前端没有SourceName";
        }

    }
}
