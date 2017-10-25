using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

class Pool:MonoBehaviour
{
    [Range(2,6)]
    public int gameobjectNumber = 4;

    void Start() 
    {
        CretaGameObject();
        CretaGameObjectDeer();
    }

    void FixedUpdate()
    { 
    


    }

    public void CretaGameObject()
    {
        GamePool trger = CreateGameobjectPool.GameobjetPools("Triger");

      
        for (int i = 0; i < gameobjectNumber;i++ )
        {
            GameObject obj = Instantiate(Resources.Load("Trger/WhiltTiger", typeof(GameObject))) as GameObject;

            trger.EnqueuePool(obj);

            trger.FindQueueCound("Triger");

        }
    }

    public void CretaGameObjectDeer() {

        GamePool trger = CreateGameobjectPool.GameobjetPools("Deer");

       // GameObject obj = Instantiate(Resources.Load("Trger/YellowTiger", typeof(GameObject))) as GameObject;

        for (int i = 0; i < gameobjectNumber; i++)
        {
            GameObject obj = Instantiate(Resources.Load("Trger/YellowTiger", typeof(GameObject))) as GameObject;

            trger.EnqueuePool(obj);

            trger.FindQueueCound("Deer");

        }
    }
}

