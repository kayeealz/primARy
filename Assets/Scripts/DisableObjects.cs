using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjects : MonoBehaviour
{
    public GameObject parentGameObject;
    
    public void DisableAllObject()
    {
        for (int i =0; i < parentGameObject.transform.childCount; i++)
        {
            var child = parentGameObject.transform.GetChild(i).gameObject;

            if (child != null)
            {
                child.SetActive(false);
            }
        }
    }

 
}
