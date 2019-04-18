using System;
using System.IO;
using System.Text;

namespace BCL.ToolLib.Modules
{
    public class FileModule
    {
        public static string GetConfigFileName(string CONFIGFILENAME)
        {
            return AppDomain.CurrentDomain.BaseDirectory + "\\" + CONFIGFILENAME;
        }

        /// <summary>
        /// 读取文件字符串
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Read(string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string line;
                StringBuilder sb = new StringBuilder();
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line);
                }
                return sb.ToString();
            }
        }
    }
}
