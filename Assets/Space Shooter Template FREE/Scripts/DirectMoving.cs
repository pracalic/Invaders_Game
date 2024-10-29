using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface MoveStrategy
{
    public Vector3 Move(float speed);
    public bool IsVisible(Transform tr, float invisibleLenght);

    public Vector3 GiveChangePosition(float lenght);

}

public class MoveFromUpToDownStrategy : MoveStrategy
{

    public Vector3 Move(float speed)
    {
        return new Vector3(0, -speed, 0);
    }
    public bool IsVisible(Transform tr, float invisibleLenght)
    {
        if (tr.position.y < invisibleLenght)
            return false;
        return true;
    }

    public Vector3 GiveChangePosition(float lenght)
    {
        return new Vector3(0, -lenght *2, 0);
    }
}

public class MoveFromRightToLeftStrategy : MoveStrategy
{
    public Vector3 Move(float speed)
    {
        return new Vector3(-speed, 0, 0);
    }

    public bool IsVisible(Transform tr, float invisibleLenght)
    {
        if (tr.position.x < invisibleLenght*2)
            return false;
        return true;
    }

    public Vector3 GiveChangePosition(float lenght)
    {
        return new Vector3( -lenght * 4, 0, 0);
    }
}
/// <summary>
/// This script moves the attached object along the Y-axis with the defined speed
/// </summary>
public class DirectMoving : MonoBehaviour {

    [Tooltip("Moving speed on Y axis in local space")]
    public float speed;
    [SerializeField]
    bool fromUpToDown = false;

    MoveStrategy ms;

    public MoveStrategy GetMoveStrategy
    {
        get { return ms; }
    }

    private void Awake()
    {
        if (fromUpToDown)
        {
            ms = new MoveFromUpToDownStrategy();
        }
        else
        {
            ms = new MoveFromRightToLeftStrategy();
        }
    }


    //moving the object with the defined speed
    private void Update()
    {
        transform.Translate(transform.rotation * ms.Move(speed) * Time.deltaTime); 
    }
}
