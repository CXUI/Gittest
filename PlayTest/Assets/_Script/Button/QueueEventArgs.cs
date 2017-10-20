using UnityEngine;
using System.Collections;

public class QueueEventArgs  
{

    public int count;
    public string conText;

    public QueueEventArgs(int cou,string con)
    {
        count = cou;
        conText = con;

    }
}
