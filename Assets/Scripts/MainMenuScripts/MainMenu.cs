using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TimeManager timeManager;



    // boss pag hinahanap mo yung onlick logic dati sa newgame nilipat ko sa " continuegame na script"

    public void PlayIntroductionCutscene()
    {
        SceneManager.LoadSceneAsync("Introduction");
    }

    public void TutorialLevel()
    {
        SceneManager.LoadSceneAsync("TUTORIAL LEVEL");
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

    public void PlayChapter2()
    {
        SceneManager.LoadSceneAsync("CHAPTER 2");
    }

    public void PlayChapter3()
    {
        SceneManager.LoadSceneAsync("CHAPTER 3");
    }

    public void PlayChapter4()
    {
        SceneManager.LoadSceneAsync("CHAPTER 4");
    }

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
