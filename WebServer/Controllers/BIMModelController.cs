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

            WebApiApplication.Projects[value.ProjectId].BIMModel = value;

            value.SVFUrn64 = GetForgeInfo.GetURN64(value.SVFUrn).Replace("=", "");
            value.FBXUrn64 = GetForgeInfo.GetURN64(value.FBXUrn).Replace("=", "");
            //if (value.SVFUrn == null) value.SVFUrn = "前端没有SVFUrn";
            //if (value.SourceName == null) value.SourceName = "前端没有SourceName";
        }

    }
}
