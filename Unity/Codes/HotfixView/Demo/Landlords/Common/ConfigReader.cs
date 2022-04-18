using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System;
namespace ET
{
    ///<summary>
    ///�����ȡ�����ļ����ṩ������
    ///<summary>
    public static class ConfigReader
    {
        /// <summary>
        /// ���أ���ȡ�������ļ�
        /// </summary>
        /// <param name="fileName">�ļ���</param>
        /// <returns>��ȡ���ַ���(������)</returns>
        public static string GetConfigFile(string fileName)
        {
            string url = "";
            //���ƶ���ͨ��Application.StreamingAssets�����׿��ܻ���� Ӧ�����·���
            //url���ݲ�ͬƽ̨�в�ͬ��·��,���ú��ǩ�ڱ����ڼ����У���������ƽ̨ѡ���������
            //�������൱�ھ�ѡ����һ�����ʵ����url=xxxx  
            //if(Application.platform == RuntimePlatform.Android) �����Բ�
            if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                url = "file://" + Application.dataPath + "/StreamingAssets/" + fileName;
            else if(Application.platform == RuntimePlatform.IPhonePlayer)
                url = "file://" + Application.dataPath + "/Raw/"+fileName;
            else if(Application.platform == RuntimePlatform.Android)
                url = "jar:file://" + Application.dataPath + "!/assets/"+fileName;

            


            //�ƶ��˸���url�����ļ���Դ���շ���һ��string
            UnityWebRequest www = UnityWebRequest.Get(url);
            if (www == null)
            {
                Log.Error("Config������ ����");
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

            //��������string   "xxxName=xxxPath/r/nxxxName=xxxPath/r/n....
            //�����ַ���,����StringReader�ַ�����ȡ��������������ͷ��ڴ�
            //using ���������Զ��ͷ���Դ
            using (StringReader reader = new StringReader(fileContent))
            {
                string line;
                while ((line = reader.ReadLine()) != null) //���л�ȡ�ַ���
                {
                    //��������
                    handler(line);
                }
            }
        }
    }

}
