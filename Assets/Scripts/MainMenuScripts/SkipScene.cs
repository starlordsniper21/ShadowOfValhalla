using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipScene : MonoBehaviour
{
    public void SkipButton()
    {
        SceneManager.LoadSceneAsync("CHAPTER 1 CUTSCENE");
    }

    public void SkipButton2()
    {
        SceneManager.LoadSceneAsync("CHAPTER 4 CUTSCENE");
    }

}
