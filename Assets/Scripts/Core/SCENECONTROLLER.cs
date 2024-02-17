using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    public Timer timer; // Reference to the Timer script

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
            Destroy(gameObject);
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name == "LeaderBoardPanel")
        {
            if (SceneController.instance.timer != null)
            {
                Time.timeScale = 0;
                SceneController.instance.timer.StopTimer();
                Debug.Log("Timer paused");
            }
        }
    }

    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);

        if (sceneName == "LeaderBoardPanel" && timer != null)
        {
            timer.StopTimer();
            Debug.Log("Timer paused");
        }
    }

}
