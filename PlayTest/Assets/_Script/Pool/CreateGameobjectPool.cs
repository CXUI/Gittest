using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

class CreateGameobjectPool
{
#region 声明物体类
    //ObjectBirdPool bird;

    //ObjectDeerPool deer;

    //ObjectTrigerPool triger;
#endregion

    public static CreateGameobjectPool instance;
    /// <summary>
    /// 构造函数
    /// </summary>
    //public CreateGameobjectPool()
    //{
    //    bird = new ObjectBirdPool();
    //    deer = new ObjectDeerPool();
    //    triger = new ObjectTrigerPool();
    //}

    /// <summary>
    /// 单利
    /// </summary>
    /// <returns></returns>
    public static CreateGameobjectPool Instance() { 
    
        if(instance==null)
        {

            instance = new CreateGameobjectPool();

        }
        return instance;

    }

    /// <summary>
    /// 简单工厂调用
    /// </summary>
    /// <param name="objectType"></param>
    /// <returns></returns>
    public static GamePool GameobjetPools(string objectType) 
    {

        GamePool pool = null;

        switch(objectType)
        {
            case "Triger": pool = new ObjectTrigerPool(); break;
            case "Deer": pool = new ObjectDeerPool(); break;
            case "Bird": pool = new ObjectBirdPool(); break;
           // default: pool = null; break;

        }
        Debug.Log("pooooooooooooooooool" + pool);
        return pool;

    }


}

