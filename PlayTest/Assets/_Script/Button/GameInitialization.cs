using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Linq;
 
    //初始化
    class GameInitialization:MonoBehaviour
    {

        private const  int number = 8;

        public Image[] imageArray;

        public string path;

        public Image ssss;
        Texture2D tex;

        public static Dictionary<string , string> GetImageName = new Dictionary<string, string>();
        void Awake()
        {
          //AddQueueElement();
            
        }

        void Start()
        {
          

            GetDictionarySaveInfortation();

        }

 

        /// <summary>
        /// 检测子物体
        /// </summary>
        public void TestingImageArrayChild()
        {
            for (int i = 0; i < imageArray.Length;i++ )
            {
                if(imageArray[i].transform.childCount==0)
                {
                    
                }

            }

        }

        /// <summary>
        /// 得到字典保存的信息
        /// </summary>
        public void GetDictionarySaveInfortation()
        {
            foreach(var temp in ReandingXML.Instance().DicSave())
            {
                path = temp.Value.Path + temp.Value.Name;
                StartCoroutine(ReadingImage(path,int.Parse(temp.Key.ToString())));

                GetImageName.Add(temp.Value.Id, temp.Value.Describe);

            }
            
        }


        /// <summary>
        /// 读取图片
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IEnumerator ReadingImage(string path,int id)
        {
            //WWW www = new WWW("file://"+Application.streamingAssetsPath+"/Image"+"/0.png");
            WWW www = new WWW("file://" + Application.streamingAssetsPath + path);

            yield return www;

            if(string.IsNullOrEmpty(www.error))
            {
                tex = www.texture;
               // imageArray[id].GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.height, tex.width), Vector2.zero);

                //aaa.rectTransform.sizeDelta = new Vector2(50, 50);

               Image sprites = Instantiate(ssss.GetComponent<Image>());

               sprites.GetComponent<Image>();

               sprites.gameObject.name = GetImageName[id.ToString()];

               sprites.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(50, 50);

               sprites.transform.SetParent(imageArray[id].transform);

               sprites.transform.localPosition = new Vector3(0, 0, 0);

               sprites.transform.localScale = new Vector3(1, 1, 1);

               sprites.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.height, tex.width), Vector2.zero);

               sprites.gameObject.AddComponent<MouseClieckEvent>();
            }
            else
            {
                Debug.Log(www.error);
            }
        }


    }

