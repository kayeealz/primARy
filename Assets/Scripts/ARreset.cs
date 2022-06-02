using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARreset : MonoBehaviour
{
    [SerializeField] ARSession arSession; // assign this field via Inspector
 
 
    void Awake() {
        bool needReset = false; // replace with your own code
        if (needReset) {
            arSession.Reset();
            Debug.Log("Reset");
        }
    }

    public void ResetSession()
    {
        LoaderUtility.Deinitialize();
        LoaderUtility.Initialize();
    }

}
