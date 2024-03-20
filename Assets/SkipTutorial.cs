using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipTutorial : MonoBehaviour
{
    public void TutorialLevel()
    {
        SceneManager.LoadSceneAsync("Tutorial Cutscene");
    }

    public void SkipTutorialScence()
    {
        SceneManager.LoadSceneAsync("Introduction");
    }
}
