using UnityEngine;

public interface IMoveFromUpToDownStrategy
{
    bool IsVisible(Transform tr, float invisibleLenght);
    Vector3 Move(float speed);
}