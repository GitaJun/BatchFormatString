using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinYinConvert;

namespace BatchString
{
    /// <summary>
    /// 批量字符串生产工厂
    /// </summary>
    public class Factory_BatchString
    {
        private Factory_BatchString() { }
        private static Factory_BatchString __instance;
        public static Factory_BatchString Instance
        {
            get { return __instance == null ? __instance = new Factory_BatchString() : __instance; }
        }

        /// <summary>
        /// 格式化字符串
        /// </summary>
        private string str_format;
        /// <summary>
        /// 格式化变量
        /// </summary>
        private string str_var;
        /// <summary>
        /// 输出字符串
        /// </summary>
        private string str_output;

        /// <summary>
        /// 获取格式化字符串输出
        /// </summary>
        /// <param name="str_format">格式化字符串</param>
        /// <param name="str_var">格式化变量</param>
        /// <param name="onPinyin">是否转换为拼音</param>
        /// <returns></returns>
        public string GetString(string str_format, string str_var, bool onPinyin = false)
        {
            this.str_format = str_format;
            this.str_var = str_var;
            this.str_output = string.Empty;
            Excute(onPinyin);
            return str_output;
        }

        private void Excute(bool onPinyin)
        {
            //分号分割每个格式化变量组  -  每组是一个字符串
            string[] variablesStringArray = str_var.Split(';');

            //分隔字符串
            char[] sep = "\r\n".ToArray<char>();
            //格式化变量字典 key - 格式化索引  value - 格式化变量组
            Dictionary<int, string[]> variablesArrayDic = new Dictionary<int, string[]>();
            for (int i = 0; i < variablesStringArray.Length; i++)
            {
                variablesArrayDic.Add(i, variablesStringArray[i].Split(sep, StringSplitOptions.RemoveEmptyEntries));
            }

            /*遍历格式化变量字典，构造格式化字符串输出*/
            List<string> formatArg = new List<string>();  //格式化信息
            for (int i = 0; i < variablesArrayDic[0].Length; i++)  //Length是格式化变量的数量
            {
                //key - 格式化索引  value - 格式化变量组
                foreach (KeyValuePair<int, string[]> pair in variablesArrayDic)
                {
                    formatArg.Add(pair.Value[i]);  //取每个格式化变量组的第i个
                }
                if (onPinyin)  //如果启用拼音转换
                {
                    using (PinyinConverter pyConverter = new PinyinConverter())
                    {
                        str_output += pyConverter.ConvertToPinYin(String.Format(str_format, formatArg.ToArray()));
                    }
                }
                else
                {
                    str_output += String.Format(str_format, formatArg.ToArray());
                }
                formatArg.Clear();
            }
        }
    }
}
