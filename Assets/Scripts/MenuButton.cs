using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class MenuButton : MonoBehaviour
{
    public void Main()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Easy()
    {
        SceneManager.LoadScene("SelectLevelEZ");
    }

    public void Medium()
    {
        SceneManager.LoadScene("SelectLevelMed");
    }

    public void Hard()
    {
        SceneManager.LoadScene("SelectLevelHard");
    }

    public void ARsceneadd()
    {
        LoaderUtility.Initialize();
        SceneManager.LoadScene("ARscene2", LoadSceneMode.Single);
    }

    public void Play1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Play2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Play3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

     public void Play4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void Play5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void Play6()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Back2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    } 

    public void Back3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void Back4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    public void Back5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }

    public void Back6()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
    }

    public void Back7()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 10);
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
