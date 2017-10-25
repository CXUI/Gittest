using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

class TestPool:MonoBehaviour 
{

    ObjectTrigerPool triger = new ObjectTrigerPool();

    ObjectDeerPool deer = new ObjectDeerPool();

    ObjectBirdPool bird = new ObjectBirdPool();



    void FixedUpdate() 
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
           
            triger.DequeuePool();

        }
        if (Input.GetKeyDown(KeyCode.B))
        {

            deer.DequeuePool();

        }
        if (Input.GetKeyDown(KeyCode.V))
        {

            bird.DequeuePool();

        }




        if (Input.GetKeyDown(KeyCode.D))
        {
           
            TrigerPool();

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            BirdPool();

        }
        if (Input.GetKeyDown(KeyCode.G))
        {
           
            DeerPool();

        }



         

    }


    void TrigerPool()
    {

        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Capsule);

        triger.EnqueuePool(obj);
    }

    void BirdPool() 
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        bird.EnqueuePool(obj);
        
    }

    void DeerPool() 
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        deer.EnqueuePool(obj);
    }


}

