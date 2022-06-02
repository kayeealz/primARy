using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDelay1 : MonoBehaviour
{
    public AudioSource myAudio;
    // Use this for initialization
    void Start()
    {

        StartCoroutine(PlaySoundAfterDelay(myAudio, 1f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PlaySoundAfterDelay(AudioSource audioSource, float delay)
    {
        if (audioSource == null)
        {
            Debug.Log("Null");
            yield break;
        }
        else
        {
            Debug.Log("Not Null");
            yield return new WaitForSeconds(delay);
            audioSource.Play();
        }

    }
}
