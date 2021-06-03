using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.International.Converters.PinYinConverter;

namespace PinYinConvert
{
    /// <summary>
    /// 拼音转换器
    /// </summary>
    public class PinyinConverter : IDisposable
    {
        /// <summary>
        /// 将一段中文转换成拼音
        /// </summary>
        /// <param name="cn">中文字符串</param>
        /// <returns>这段中文的拼音</returns>
        public string ConvertToPinYin(string cn)
        {
            /*字符串拼音，单个字符拼音*/
            string pyChar, pyStr = string.Empty;
            foreach (char c in cn)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(c);
                    pyChar = chineseChar.Pinyins[0].ToString();
                    pyStr += pyChar.Substring(0, pyChar.Length - 1);
                }
                catch
                {
                    pyStr += c.ToString();
                }
            }
            return pyStr.ToLower();
        }

        public void Dispose()
        {
            
        }
    }
}
