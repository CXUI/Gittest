using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;
public class ReandingXML
{
    public static ReandingXML instance;

    public string path = "/ImageName.xml";

    public Dictionary<string, SaveDictionary> dicSave;

    /// <summary>
    /// 单例
    /// </summary>
    /// <returns></returns>

    public static ReandingXML Instance()
    {
        if(instance==null)
        {
            instance = new ReandingXML();
        }
        return instance;
    }

    public ReandingXML()
    {
        dicSave = new Dictionary<string, SaveDictionary>();
    }

    /// <summary>
    /// 从指定的文件位置读取xml
    /// </summary>
    /// <returns></returns>
    public XmlDocument GetXml()
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(Application.streamingAssetsPath + path);

        return xml;
    }

    /// <summary>
    /// 运行RenderXml方法
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, SaveDictionary> DicSave() 
    { 
    
        if(dicSave==null)
        {
            dicSave = new Dictionary<string, SaveDictionary>();
            RenderXml();
        }
        else
        {
            RenderXml();
        }
       
        return dicSave;
    }


    /// <summary>
    /// 读取xml信息，并保存到字典里面
    /// </summary>
    public void RenderXml()
    {
        XmlDocument rXml = GetXml();        //获取到xml文件

        XmlNodeList xmlList = rXml.SelectSingleNode("RECORDS").ChildNodes;//得到相应的节点

        foreach(XmlElement temp in xmlList)
        {
            SaveDictionary saveDic = new SaveDictionary();

            saveDic.Describe = temp.GetAttribute("describe");
            saveDic.Name = temp.GetAttribute("name");
            saveDic.Path = temp.GetAttribute("path");
            saveDic.Id = temp.GetAttribute("id");
        
            dicSave[temp.GetAttribute("id")] = saveDic;//设置字典Key值,
            // dicSave["string"] = saveDic;//给字典value赋值
            //dicSave["string"] //创建一个字典的key，

            
        }

         
    }
	 
}


/// <summary>
/// 字典Value中的值
/// </summary>
public class SaveDictionary
{
    private string name;//图片的名称

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string describe;//图片的描述

    public string Describe
    {
        get { return describe; }
        set { describe = value; }
    }

    private string path;   //路径

    public string Path
    {
        get { return path; }
        set { path = value; }
    }

    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
   
}
