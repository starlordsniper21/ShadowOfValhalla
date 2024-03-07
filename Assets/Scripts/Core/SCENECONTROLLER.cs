using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public Timer timer;
    private bool destroyOnLoad = true; // Flag to determine whether to destroy the instance on scene load

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (destroyOnLoad)
                DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Add a method to set destroyOnLoad flag
    public void SetDestroyOnLoad(bool destroy)
    {
        destroyOnLoad = destroy;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0)
        {
            if (timer != null)
            {
                timer.StartTimer();
            }
            else
            {
                Debug.LogWarning("Timer reference not set in SceneController.");
            }
        }
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(nextSceneIndex);
            PlayerPrefs.SetInt("LastSceneIndex", nextSceneIndex);
            PlayerPrefs.SetFloat("TimerValue", timer.GetTime());
        }
        else
        {
            Debug.LogWarning("No next level available.");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        PlayerPrefs.SetString("LastScene", sceneName);
    }

    public void LoadLastScene()
    {
        if (PlayerPrefs.HasKey("LastSceneIndex"))
        {
            int lastSceneIndex = PlayerPrefs.GetInt("LastSceneIndex");
            float timerValue = PlayerPrefs.GetFloat("TimerValue");
            SceneManager.LoadScene(lastSceneIndex);
            StartCoroutine(LoadTimer(timerValue));
        }
        else
        {
            Debug.LogWarning("No last scene found.");
        }
    }

    IEnumerator LoadTimer(float value)
    {
        yield return new WaitForEndOfFrame();
        timer.SetTime(value);
    }

    public void LoadFirstCutscene()
    {
        LoadScene("FirstCutscene");
    }
}
