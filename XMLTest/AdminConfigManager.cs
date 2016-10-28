using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XMLTest
{
    public static class AdminConfigManager
    {       
        public static IList<AdminUser> AdminUsers { get; } = new List<AdminUser>();

        #region 加载、保存相关
        /// <summary>
        /// 获取或设置配置文件路径。
        /// </summary>
        public static string ConfigFilePath { get; set; }
        
        /// <summary>
        /// 加载配置。
        /// </summary>
        public static void LoadConfig()
        {
            XElement root = XElement.Load(ConfigFilePath);
            AdminUsers.Clear();
            foreach (XElement element in root.Elements("AdminUser"))
            {
                AdminUser adminUser = new AdminUser();
                adminUser.Id = (string)element.Attribute("Id");
                adminUser.Name = (string)element.Attribute("Name");
                AdminUsers.Add(adminUser);
            }
        }

        /// <summary>
        /// 保存配置。
        /// </summary>
        public static void SaveConfig()
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("AdminConfig",
                    from adminUser in AdminUsers
                    select new XElement("AdminUser",
                        new XAttribute("Id", adminUser.Id),
                        new XAttribute("Name", adminUser.Name))));

            doc.Save(ConfigFilePath);
        }
        #endregion
    }

    public sealed class AdminUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
