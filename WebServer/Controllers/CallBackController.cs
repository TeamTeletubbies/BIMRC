using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServer.Controllers
{
    public class CallBackController : Controller
    {
        // GET: CallBack
        public ActionResult Index(string access_token)
        {
            return View();
        }
    }
}