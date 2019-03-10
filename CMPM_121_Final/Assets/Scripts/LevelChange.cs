using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Code inspired by: https://www.youtube.com/watch?v=Oadq-IrOazg
//Code also inspired by: https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-buildIndex.html

public class LevelChange : MonoBehaviour
{
    public Animator animator;

    public GameObject player;

    private int levelToLoad;

    Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        print("Scene name:" + scene.name + " build Index:" + scene.buildIndex); //Debug
    }

    // Update is called once per frame

    void Update()
    {
        if (scene.buildIndex <= 0)
        {
            if (player.GetComponent<StickyBall>().size >= 1.5f) //access player mass
            {
                FadeToNextLevel();
            }
        }
        if (scene.buildIndex >= 1)
        {
            if (player.GetComponent<StickyBall>().size >= 4.0f) //access player mass
            {
                FadeToNextLevel();
            }
        }

    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
