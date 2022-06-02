using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ul_SpawnIdentity : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public Ul_InGameCharacterLoader gameCharacterLoader;
    // Update is called once per frame
    void Update()
    {
        if (gameCharacterLoader == null)
        {
            gameCharacterLoader = GameObject.FindObjectOfType<Ul_InGameCharacterLoader>();
            gameCharacterLoader.CharacterAnchorPoint = this.gameObject;
        }
    }
}
