using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainChar : MonoBehaviour
{
    public List<SavableObjects> savableObjects;
    public GameObject hair, clothes, shoes;
    public GameObject myObject;

    void Awake()
    {
        myObject = this.GetComponent<GameObject>();
    }
    void Start()
    {
        int getDetail;

        getDetail = PlayerPrefs.GetInt("SelectedDetail");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class SavableObjects
    {
        public string id;
        public float px, py, pz;
        public float rx, ry, rz, rw;

        public SavableObjects(string id, Vector3 position, Quaternion rotation)
        {
            this.id = id;
            px = position.x;
            py = position.y;
            pz = position.z;

            rx = rotation.x;
            ry = rotation.y;
            rz = rotation.z;
            rw = rotation.w;
        }

        public Vector3 ReturnPosition()
        {
            Vector3 pos = new Vector3(px, py, pz);
            return pos;
        }
    }
}
