using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer.Models
{
    /// <summary>
    /// 一次RC工程
    /// </summary>
    public class Project
    {
        //项目ID，创建时候自动编码
        public int Id;
        //项目创建者ID，前端来
        public string UserId;
        //项目名称，前端来
        public string ProjName;
        //关联到的BIMModel对象，在POST BIMModel时候赋值
        public BIMModel BIMModel =null ;
        //本项目之前的比对的RC模型
        public List<RCModel> UsedRCModel = new List<RCModel>();
        //OSS里的BucketName，前端来
        public string BucketName;
        //创建时间
        public DateTime CreateTime;
        // 用户名
        public string UserName;
    }
}