using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    

    public void DestroyGameObject()
    {
        Destroy (GameObject.FindWithTag("customize"));
    }
}
