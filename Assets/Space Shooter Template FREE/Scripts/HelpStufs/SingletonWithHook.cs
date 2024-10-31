using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonWithHook<Instance> : Singleton<Instance> where Instance : SingletonWithHook<Instance>
{
    protected override void Awake()
    {
        InitHook();
        base.Awake();
    }
    protected virtual void InitHook()
    {

    }
}
