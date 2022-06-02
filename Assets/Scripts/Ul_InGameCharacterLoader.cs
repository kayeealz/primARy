using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ul_InGameCharacterLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public bool UseInGameCostumeEditor = true;
    public List<Ul_CostumeSetup> costumeSetups = new List<Ul_CostumeSetup>();
    public List<Ul_CostumeSetup> IncostumeSetups = new List<Ul_CostumeSetup>();
    public GameObject CharacterAnchorPoint;
    public bool UseSmartLoaderOnStart = true, AutoSaveOnDisable = true;
    public GameObject CostumeMenuCamTarget;
    public GameObject[] InGameCamTarget;
    public bool UseParent = true;
    public Ul_CameraFocus cameraFocus;
    public GameObject CanvasMenu;
    public KeyCode CustomeMenuKey = KeyCode.Escape;
    [System.Serializable]
    public class GameCharacters
    {
        public string Name = "Female";
        public GameObject CostumeMenu;
        public GameObject Character;
    }
    public GameCharacters[] _GameChars;
    public string InGameSceneName = "DefaultName";
    //[HideInInspector]

    public bool HasLoadedDefaultScene = false, ToggleCanvas = false;
    //
    private void ApplyCameraFocus()
    {
        if (!HasLoadedDefaultScene)
        {
            if (CostumeMenuCamTarget != null)
            {
                cameraFocus.Target = CostumeMenuCamTarget;
            }
        }
        else
        if (InGameCamTarget.Length > 0)
        {
            for (int i = 0; i < InGameCamTarget.Length; ++i)
            {
                if (!UseParent)
                {
                    if (InGameCamTarget[i].activeSelf)
                        cameraFocus.Target = InGameCamTarget[i];
                }
                else
                {
                    if (InGameCamTarget[i].transform.parent.gameObject.activeSelf)
                        cameraFocus.Target = InGameCamTarget[i];
                }
            }
        }
    }
    //
    public void CallSave()
    {
        if (costumeSetups.Count <= 0) return;
        PlayerPrefs.SetString("Saved", "True");
        if (!HasLoadedDefaultScene)
        {
            for (int i = 0; i < costumeSetups.Count; ++i)
            {
                costumeSetups[i].CreateCharacterPrefs();
            }
        }
        else
        {
            //
            if (IncostumeSetups.Count > 0)
            {
                for (int i = 0; i < IncostumeSetups.Count; ++i)
                {
                    IncostumeSetups[i].CreateCharacterPrefs();
                }
            }
        }
    }
    //
    public void ClearPlayerPrefs()
    {
        //be careful with this Lad
        string SaveStatus = PlayerPrefs.GetString("Saved");
        if (SaveStatus == "True")
            PlayerPrefs.DeleteAll();
    }
    //
    public void RemoveMaterialChangerKey(string SavedHash)
    {
        PlayerPrefs.DeleteKey("Saved");
        PlayerPrefs.DeleteKey(SavedHash + "SetMatChanger");
    }
    //
    public void RemoveObjectInstantiationKey(string SavedHash)
    {
        PlayerPrefs.DeleteKey("Saved");
        PlayerPrefs.DeleteKey(SavedHash + "SetObjInst");
    }
    //
    public void LoadData()
    {
        if (costumeSetups.Count <= 0) return;
        string SaveStatus = PlayerPrefs.GetString("Saved");
        if (SaveStatus == "True")
        {
            //print("worked");
            if (CanvasMenu != null)
            {
                CanvasMenu.SetActive(false);
            }
            if (!HasLoadedDefaultScene)
            {
                for (int i = 0; i < costumeSetups.Count; ++i)
                {
                    costumeSetups[i].LoadCharacterPrefs();
                }
                if (IncostumeSetups.Count > 0)
                {
                    for (int i = 0; i < IncostumeSetups.Count; ++i)
                    {
                        IncostumeSetups[i].LoadCharacterPrefs();
                    }
                }
            }
            //
            //
            //SceneManager.UnloadSceneAsync(CharacterCustomizerSceneName);//
            if (HasLoadedDefaultScene == false)
            {
                SceneManager.LoadScene(InGameSceneName);
            }

        }
    }
    void Update()
    {
        ApplyCameraFocus();
        if (HasLoadedDefaultScene == false)
        {
            if (CharacterAnchorPoint != null)
            {
                if (_GameChars.Length > 0)
                {
                    for (int i = 0; i < _GameChars.Length; ++i)
                    {
                        if (_GameChars[i].Character.activeSelf)
                        {
                            _GameChars[i].Character.transform.position = CharacterAnchorPoint.transform.position;
                            if (_GameChars[i].CostumeMenu != null)
                            {
                                _GameChars[i].CostumeMenu.SetActive(true);
                            }
                        }
                    }

                }
                HasLoadedDefaultScene = true;
            }
        }
        //
        if (HasLoadedDefaultScene)
        {
            if (Input.GetKeyDown(CustomeMenuKey))
            {
                ToggleCanvas = !ToggleCanvas;
            }
            if (_GameChars.Length > 0)
            {
                for (int i = 0; i < _GameChars.Length; ++i)
                {
                    if (_GameChars[i].Character.activeSelf)
                    {
                        if (_GameChars[i].CostumeMenu != null)
                        {
                            _GameChars[i].CostumeMenu.SetActive(ToggleCanvas);
                        }
                    }
                }

            }
        }
    }
    //
    void OnDisable()
    {
        if (AutoSaveOnDisable)
        {
            CallSave();
        }
    }
    //
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (UseSmartLoaderOnStart)
        {
            LoadData();
        }
    }
}
