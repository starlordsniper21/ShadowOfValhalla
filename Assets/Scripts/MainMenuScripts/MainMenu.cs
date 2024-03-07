using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    private bool destroyManagersOnLoad = true;


    // pag sakaling hinahanp mo yung script dito boss nilipat ko sa SCENECONTROLLER script
    public void PlayIntroductionCutscene()
    {
        
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("Introduction");
    }

    public void TutorialLevel()
    {
       
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("TUTORIAL LEVEL");
    }

    public void PlayCutscene1()
    {
       
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 1 CUTSCENE");
    }

    public void PlayCutscene2()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 2 CUTSCENE");
    }

    public void PlayCutscene3()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 3 CUTSCENE");
    }

    public void PlayCutscene4()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 4 CUTSCENE");
    }

    public void PlayCutscene5()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 5 CUTSCENE");
    }

    public void PlayCutscene6()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 6 CUTSCENE");
    }

    public void PlayCutscene7()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 7 CUTSCENE");
    }

    public void PlayChapter1()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 1");
    }

    public void PlayChapter2()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 2");
    }

    public void PlayChapter3()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 3");
    }

    public void PlayChapter4()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 4");
    }

    public void PlayChapter5()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 5");
    }

    public void PlayChapter6()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 6");
    }

    public void PlayChapter7()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("CHAPTER 7");
    }

    public void PlayTutorial()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("TUTORIAL LEVEL");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LeaderboardTest()
    {
        SetDestroyManagersOnLoad(true);
        SceneManager.LoadSceneAsync("LeaderBoardPanel");
    }


    private void SetDestroyManagersOnLoad(bool destroy)
    {
        SceneController sceneController = FindObjectOfType<SceneController>();
        TimeManager timeManager = FindObjectOfType<TimeManager>();

        if (sceneController != null)
        {
            sceneController.SetDestroyOnLoad(destroy);
            if (destroy)
                Destroy(sceneController.gameObject);
        }

        if (timeManager != null)
        {
            timeManager.SetDestroyOnLoad(destroy);
            if (destroy)
                Destroy(timeManager.gameObject);
        }
    }
}
