using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play() //play button functionality
    {
        SceneManager.LoadScene(0);
    }

    public void Quit() //quit button functionality
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
