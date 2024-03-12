using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public Timer timer;
    private bool destroyOnLoad = true;

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

    public void SetDestroyOnLoad(bool destroy)
    {
        destroyOnLoad = destroy;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0)
        {
            SceneController sceneController = FindObjectOfType<SceneController>();
            TimeManager timeManager = FindObjectOfType<TimeManager>();

            if (sceneController != null && timeManager != null)
            {

                if (PlayerPrefs.HasKey("PlayerHealth"))
                {
                    float playerHealth = PlayerPrefs.GetFloat("PlayerHealth");
                    FindObjectOfType<Health>().currentHealth = playerHealth;
                }
            }
            else
            {

                FindObjectOfType<Health>().currentHealth = FindObjectOfType<Health>().startingHealth;
            }

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
            PlayerPrefs.SetFloat("PlayerHealth", FindObjectOfType<Health>().currentHealth);
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

    public void LoadLastSceneWithTimer()
    {
        if (PlayerPrefs.HasKey("LastSceneIndex"))
        {
            int lastSceneIndex = PlayerPrefs.GetInt("LastSceneIndex");
            float timerValue = PlayerPrefs.GetFloat("TimerValue", 0);

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

//bosssss im dyingg !!! hahahahaha