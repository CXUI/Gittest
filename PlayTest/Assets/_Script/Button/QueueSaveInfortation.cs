using UnityEngine;
using System.Collections;


/// <summary>
/// 队列存储信息
/// </summary>

//public delegate void QueueEventHandle(object send, QueueEventArgs e);  //声明委托
public class QueueSaveInfortation  
{
    private Queue queueArray;

    public Queue QueueArray
    {
        get { return queueArray; }
        set { queueArray = value; }
    }

   // public event QueueEventHandle queueEvent;  //监听事件

    public static QueueSaveInfortation instance;

    public QueueSaveInfortation() 
    {

         QueueArray = new Queue();
       //queueEvent += new QueueEventHandle(OnEventQueue);

        AddEventListent.EventHandle += new DelegateEventHandle(OnEventQueue);//绑定事件
 
    }

   
    public static QueueSaveInfortation Instance()
    {
        if (instance == null)
        {
            instance = new QueueSaveInfortation();
        }

        return instance;
    }

    /// <summary>
    /// 判断队列里面是否有元素
    /// </summary>
    /// <param name="Sent"></param>
    /// <param name="e"></param>
    private bool OnEventQueue(object Sent, QueueEventArgs e)
    {
        if (e.count > 0)
        {
            Debug.Log("队列不为空：" + e.count);
            
            return true;
        }
        else
        {
            Debug.Log("队列为空");
            return false;
        }

    }

    //添加监听
    //public void OnAddListentQueue(int count, string conText)
    //{
    //    if (queueEvent != null)
    //    {
    //        queueEvent(this, new QueueEventArgs(count, conText));
    //    }
    //    AddEventListent a = new AddEventListent();
    //    a.AddListentQueue(count, conText);
    //}



    /// <summary>
    /// 入队
    /// </summary>
    public void QueueEnqueue(GameObject array)
    {
        QueueArray.Enqueue(array);

    }

    /// <summary>
    /// 出队
    /// </summary>
    public void QueueDequeue()
    {
        QueueArray.Dequeue();
    }

    /// <summary>
    /// 返回队列中的第一个元素
    /// </summary>
    /// <returns></returns>

    public GameObject  QueuePeek()
    {
      return (GameObject)QueueArray.Peek();
    }

    /// <summary>
    /// 调出队列的长度
    /// </summary>
    /// <returns></returns>
    public int QueueCount()
    {
        return QueueArray.Count;
    }

    /// <summary>
    /// 清除队列中的元素
    /// </summary>
    public void QueueClear()
    {
        QueueArray.Clear();
    }

    /// <summary>
    /// 显示队列中的元素
    /// </summary>
    public void ShowQueueElement()
    {
        foreach(var temp in QueueArray)
        {
            Debug.Log(temp);
        }
    }

    /// <summary>
    /// 队列里面的元素数量，是否为空
    /// </summary>
    public bool  QueueElementCount()
    {
       // AddEventListent listent = new AddEventListent();

        return AddEventListent.Instance().AddListentQueue(QueueArray.Count, QueueArray.ToString());
 
    }

 
}
