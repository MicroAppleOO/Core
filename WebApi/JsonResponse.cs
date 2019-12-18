using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    /// <summary>
    /// 构建标准的返回信息
    /// </summary>
    public class JsonResponse
    {
        public JsonResponse() { }

        public JsonResponse(int status, string info, object data)
        {
            this.status = status;
            this.info = info;
            this.data = data;
        }

        public JsonResponse(int status, string info, object data, object log)
        {
            this.status = status;
            this.info = info;
            this.data = data;
            this.log = log;
        }
        /// <summary>
        /// status:200-成功,300-失败,400-参数非法等等
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string info { get; set; }

        /// <summary>
        /// 返回的具体数据信息
        /// </summary>
        public object data { get; set; }

        /// <summary>
        /// 返回操作错误提示或日志
        /// </summary>
        public object log { get; set; }

    }
    /// <summary>
    /// 构建标准返回数据页的详情
    /// </summary>
    public class Page_Info
    {
        /// <summary>
        /// 返回记录总数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 返回当前页数
        /// </summary>
        public int index { get; set; }

        /// <summary>
        /// 返回当前页记录数
        /// </summary>
        public int size { get; set; }

    }
}
