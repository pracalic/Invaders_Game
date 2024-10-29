using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GsmeSet : Singleton<GsmeSet>
{
    [SerializeField]
    bool fromUpToDown = false;
    [SerializeField]
    float startEnemyRotation = 270f;

    public float GetStartEnemyRotation
    {
        get
        {
            return startEnemyRotation;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
