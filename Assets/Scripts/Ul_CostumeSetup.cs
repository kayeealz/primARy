using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Ul_CostumeSetup : MonoBehaviour
{
    public enum CustomeOperation
    {
        ObjectShuffle,
        ChangeMaterial
    }
    //
    public CustomeOperation GetCustomeOperation = CustomeOperation.ObjectShuffle;
    //
    [Serializable]
    public class ObjectInstantaitionSettings
    {
        public String ObjectName;
        public int ClassID;
        public GameObject SceneObject;
    }
    //
    [Serializable]
    public class MaterialChanger
    {
        public String MaterialName = "DefaultMat";
        public int ClassID;
        public Material MaterialPrefab;
        public enum RendererType
        {
            Mesh,
            SkinnedMesh
        }
        public RendererType GetRenderer = RendererType.SkinnedMesh;
        public List<MeshRenderer> GetMeshRenderer;
        public List<SkinnedMeshRenderer> GetSkinnedMeshRenderers;
    }
    //
    public List<MaterialChanger> materialChangers = new List<MaterialChanger>();
    //
    public List<ObjectInstantaitionSettings> GetObjectInstantaitionSettings;
    //
    public GameObject GetObj;

    public bool CallOnStart = true;
    public int SelectedSpawnObject;
    public string SavedHash = "#default";
    //
    private void Start()
    {
        if (CallOnStart)
            CreateNewCharacter(0);
    }
    //
    public void IncreaseObjectIndex()
    {
        if (SelectedSpawnObject < GetObjectInstantaitionSettings.Count - 1)
            SelectedSpawnObject++;
        CreateNewCharacter(SelectedSpawnObject);
    }
    //
    public void DecreaseObjectIndex()
    {
        if (SelectedSpawnObject >= 1)
            SelectedSpawnObject--;
        CreateNewCharacter(SelectedSpawnObject);
    }
    //
    public void IncreaseMaterialIndex()
    {
        if (SelectedSpawnObject < materialChangers.Count - 1)
            SelectedSpawnObject++;
        CreateMaterialInstance(SelectedSpawnObject);
    }
    //
    public void DecreaseMaterialIndex()
    {
        if (SelectedSpawnObject >= 1)
            SelectedSpawnObject--;
        CreateMaterialInstance(SelectedSpawnObject);
    }
    //
    public void CreateCharacterPrefs()
    {
        //if (GetObj == null) return;
        if (GetCustomeOperation == CustomeOperation.ObjectShuffle)
        {

            //store Material changer
            PlayerPrefs.SetInt(SavedHash + "SetObjInst", SelectedSpawnObject);
            PlayerPrefs.Save();
        }
        else
        {
            //store objectnstantiation; 
            PlayerPrefs.SetInt(SavedHash + "SetMatChanger", SelectedSpawnObject);
            //
            PlayerPrefs.Save();
        }
    }
    //
    public void LoadCharacterPrefs()
    {
        if (GetCustomeOperation == CustomeOperation.ObjectShuffle)
        {
            SelectedSpawnObject = PlayerPrefs.GetInt(SavedHash + "SetObjInst");
            //            print(SelectedSpawnObject);
            CreateNewCharacter(SelectedSpawnObject);
        }
        else
        {
            SelectedSpawnObject = PlayerPrefs.GetInt(SavedHash + "SetMatChanger");
            // print(SelectedSpawnObject);
            CreateMaterialInstance(SelectedSpawnObject);
        }
    }
    //
    public void CreateMaterialInstance(int i)
    {
        if (GetCustomeOperation == CustomeOperation.ObjectShuffle) return;
        SelectedSpawnObject = i;
        if (materialChangers != null)
        {
            if (materialChangers.Count > 0)
            {
                if (true)
                {
                    switch (materialChangers[i].GetRenderer)
                    {
                        case MaterialChanger.RendererType.Mesh:
                            {
                                for (int k = 0; k < materialChangers[i].GetMeshRenderer.Count; ++k)
                                {
                                    materialChangers[i].GetMeshRenderer[k].sharedMaterial = materialChangers[i].MaterialPrefab;
                                }
                            }
                            break;
                        case MaterialChanger.RendererType.SkinnedMesh:
                            {

                                for (int k = 0; k < materialChangers[i].GetSkinnedMeshRenderers.Count; ++k)
                                {
                                    materialChangers[i].GetSkinnedMeshRenderers[k].sharedMaterial = materialChangers[i].MaterialPrefab;
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
    //
    public void CreateNewCharacter(int i)
    {
        if (GetCustomeOperation == CustomeOperation.ChangeMaterial) return;
        if (GetObjectInstantaitionSettings == null) return;
        if (GetObjectInstantaitionSettings.Count == 0) return;
        SelectedSpawnObject = i;
        if (GetObj != null)
        {
            GetObj.SetActive(false);
        }
        GetObj = GetObjectInstantaitionSettings[i].SceneObject;
        GetObj.SetActive(true);
    }
    //
}
