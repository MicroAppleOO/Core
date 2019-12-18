using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Function.Project
{
    public class personInforFactory
    {
        #region 单例,注入
        //单例
        private static personInforFactory instance;
        public static personInforFactory Instance(CoreDemoContext demoContext)
        {
            if (instance == null)
            {
                instance = new personInforFactory(demoContext);
            }
            return instance;
        }
        //注入
        public CoreDemoContext  DemoContext { get; }
        public personInforFactory(CoreDemoContext coreDemoContext)
        {
            DemoContext = coreDemoContext;
        }
        #endregion
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<PersonInfor> Get() 
        {
            return DemoContext.PersonInfor.ToList();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="InFor"></param>
        /// <returns></returns>
        public PersonInfor Update(string id, PersonInfor InFor)
        {
            var guid = new Guid(id);
            PersonInfor information = DemoContext.PersonInfor.Where(p => p.Id == guid).FirstOrDefault();
            information.Name = InFor.Name;
            information.Age = InFor.Age;
            information.Sex = InFor.Sex;
            information.Address = InFor.Address;
            DemoContext.SaveChanges();
            return InFor;
        }
    }
}
