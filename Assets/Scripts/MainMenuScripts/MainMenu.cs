using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This function will be called when the "Chapter 1" button is clicked.
    public TimeManager timeManager;


    public void PlayIntroductionCutscene()
    {
        SceneManager.LoadSceneAsync("Introduction");

    }

    public void TutorialLevel()
    {
        SceneManager.LoadSceneAsync("TUTORIAL LEVEL");
    }

    public void FirstCutscene()
    {
        // Find the TimeManager object in the scene
        TimeManager timeManager = FindObjectOfType<TimeManager>();

        // Check if the TimeManager is not null before starting the timer
        if (timeManager != null)
        {
            // Access the StartTimer method from the TimeManager
            timeManager.StartTimer();
            Debug.Log("Timer Activated");
        }
        else
        {
            Debug.LogWarning("TimeManager not found in the scene!");
        }

        // Load the FirstCutscene scene
        SceneManager.LoadSceneAsync("FirstCutscene");
    }




    public void PlayCutscene1()
    {
        SceneManager.LoadSceneAsync("CHAPTER 1 CUTSCENE");
    }

    public void PlayCutscene2()
    {
        SceneManager.LoadSceneAsync("CHAPTER 2 CUTSCENE");
    }

    public void PlayCutscene3()
    {
        SceneManager.LoadSceneAsync("CHAPTER 3 CUTSCENE");
    }

    public void PlayCutscene4()
    {
        SceneManager.LoadSceneAsync("CHAPTER 4 CUTSCENE");
    }

    public void PlayCutscene5()
    {
        SceneManager.LoadSceneAsync("CHAPTER 5 CUTSCENE");
    }

    public void PlayCutscene6()
    {
        SceneManager.LoadSceneAsync("CHAPTER 6 CUTSCENE");
    }

    public void PlayCutscene7()
    {
        SceneManager.LoadSceneAsync("CHAPTER 7 CUTSCENE");
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
    public void PlayChapter6()
    {
        SceneManager.LoadSceneAsync("CHAPTER 6");
    }

    public void PlayChapter7()
    {
        SceneManager.LoadSceneAsync("CHAPTER 7");
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
