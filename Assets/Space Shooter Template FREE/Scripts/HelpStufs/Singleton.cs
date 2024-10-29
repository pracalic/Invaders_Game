using UnityEngine;

public class Singleton<Instance> : MonoBehaviour where Instance : Singleton<Instance>
{
    public static Instance instance;

    protected virtual void Awake()
    {
        if (!instance)
        {
            instance = this as Instance;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}