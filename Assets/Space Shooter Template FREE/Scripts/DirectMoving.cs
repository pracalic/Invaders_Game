using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script moves the attached object along the Y-axis with the defined speed
/// </summary>
public class DirectMoving : MonoBehaviour {

    [Tooltip("Moving speed on Y axis in local space")]
    public float speed;
    // [SerializeField]
    // bool fromUpToDown = false;
    MoveStrategy ms;
    private void Start()
    {
        ms = GameSet.instance.GetMoveStrategy;
        // Debug.Log(ms);
    }



    //moving the object with the defined speed
    private void Update()
    {
        transform.Translate(transform.rotation * ms.Move(speed) * Time.deltaTime); 
    }
}
