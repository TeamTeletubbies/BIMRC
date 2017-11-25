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
        public IEnumerable<RCModel> Get(int projId)
        {
            return null;
        }

        // POST: api/RCModel
        public void Post([FromBody]RCModel value)
        {
            var myProject = WebApiApplication.Projects[value.ProjectId];
            value.Id = myProject.UsedRCModel.Count;
            value.DateTime = DateTime.Now;
            if (value.PhotoSceneId == null)
            {
                value.PhotoSceneId = "前端没有PhotoSceneId";
            }

        }

    }
}
