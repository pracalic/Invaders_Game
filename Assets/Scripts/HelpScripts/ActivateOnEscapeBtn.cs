using UnityEngine;
using UnityEngine.Events;

public class ActivateOnEscapeBtn : MonoBehaviour
{
    public UnityEvent unityEvent;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) unityEvent.Invoke();
    }
}
