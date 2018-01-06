using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebServer.Models;

namespace WebServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Project
        /// </summary>
        public static  List<Project> Projects;
        public static string MainPath = @"C:\Users\Laugh\Desktop\天线宝宝队\Server\";
        public static string fbxPath= MainPath+ @"fbx\";
        public static string objPath= MainPath + @"obj\";
        public static string resultPath = MainPath + @"result\";
        public static string taskPath = MainPath + @"task\";
        int i = 0;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Projects = new List<Project>() { MakeAProjectByMyself() };
            GetForgeInfo.Initialization();
            //监视模型们的progress
            //var t = new Thread(() =>
            //  {
            //      while (true)
            //      {
            //          Thread.Sleep(5000);
            //          foreach (var proj in Projects)
            //          {
            //              if (proj.BIMModel.Status == BIMModel.BIMMStatus.转换中)
            //                  UpdateBIMModelProgress(proj.BIMModel);
            //              foreach(var rcmodel in proj.UsedRCModel)
            //              {
            //                if(rcmodel.Status == RCModel.RCMStatus.转换中)
            //                  {
            //                      UpdateRCModelProgress(rcmodel);
            //                  }
            //              }
            //          }
            //      }
            //  });

            //监视result文件夹
            var t2 = new Thread(() =>
                {
                    while (true)
                    {
                        foreach (var file in Directory.GetFiles(resultPath))
                        {
                            //if (file.Contains("start")) ;

                            if (file.Contains("end"))
                                File.AppendAllText(resultPath + "Ht.txt", "sdasfdsaf");

                        }
                        Thread.Sleep(5000);
                    }


                });
        }
        //紧急使用
        Project MakeAProjectByMyself()
        {
            Project proj = new Project();
            proj.Id = 0;
            proj.BucketName = "c18ef1dbc8ed4c989e64a66058412766";
            proj.BIMModel = new BIMModel();
            proj.BIMModel.SVFUrn64 = "dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6YzE4ZWYxZGJjOGVkNGM5ODllNjRhNjYwNTg0MTI3NjYvQklNUkN0ZXN0TW9kZWwxLSVFNCVCOCU4OSVFNyVCQiVCNCVFOCVBNyU4NiVFNSU5QiVCRS0lN0IlRTQlQjglODklRTclQkIlQjQlN0QoMSkuZmJ4";
            proj.BIMModel.FBXUrn64 = "";
            proj.BIMModel.Progress = 1;
            proj.BIMModel.ProjectId = 0;
            proj.BIMModel.SourceName = "BIMRC.fbx";
            proj.BIMModel.Status = BIMModel.BIMMStatus.已完成;
            proj.CreateTime = DateTime.Now;
            proj.ProjName = "test1";
            proj.UsedRCModel = new List<RCModel>();
            proj.UserId = "0";
            proj.UserName = "sss";
            return proj;
        }

        private async void UpdateBIMModelProgress(BIMModel bimModel)
        {
            await Task.Run(() =>
            {
                //费时间的操作
               string progress = GetForgeInfo.GetProgress(GetForgeInfo.client, GetForgeInfo.token, bimModel.SVFUrn);
                if (progress == "complete")
                {
                    GetForgeInfo.DownloadFile(@"C:\Users\Laugh\Desktop\天线宝宝队\Server\fbx\", GetForgeInfo.client, GetForgeInfo.token, bimModel.FBXUrn);

                    bimModel.Status = BIMModel.BIMMStatus.已完成;
                }
            });
        }

        private async void UpdateRCModelProgress(RCModel rcModel)
        {
            await Task.Run(() =>
            {
                //费时间的操作
                string progress="";
                if (progress == "complete")
                {
                    //下载obj，同时更改statu为完成，下载完成后创建task，
                }
            });
        }
    }
}
