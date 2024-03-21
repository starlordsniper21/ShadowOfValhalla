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
            HealthPotionManager healthPotionManager = FindObjectOfType<HealthPotionManager>();
            ManaPotionManager manaPotionManager = FindObjectOfType<ManaPotionManager>(); 

         
            if (timeManager == null && sceneController == null && healthPotionManager != null)
            {
                
                healthPotionManager.healthPotionCount = 0;
                healthPotionManager.UpdateHealthPotionUI();
            }

            if (timeManager == null && sceneController == null && manaPotionManager != null) 
            {
                
                manaPotionManager.manaPotionCount = 0;
                manaPotionManager.UpdateManaPotionUI();
            }

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

            if (sceneController != null && timeManager != null && playerBow != null) 
            {
                if (PlayerPrefs.HasKey("RemainingArrows")) 
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

           
            TimeManager timeManager = FindObjectOfType<TimeManager>();
            SceneController sceneController = FindObjectOfType<SceneController>();
            if (timeManager != null && sceneController != null)
            {
                
                PlayerBow playerBow = FindObjectOfType<PlayerBow>();
                if (playerBow != null)
                {
                    PlayerPrefs.SetInt("RemainingArrows", playerBow.GetRemainingArrows());
                }

                PlayerPrefs.SetFloat("PlayerHealth", FindObjectOfType<Health>().currentHealth);
                PlayerPrefs.SetInt("PlayerMana", FindObjectOfType<ManaSystem>().currentMana);
                PlayerPrefs.SetFloat("PlayerArmor", FindObjectOfType<Armor>().currentArmor);
 
                HealthPotionManager healthPotionManager = FindObjectOfType<HealthPotionManager>();
                if (healthPotionManager != null)
                {
                    healthPotionManager.SaveRemainingHealthPotionCount();
                }
                ManaPotionManager manaPotionManager = FindObjectOfType<ManaPotionManager>();
                if (manaPotionManager != null)
                {
                    manaPotionManager.SaveRemainingManaPotionCount();
                }
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

    private void OnApplicationQuit()
    {
        // Check if both SceneController and TimeManager are present
        SceneController sceneController = FindObjectOfType<SceneController>();
        TimeManager timeManager = FindObjectOfType<TimeManager>();

        // Check if the current scene is not the Main Menu scene
        if (sceneController != null && timeManager != null && SceneManager.GetActiveScene().name != "Main Menu")
        {
            // Save the current scene index and timer value when the application quits
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            float timerValue = timeManager.timer.GetTime();

            PlayerPrefs.SetInt("LastSceneIndex", currentSceneIndex);
            PlayerPrefs.SetFloat("TimerValue", timerValue);

            PlayerPrefs.Save(); // Make sure to save PlayerPrefs data
        }
    }
}
// BOSS HELP ME IM DYING AGAIN HAHAHAHA


