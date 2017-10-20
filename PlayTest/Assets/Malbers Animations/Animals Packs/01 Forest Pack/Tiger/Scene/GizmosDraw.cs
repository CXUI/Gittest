using UnityEngine;
using System.Collections;

public class GizmosDraw : MonoBehaviour {

    public Color drawColor = Color.red;


    public void OnDrawGizmos() 
    {
        Gizmos.color = drawColor;
        Gizmos.DrawRay(transform.position,transform.up*10);
        Gizmos.DrawSphere(transform.up * 10, 0.03f);
    }

}
