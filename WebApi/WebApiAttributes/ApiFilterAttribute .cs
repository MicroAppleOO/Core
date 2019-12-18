

using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.WebApiAttributes
{
    public class ApiFilterAttribute : ActionFilterAttribute, IActionFilter, IAsyncResourceFilter
    {
        public CoreDemoContext DemoContext { get; }
        public Logs logs = new Logs();
        public ApiFilterAttribute(CoreDemoContext coreDemoContext)
        {
            DemoContext = coreDemoContext;
        }
        /// <summary>
        /// 请求Api 资源时
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            // 执行前
            try
            {
                await next.Invoke();
            }
            catch
            {
            }
            // 执行后
            await OnResourceExecutedAsync(context);        
        }
        /// <summary>
        /// 记录Http请求上下文
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task OnResourceExecutedAsync(ResourceExecutingContext context)
        {
            logs.LogMethod = context.HttpContext.Request.Method;
            if (logs.LogMethod=="GET"|| logs.LogMethod=="DELETE")
            {
                logs.LogParameter = context.HttpContext.Request.QueryString.ToString();
            }        
            logs.LogName = "Administrator";
            logs.LogTime = DateTime.Now;
            logs.LogContextType = context.HttpContext.Request.ContentType;
            logs.LogHost = context.HttpContext.Request.Host.ToString();
            logs.LogPath = context.HttpContext.Request.Path;
            logs.LogScheme = context.HttpContext.Request.Scheme;    
            DemoContext.Logs.Add(logs);
            DemoContext.SaveChanges();
        }
        //requestbody
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var request = context.HttpContext.Request;
            if (request.Method.ToLower().Equals("post")|| request.Method.ToLower().Equals("put"))
            {
                request.Body.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(request.Body, Encoding.UTF8))
                {
                    logs.LogParameter = reader.ReadToEnd();
                }
            }
        }
        //responsebody
        public override void OnActionExecuted(ActionExecutedContext context)
        {       
            base.OnActionExecuted(context);
            var data = JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(context.Result));
            string value = data["Value"].ToString(); ;
            IDictionary<string, object> Dictionary = JsonConvert.DeserializeObject<IDictionary<string, object>>(value);
            logs.LogStatus = Convert.ToInt32(Dictionary["status"]);
            logs.Log_Info = Dictionary["info"].ToString();
        }
    }
}
