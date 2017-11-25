using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer.Models
{
    public class BIMModel
    {
        // 关联到的项目的ID，从前端来
        public int ProjectId;
        // 转换后的SVF文件Urn，前端来
        public string SVFUrn;
        // 上传的FBX文件的名称，从前端来
        public string SourceName;
        //--------------------------------------------
        // 转换进度
        public double Progress;
        // 当前状态
        public BIMMStatus Status;

        public enum BIMMStatus
        {
            转换中,
            已完成,
            转换失败
        }
    }


}