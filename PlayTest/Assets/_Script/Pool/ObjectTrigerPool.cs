﻿using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ObjectTrigerPool:GamePool
{
    public override GameObject DequeuePool()
    {
        return base.DequeuePool();
    }

    public override void EnqueuePool(GameObject obj)
    {
        base.EnqueuePool(obj);
    }
 
}


public class ObjectBirdPool : GamePool
{
    public override GameObject DequeuePool()
    {
        return base.DequeuePool();
    }

    public override void EnqueuePool(GameObject obj)
    {
        base.EnqueuePool(obj);
    }


    //public void CretaeGame()
    //{
    //    for (int i = 0; i < 10;i++ )
    //    {
    //        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
    //        EnqueuePool(obj);
    //    }
    //}
}


public class ObjectDeerPool : GamePool
{
    public override GameObject DequeuePool()
    {
        return base.DequeuePool();
    }

    public override void EnqueuePool(GameObject obj)
    {
        base.EnqueuePool(obj);
    }
}

