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

    public void SkipButton3()
    {
        SceneManager.LoadSceneAsync("Chapter 6 Intro meething atros");
    }

    public void SkipButton4()
    {
        SceneManager.LoadSceneAsync("Chapter 6 Cutscene Kjelford");
    }

    public void SkipButton5()
    {
        SceneManager.LoadSceneAsync("chapter 7 Canute's Fortress");
    }

    public void SkipButton6()
    {
        SceneManager.LoadSceneAsync("LeaderBoardPanel");
    }

    public void SkipButtonspare1()
    {
        SceneManager.LoadSceneAsync("SPARE CANUTE SCENE 3");
    }

    public void SkipButtonspare2()
    {
        SceneManager.LoadSceneAsync("LeaderBoardPanel");
    }

}
