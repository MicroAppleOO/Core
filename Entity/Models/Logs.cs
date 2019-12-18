using System;
using System.Collections.Generic;

namespace Entity.Models
{
    public partial class Logs
    {
        public Guid LogUid { get; set; }
        //操作人
        public string LogName { get; set; }
        //时间
        public DateTime? LogTime { get; set; }
        //请求方式
        public string LogMethod { get; set; }
        //请求内容类型
        public string LogContextType { get; set; }
        //请求协议标识
        public string LogScheme { get; set; }
        //请求域名消息
        public string LogHost { get; set; }
        //请求地址
        public string LogPath { get; set; }
        //返回状态
        public int? LogStatus { get; set; }
        //返回信息
        public string Log_Info { get; set; }       
        //请求参数
        public string LogParameter { get; set; }
    }
}
