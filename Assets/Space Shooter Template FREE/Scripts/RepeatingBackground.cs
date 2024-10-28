using UnityEngine;

/// <summary>
/// This script attaches to ‘Background’ object, and would move it up if the object went down below the viewport border. 
/// This script is used for creating the effect of infinite movement. 
/// </summary>
/// 

interface MoveStrategy
{
    public Vector3 Move(float speed);

}

class MoveFromUpToDown : MoveStrategy
{

    public Vector3 Move(float speed)
    {
        throw new System.NotImplementedException();
    }
}

class MoveFromRightToLeft : MoveStrategy
{
    public Vector3 Move(float speed)
    {
        throw new System.NotImplementedException();
    }
}


public class RepeatingBackground : MonoBehaviour
{
    [Tooltip("vertical size of the sprite in the world space. Attach box collider2D to get the exact size")]
    public float verticalSize;
    
    private void Update()
    {
        

        if (transform.position.y < -verticalSize) //if sprite goes down below the viewport move the object up above the viewport
        {
            RepositionBackground();
        }
    }

    void RepositionBackground() 
    {
        Vector2 groundOffSet = new Vector2(0, verticalSize * 2f);
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}
