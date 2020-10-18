using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HuaShiMicroApp
{
    //工具类，用于将结果写入文件
    public class FileUtil
    {
        /// <summary>
        /// 从文件中读取信息
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string GetInfoFromFile(string path)
        {
            StringBuilder str = new StringBuilder();
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(path, Encoding.Default);
                while (!reader.EndOfStream)
                {
                    str.Append(reader.ReadLine());
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                reader.Close();
            }
            return str.ToString();
        }

        /// <summary>
        /// 返回指定目录中的文件名称
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public static string[] GetFileNameFromFolder(string folderPath)
        {
            try
            {
                return Directory.GetFiles(folderPath);
            }
            catch (DirectoryNotFoundException ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 往文件中写数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="info">数据</param>
        /// <param name="useSep">使用分隔符</param>
        /// <returns></returns>
        public static void WriteToFile(string path, string info, bool useSep)
        {
            if (!File.Exists(path))
            {
                FileStream fs1 = new FileStream(path, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter writer = new StreamWriter(fs1);
                writer.WriteLine(info);
                if (useSep)
                {
                    writer.WriteLine("####################分隔线####################");
                    writer.WriteLine();
                    writer.WriteLine();
                }
                writer.Close();
                fs1.Close();
            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter writer = writer = new StreamWriter(fs);
                writer.WriteLine(info);
                if (useSep)
                {
                    writer.WriteLine("####################分隔线####################");
                    writer.WriteLine();
                    writer.WriteLine();
                }
                writer.Close();
                fs.Close();
            }
            /*
            if (!Directory.Exists(path))
            {//创建路径
                // Directory.CreateDirectory(path);
                FileInfo file = new FileInfo(path);
                FileStream f = file.Create();
                f.Close();
            }
            StreamWriter writer = null;
            try
            {
                //追加结果
                writer = new StreamWriter(path, true, Encoding.Default);
                writer.WriteLine(info);
                writer.WriteLine("####################分割线####################");
                writer.WriteLine();
            }
            catch
            {
                return false;
            }
            finally
            {
                writer.Close();
            }
            return true;
             */
        }
    }
}
