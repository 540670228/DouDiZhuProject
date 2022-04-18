using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Management.Instrumentation;
using UnityEditor;
using UnityEngine;

public class GenrateResConfig : Editor
{
    [MenuItem("Tools/Resources/Generate ResConfig File")]
    public static void Generate()
    {
        File.WriteAllLines("Assets/StreamingAssets/ConfigMap.txt",new string[0]);
        List<string> typeList = new List<string>();
        List<string> suffixList = new List<string>();
        typeList.Add("prefab");
        suffixList.Add("");
        typeList.Add("ScriptableObject");
        suffixList.Add("asset");
        typeList.Add("AudioClip");
        suffixList.Add("ogg&mp3");
        typeList.Add("Texture");
        suffixList.Add("png&jpg&ttf");
        int i = 0;
        
        foreach(string type in typeList)
        {
            string[] mapArr = getMapping(type,suffixList[i++]);
            //3.д���ļ�
            
            if(!Directory.Exists("Assets/StreamingAssets"))
            {
                Directory.CreateDirectory("Assets/StreamingAssets");
            }
            File.AppendAllLines("Assets/StreamingAssets/ConfigMap.txt", mapArr);
        }
        //ˢ��
        AssetDatabase.Refresh();
        
    }

    private static string[] getMapping(string type,string suffix = null)
    {
        //������Դ�����ļ�
        //1.����ResourcesĿ¼������Ԥ�Ƽ�������·��
        //����ֵΪGUID ��Դ��� �� ����1 ָ�����ͣ�����2 ����Щ·���²���
        string[] resFiles = AssetDatabase.FindAssets($"t:{type}", new string[] { "Assets/Resources" });
        for (int i = 0; i < resFiles.Length; i++)
        {
            resFiles[i] = AssetDatabase.GUIDToAssetPath(resFiles[i]);
            //2.���ɶ�Ӧ��ϵ  ����=·��
            string fileName = Path.GetFileNameWithoutExtension(resFiles[i]);
            string filePath = resFiles[i].Replace("Assets/Resources/", string.Empty)
                .Replace($".{type}", string.Empty);
            
            //�ָ�suffix�ַ���
            string[] suffixs = suffix.Split('&');
            foreach (string x in suffixs)
            {
                if(!string.IsNullOrEmpty(x))
                    filePath = filePath.Replace($".{x}", string.Empty);
            }
            resFiles[i] = fileName + "=" + filePath;
        }
        return resFiles;
    }


}
