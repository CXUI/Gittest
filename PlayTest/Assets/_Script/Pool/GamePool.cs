using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

/// <summary>
/// 对象池
/// </summary>
public class GamePool 
{
   
    public Queue<GameObject> queueObject;

    public GamePool() 
    {

        queueObject = new Queue<GameObject>();
    }

    /// <summary>
    /// 入队
    /// </summary>
    /// <param name="obj"></param>
    public virtual void EnqueuePool(GameObject obj)
    {
        
        queueObject.Enqueue(obj);

    }

    /// <summary>
    /// 出队
    /// </summary>
    /// <returns></returns>
    public virtual GameObject DequeuePool()
    {
       // FindQueueCound();
        return queueObject.Dequeue(); 

    }

    public  void FindQueueCound(string name) 
    {
        Debug.Log(name+"队列的长度："+queueObject.Count);

    }




    public void CreateOb() 
    {

        for (int i =0; i < 5;i++ )
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Capsule);

            queueObject.Enqueue(obj);

        }

    }

    public void CreateObject()
    {
        for (int i = 0; i < 10;i++ )
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

            queueObject.Enqueue(obj);

         Debug.Log(queueObject.Count);
        }
    }

    
}
     
 
