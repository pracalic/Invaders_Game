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
        return new Vector3(0, -lenght * 2, 0);
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
        if (tr.position.x < invisibleLenght * 2)
            return false;
        return true;
    }

    public Vector3 GiveChangePosition(float lenght)
    {
        return new Vector3(-lenght * 4, 0, 0);
    }
}

public class GameSet : SingletonWithHook<GameSet>
{
    [SerializeField]
    bool fromUpToDown = false;
    [SerializeField]
    float startEnemyRotation = 270f;

    [SerializeField]
    GameObject menuInGame = null;


    public GameObject GetMenu
    {
        get { return menuInGame; } 
    }
    
    public bool GetMoveDirection
    {
        get
        {
            return fromUpToDown;

        }
    }

    public float GetStartEnemyRotation
    {
        get
        {
            return startEnemyRotation;

        }
    }


    MoveStrategy ms;

    public MoveStrategy GetMoveStrategy
    {
        get { return ms; }
    }

    protected override void InitHook()
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
