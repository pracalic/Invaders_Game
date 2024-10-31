using Unity.Hierarchy;
using UnityEngine;

/// <summary>
/// This script attaches to ‘Background’ object, and would move it up if the object went down below the viewport border. 
/// This script is used for creating the effect of infinite movement. 
/// </summary>
/// 




public class RepeatingBackground : MonoBehaviour
{
    [Tooltip("vertical size of the sprite in the world space. Attach box collider2D to get the exact size")]
    public float verticalSize;
    MoveStrategy ms;
    private void Start()
    {
        ms = GameSet.instance.GetMoveStrategy;
        // Debug.Log(ms);
    }


    private void Update()
    {
        if (!ms.IsVisible(transform, verticalSize))
        {
            RepositionBackground();
        }

        //if (transform.position.y < -verticalSize) //if sprite goes down below the viewport move the object up above the viewport
        //{
        //    RepositionBackground();
        //}
    }

    void RepositionBackground() 
    {
        //Vector2 groundOffSet = new Vector2(0, verticalSize * 2f);
        //transform.position = (Vector2)transform.position + groundOffSet;
        transform.position += ms.GiveChangePosition(verticalSize);
    }
}
