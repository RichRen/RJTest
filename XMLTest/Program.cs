using System;
using System.Collections.Generic;

namespace XMLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1.0 加载配置
            //这段代码一般放在程序的启动入库处，比如web项目的Global.asax.cs文件的Application_Start()方法里
            AdminConfigManager.ConfigFilePath = @"../../AdminUserConfig.xml";//配置xml文件路径
            AdminConfigManager.LoadConfig();//加载文件 
            #endregion

            IList<AdminUser> andminUsers = AdminConfigManager.AdminUsers;

            #region 2.0 新增
            AdminUser addAdminUser = new AdminUser();
            addAdminUser.Id = "RJ";
            addAdminUser.Name = "任静";
            AdminConfigManager.AdminUsers.Add(addAdminUser);
            AdminConfigManager.SaveConfig();
            #endregion

            #region 3.0 删除
            //AdminUser deleteAdminUser = AdminConfigManager.AdminUsers.Where(u => u.Id == "RJ").First();
            //AdminConfigManager.AdminUsers.Remove(deleteAdminUser);
            //AdminConfigManager.SaveConfig(); 
            #endregion

            Console.ReadKey();
        }
    }
}
