using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RCModel 
    {
        /// <summary>
        /// RC接口的场景ID，前端传过来
        /// </summary>
        public string PhotoSceneId;

        /// <summary>
        /// 进度，每次周期查询后更新，即表示转换进度又表示比对进度
        /// </summary>
        public double Progress;

        /// <summary>
        /// 扫描时间，服务器根据当前时刻填
        /// </summary>
        public DateTime DateTime;

        /// <summary>
        /// 当前状态
        /// </summary>
        public RCMStatus Status;

        /// <summary>
        /// 关联的项目ID
        /// </summary>
        public int ProjectId;

        /// <summary>
        /// 计算结果，包括所有存在的构件的ElementID
        /// </summary>
        public List<int> ExistId;

        public enum RCMStatus
        {
            转换中,
            已完成,
            转换失败,
            比对中,
            比对完成
        }


        /*
         * Task json
         * 文件名 [PhotoSceneId].json
         * 
         * {
         *     "photoscentId":"",
         *     "rvtfilename":"",
         *     "objfilename",""
         * }
         * 
         * [123123,123123,123123,123123,123123]
         * 
         * 
         * 
         * 
         * 
         * **/
    }
}