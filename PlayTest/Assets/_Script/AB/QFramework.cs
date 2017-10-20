using UnityEngine;
using System.Collections;
using System.IO;


public class QFramework : MonoBehaviour {


    public string busUnity;
    public string busName;

    private float x;
    public GameObject tr;

 
    // Use this for initialization
    void Start()
    {

       // StartCoroutine(GameInstanciate(busUnity, busName));
 

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    IEnumerator GameInstanciate(string unity, string name)
    {

        WWW www = new WWW("file:///" + Application.streamingAssetsPath +"/QAB/" +  unity);

        yield return www;

        Debug.Log(www.url);
            

        if (string.IsNullOrEmpty(www.error))
        {
            
            var go = www.assetBundle.LoadAsset<GameObject>(name);

            Instantiate(go);
            www.assetBundle.Unload(false);
        }
        else
        {
            Debug.LogError(www.error);
        }
    }
}
