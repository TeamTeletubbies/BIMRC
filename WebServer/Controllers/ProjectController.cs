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
            var result = WebApiApplication.Projects;
            foreach (var a in result)
                foreach (var b in a.UsedRCModel)
                {
                    b.ExistId = null;
                }
            return result;
        }


        // POST: api/Project
        public void Post([FromBody]Project value)
        {
            value.Id = WebApiApplication.Projects.Count;
            WebApiApplication.Projects.Add(value);
            value.CreateTime = DateTime.Now;
            //if (value.UserId == null) value.UserId = "前端没有Userid";
            //if (value.ProjName == null) value.ProjName = "前端没有projname";
            //if (value.BucketName == null) value.BucketName = "前端没有BucketName";
        }


    }
}
