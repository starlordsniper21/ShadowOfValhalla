using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This function will be called when the "Chapter 1" button is clicked.
    public Timer timer;


    public void PlayIntroductionCutscene()
    {
        SceneManager.LoadSceneAsync("Introduction");

    }

    public void TutorialLevel()
    {
        SceneManager.LoadSceneAsync("TUTORIAL LEVEL");
    }

    public void FirstCutscence()
    {
        if (timer != null)
        {
            timer.StartTimer();
            Debug.Log("Timer Activated");
        }

        SceneManager.LoadSceneAsync("FirstCutscene");
    }




    public void PlayCutscene1()
    {
        SceneManager.LoadSceneAsync("CHATPER 1 CUTSCENE");
    }

    public void PlayCutscene2()
    {
        SceneManager.LoadSceneAsync("CHATPER 2 CUTSCENE");
    }

    public void PlayCutscene3()
    {
        SceneManager.LoadSceneAsync("CHATPER 3 CUTSCENE");
    }

    public void PlayCutscene4()
    {
        SceneManager.LoadSceneAsync("CHATPER 4 CUTSCENE");
    }

    public void PlayCutscene5()
    {
        SceneManager.LoadSceneAsync("CHATPER 5 CUTSCENE");
    }

    public void PlayCutscene6()
    {
        SceneManager.LoadSceneAsync("CHATPER 6 CUTSCENE");
    }

    public void PlayCutscene7()
    {
        SceneManager.LoadSceneAsync("CHATPER 7 CUTSCENE");
    }

    public void PlayChapter1()
    {
        SceneManager.LoadSceneAsync("CHAPTER 1");
    }

    // This function will be called when the "Chapter 2" button is clicked.
    public void PlayChapter2()
    {
        SceneManager.LoadSceneAsync("CHAPTER 2");
    }

    // This function will be called when the "Chapter 3" button is clicked.
    public void PlayChapter3()
    {
        SceneManager.LoadSceneAsync("CHAPTER 3");
    }

    // This function will be called when the "Chapter 4" button is clicked.
    public void PlayChapter4()
    {
        SceneManager.LoadSceneAsync("CHAPTER 4");
    }

    // This function will be called when the "Chapter 5" button is clicked.
    public void PlayChapter5()
    {
        SceneManager.LoadSceneAsync("CHAPTER 5");
    }

    public void PlayTutorial()
    {
        SceneManager.LoadSceneAsync("TUTORIAL LEVEL");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LeaderboardTest()
    {
        SceneManager.LoadSceneAsync("LeaderBoardPanel");
    }

}
