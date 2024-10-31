using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDisactivateObiect : MonoBehaviour
{

    public void Toogle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    
}
