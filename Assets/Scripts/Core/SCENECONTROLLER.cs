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
            Health playerHealth = FindObjectOfType<Health>();
            ManaSystem playerMana = FindObjectOfType<ManaSystem>();
            Armor playerArmor = FindObjectOfType<Armor>();
            PlayerBow playerBow = FindObjectOfType<PlayerBow>(); 

            if (sceneController != null && timeManager != null && playerHealth != null)
            {
                if (PlayerPrefs.HasKey("PlayerHealth"))
                {
                    float savedHealth = PlayerPrefs.GetFloat("PlayerHealth");
                    playerHealth.currentHealth = savedHealth;
                }
            }
            else
            {
                if (playerHealth != null)
                {
                    playerHealth.currentHealth = playerHealth.startingHealth;
                }
            }

            if (sceneController != null && timeManager != null && playerMana != null)
            {
                if (PlayerPrefs.HasKey("PlayerMana"))
                {
                    int savedMana = PlayerPrefs.GetInt("PlayerMana");
                    playerMana.currentMana = savedMana;
                }
            }
            else
            {
                if (playerMana != null)
                {
                    playerMana.currentMana = playerMana.startingMana;
                }
            }

            if (sceneController != null && timeManager != null && playerArmor != null)
            {
                if (PlayerPrefs.HasKey("PlayerArmor"))
                {
                    float savedArmor = PlayerPrefs.GetFloat("PlayerArmor");
                    playerArmor.currentArmor = savedArmor;
                }
            }
            else
            {
                if (playerArmor != null)
                {
                    playerArmor.currentArmor = playerArmor.startingArmor;
                }
            }

            if (sceneController != null && timeManager != null && playerBow != null) // Check for PlayerBow
            {
                if (PlayerPrefs.HasKey("RemainingArrows")) // Load remaining arrows if available
                {
                    int savedArrows = PlayerPrefs.GetInt("RemainingArrows");
                    playerBow.SetRemainingArrows(savedArrows);
                }
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

            // Only save data if both TimeManager and SceneController are present
            TimeManager timeManager = FindObjectOfType<TimeManager>();
            SceneController sceneController = FindObjectOfType<SceneController>();
            if (timeManager != null && sceneController != null)
            {
                // Store remaining arrows before transitioning to the next scene
                PlayerBow playerBow = FindObjectOfType<PlayerBow>();
                if (playerBow != null)
                {
                    PlayerPrefs.SetInt("RemainingArrows", playerBow.GetRemainingArrows());
                }

                // Store player health, mana, and armor before transitioning to the next scene
                PlayerPrefs.SetFloat("PlayerHealth", FindObjectOfType<Health>().currentHealth);
                PlayerPrefs.SetInt("PlayerMana", FindObjectOfType<ManaSystem>().currentMana);
                PlayerPrefs.SetFloat("PlayerArmor", FindObjectOfType<Armor>().currentArmor);
            }
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
