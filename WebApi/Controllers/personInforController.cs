

using Entity.Models;
using Function;
using Function.Project;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    /// 人员信息
    /// </summary>
    [ApiController]
    [Route("api/PersonInfor")]
    public class personInforController : ControllerBase
    {
        public personInforController(personInforFactory information) { Factory = information; }
        public personInforFactory Factory { get; }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="id">uid</param>
        /// <param name="information">修改信息</param>
        /// <returns></returns>
        [HttpPost, Route("Update")]
        public IActionResult update(string id, PersonInfor information)
        {
            JsonResponse resp = null;
            var data = Factory.Update(id, information);
            if (data == null)
                resp = new JsonResponse(300, "修改失败", null);
            else
            {
                resp = new JsonResponse(200, "修改成功", data);
            }
            return Ok(resp);
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("All")]
        public IActionResult all()
        {
            JsonResponse resp = null;
            var data = Factory.Get();
            if (data == null)
                resp = new JsonResponse(300, "查询失败", null);
            else
            {
                resp = new JsonResponse(200, "增加成功", data);
            }
            return Ok(resp);
        }
    }
}
