using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class MouseClieckEvent : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler, IPointerEnterHandler, IDragHandler
{


    // public void

    public Transform tempParent; //记录图片的原父物体

    public Transform images;//拖拽时的父物体

    public RaycastHit hit;

    public Text name;//显示图片的名字

    public static float oldImageheight = 100;//GridLayoutPanel的高度
    public static int imageNumber = 0;      //图片下标

    public Transform oldImage; //使用过的image的父物体
    void Start()
    {
        images = GameObject.Find("tempParentImage").transform;
        name = GameObject.Find("Text").GetComponent<Text>();
        oldImage = GameObject.Find("GridLayoutPanel").transform;
    }

    /// <summary>
    /// 鼠标松开
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("鼠标松开（Anyplace）");


        transform.parent = tempParent;
        transform.localPosition = Vector3.zero;


        transform.GetComponent<CanvasGroup>().blocksRaycasts = true;

        CameraRay();
    }

    /// <summary>
    /// 鼠标在image上松开
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("鼠标松开（在Image）");
    }

    /// <summary>
    /// 鼠标在image点击按下
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("鼠标点击");


        tempParent = transform.parent;

        transform.parent = images;

        transform.GetComponent<CanvasGroup>().blocksRaycasts = false;

         
    }

    /// <summary>
    /// 鼠标离开image
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("鼠标离开");
        name.text = string.Empty;
        //name.transform.parent = null;   
    }

    /// <summary>
    /// 鼠标悬浮在image上
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("鼠标悬浮");

        QueueSaveInfortation.Instance().QueueElementCount();



        name.transform.parent = eventData.pointerCurrentRaycast.gameObject.transform;
        name.transform.localPosition = new Vector3(0, -40, 0);
        name.text = eventData.pointerCurrentRaycast.gameObject.name;

    }


    /// <summary>
    /// 鼠标退拽时
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;

    }

    /// <summary>
    /// 摄像机发射射线
    /// </summary>
    public Transform CameraRay()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);

            CreateGameObject(hit.point);
            return hit.transform;
        }
        return null;

    }

    /// <summary>
    /// 生成物体
    /// </summary>
    /// <param name="points"></param>
    public void CreateGameObject(Vector3 points)
    {
        GameObject trig = Instantiate(Resources.Load("Trger/BlackTiger", typeof(GameObject)), points, Quaternion.identity) as GameObject;
        CreateImage();
    }


    /// <summary>
    /// 生成以及存放到栈中的物体
    /// </summary>
    public void CreateImage() 
    {
        //生成该物体，调整物体和位置，调整该父物体的高度
        GameObject oldIma = Instantiate(transform.gameObject, oldImage)as GameObject;
        oldIma.transform.position = new Vector3(0, 0, 0);
        oldIma.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(30, 30);
        oldImage.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(50, (oldImageheight<1200? oldImageheight += 40:oldImageheight));

       
        //检测物体里面是否有子物体
        if(oldIma.transform.childCount==0)
        {
            GameObject te = Instantiate(name.gameObject)as GameObject;
            te.transform.parent = oldIma.transform;
            te.name = "Text";
        }

        //更改子物体的大小，位置
       Text teTemp = oldIma.transform.FindChild("Text").gameObject.GetComponent<Text>();  
       teTemp.GetComponent<Text>().rectTransform.sizeDelta = new Vector2(20, 20);
       teTemp.transform.position = new Vector3(10, -10, 0);


        //压栈
       QueueSaveInfortation.Instance().QueueEnqueue(oldIma.gameObject);
        //出栈  删除
       if (QueueSaveInfortation.Instance().QueueCount()>30)
         {
            
             Destroy(QueueSaveInfortation.Instance().QueuePeek());
             QueueSaveInfortation.Instance().QueueDequeue();
         }

        //删除该物体上面的脚本和组件。
        teTemp.text = (imageNumber++).ToString();
        Destroy(oldIma.GetComponent<MouseClieckEvent>());
        Destroy(oldIma.GetComponent<CanvasGroup>());

    }
}
