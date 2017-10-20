using UnityEngine;
using System.Collections;

public delegate bool  DelegateEventHandle(object send,QueueEventArgs e);

public class AddEventListent {


    public static AddEventListent instance;


    public static AddEventListent Instance()
    {
        if(instance==null)
        {
            instance = new AddEventListent();

        }

        return instance;
    }


    public static  event DelegateEventHandle EventHandle;

 
    /// <summary>
    /// 把事件注册到委托中
    /// </summary>
  //  public static  void ListentQueueElement()
   // {
       // EventHandle += new DelegateEventHandle(OnEventQueue);
       
   // }

    /// <summary>
    /// 关联事件
    /// </summary>
    /// <param name="Sent"></param>
    /// <param name="e"></param>
   // private static  void OnEventQueue(object Sent, QueueEventArgs e)
   // {
        //if (e.count > 0)
        //{
        //    Debug.Log("队列不为空：" + e.count);
        //}
        //else
        //{
        //    Debug.Log("队列为空");
        //}

   // }


    /// <summary>
    /// 添加监听
    /// </summary>
    /// <param name="count"></param>
    /// <param name="context"></param>
    public   bool  AddListentQueue(int count,string context)
    {
        if(EventHandle!=null)
        {
         return EventHandle(this, new QueueEventArgs(count, context));

        }
        return false;
    }
	 
}
