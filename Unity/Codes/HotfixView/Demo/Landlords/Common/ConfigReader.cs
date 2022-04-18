using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System;
namespace ET
{
    ///<summary>
    ///负责读取配置文件并提供解析行
    ///<summary>
    public static class ConfigReader
    {
        /// <summary>
        /// 加载（获取）配置文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>获取的字符串(待解析)</returns>
        public static string GetConfigFile(string fileName)
        {
            string url = "";
            //在移动端通过Application.StreamingAssets不靠谱可能会出错 应用以下方法
            //url根据不同平台有不同的路径,利用宏标签在编译期间运行，根据所处平台选择哪条语句
            //发布后相当于就选择了一条合适的语句url=xxxx  
            //if(Application.platform == RuntimePlatform.Android) 性能稍差
            if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                url = "file://" + Application.dataPath + "/StreamingAssets/" + fileName;
            else if(Application.platform == RuntimePlatform.IPhonePlayer)
                url = "file://" + Application.dataPath + "/Raw/"+fileName;
            else if(Application.platform == RuntimePlatform.Android)
                url = "jar:file://" + Application.dataPath + "!/assets/"+fileName;

            


            //移动端根据url加载文件资源最终返回一个string
            UnityWebRequest www = UnityWebRequest.Get(url);
            if (www == null)
            {
                Log.Error("Config不存在 请检查");
                return "";
            }
            www.SendWebRequest();
            while (true)
            {
                if (www.downloadHandler.isDone)
                    return www.downloadHandler.text;
            }
        }

        public static void Reader(string fileContent,Action<string> handler)
        {

            //读出来的string   "xxxName=xxxPath/r/nxxxName=xxxPath/r/n....
            //解析字符串,利用StringReader字符串读取器，流用完必须释放内存
            //using 代码块结束自动释放资源
            using (StringReader reader = new StringReader(fileContent))
            {
                string line;
                while ((line = reader.ReadLine()) != null) //逐行获取字符串
                {
                    //解析方法
                    handler(line);
                }
            }
        }
    }

}
