using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public string GetString()
        {
           return GetForgeInfo.DownloadFile(@"C:\Users\Laugh\Desktop\天线宝宝队\", GetForgeInfo.client, GetForgeInfo.token, "urn:adsk.viewing:fs.file:dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6ZjE0OGM5YTEzYmFlNGU2Zjk0NDdjZGU5ZTdjNTBkZTUvJUU5JUExJUI5JUU3JTlCJUFFMS0lRTQlQjglODklRTclQkIlQjQlRTglQTclODYlRTUlOUIlQkUtJTdCM0QlN0QuZmJ4/output/1/项目1-三维视图-{3D}.svf");

        }
    }
}

