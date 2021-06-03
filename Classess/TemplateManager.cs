using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using BatchString.Classess.JsonEntiy;

namespace BatchString.Classess
{
    class TemplateManager
    {
        private TemplateManager() { }
        public static TemplateManager Instance { get; private set; }
        static TemplateManager() { Instance = new TemplateManager(); }

        /// <summary>
        /// 模板字典
        /// </summary>
        private readonly Dictionary<string, StringTemplate> tempEntities = new Dictionary<string, StringTemplate>();

        /// <summary>
        /// 从Json文件加载模板信息到内存，并返回模板名字的列表
        /// </summary>
        /// <param name="jsonPath">json文件路径</param>
        /// <returns>模板名字的列表</returns>
        public List<string> LoadTemplates(string jsonPath)
        {
            tempEntities.Clear();
            var tempList = JsonConvert.DeserializeObject<List<StringTemplate>>(System.IO.File.ReadAllText(jsonPath));
            foreach (var item in tempList)
            {
                if (tempEntities.ContainsKey(item.Name))
                    tempEntities[item.Name] = item;
                else
                    tempEntities.Add(item.Name, item);
            }
            return tempEntities.Keys.ToList();
        }

        /// <summary>
        /// 是否存在该模板
        /// </summary>
        /// <param name="tempName">模板名</param>
        /// <returns></returns>
        public bool ContainsTemplate(string tempName)
        {
            return tempEntities.ContainsKey(tempName);
        }

        /// <summary>
        /// 获取模板，若存在则返回模板，否则返回空字符
        /// </summary>
        /// <param name="tempName">模板名字</param>
        /// <param name="template">模板字符串</param>
        /// <returns></returns>
        public bool GetTemplate(string tempName, out string template)
        {
            bool contain = tempEntities.ContainsKey(tempName);
            template = contain ?  tempEntities[tempName].Template : string.Empty;
            return contain;
        }

        /// <summary>
        /// 修改模板
        /// </summary>
        /// <param name="tempName">模板名字</param>
        /// <param name="template">模板内容</param>
        /// <param name="jsonPath">Json文件路径</param>
        /// <returns></returns>
        public bool ModifyTemplate(string tempName, string template, string jsonPath)
        {
            if (tempEntities.ContainsKey(tempName))
            {
                tempEntities[tempName].Template = template;

                File.WriteAllText(jsonPath, JsonConvert.SerializeObject(tempEntities.Values.ToArray()));
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 增加模板
        /// </summary>
        /// <param name="tempName">模板名字</param>
        /// <param name="template">模板内容</param>
        /// <param name="jsonPath">Json文件路径</param>
        /// <returns></returns>
        public bool AddTemplate(string tempName, string template, string jsonPath)
        {
            if (!tempEntities.ContainsKey(tempName))
            {
                tempEntities.Add(tempName, new StringTemplate() { Name = tempName, Template = template });

                File.WriteAllText(jsonPath, JsonConvert.SerializeObject(tempEntities.Values.ToArray()));
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="tempName">模板名字</param>
        /// <param name="jsonPath">Json文件路径</param>
        /// <returns></returns>
        public bool RemoveTemplate(string tempName, string jsonPath)
        {
            if (tempEntities.ContainsKey(tempName))
            {
                tempEntities.Remove(tempName);

                File.WriteAllText(jsonPath, JsonConvert.SerializeObject(tempEntities.Values.ToArray()));
                return true;
            }
            else return false;
        }
    }
}
