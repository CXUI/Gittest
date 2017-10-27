using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

class Pool:MonoBehaviour
{
    #region 变量
    [Range(2,6)]
    public int gameobjectNumber = 4;
    #endregion

    public static Pool instance;
    public List<GamePool> listPool = new List<GamePool>();

    public  Pool()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start() 
    {
        CretaGameObject();
        CretaGameObjectDeer();
        CretaGameObjectBird();
    }

 

    #region 方法
    /// <summary>
    /// 生成动物Triger
    /// </summary>
    public void CretaGameObject()
    {
        GamePool trger = CreateGameobjectPool.GameobjetPools("Triger");

        listPool.Add(trger);
      
        for (int i = 0; i < gameobjectNumber;i++ )
        {
            GameObject obj = Instantiate(Resources.Load("Trger/WhiltTiger", typeof(GameObject))) as GameObject;

            trger.EnqueuePool(obj);

            trger.FindQueueCound("Triger");

        }
    }

    /// <summary>
    /// 生成动物Deer
    /// </summary>
    public void CretaGameObjectDeer() {

        GamePool trger = CreateGameobjectPool.GameobjetPools("Deer");

        listPool.Add(trger);
       // GameObject obj = Instantiate(Resources.Load("Trger/YellowTiger", typeof(GameObject))) as GameObject;

        for (int i = 0; i < gameobjectNumber; i++)
        {
            GameObject obj = Instantiate(Resources.Load("Trger/YellowTiger", typeof(GameObject))) as GameObject;

            trger.EnqueuePool(obj);

            trger.FindQueueCound("Deer");

        }
    }

    /// <summary>
    /// 生成动物Bird
    /// </summary>
    public void CretaGameObjectBird()
    {

        GamePool trger = CreateGameobjectPool.GameobjetPools("Bird");

        listPool.Add(trger);
        // GameObject obj = Instantiate(Resources.Load("Trger/YellowTiger", typeof(GameObject))) as GameObject;

        for (int i = 0; i < gameobjectNumber; i++)
        {
            GameObject obj = Instantiate(Resources.Load("Trger/BlackTiger", typeof(GameObject))) as GameObject;

            trger.EnqueuePool(obj);

            trger.FindQueueCound("Bird");

        }
    }

    #endregion
}

