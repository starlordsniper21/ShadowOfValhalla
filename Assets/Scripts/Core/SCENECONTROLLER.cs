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
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(nextSceneIndex);
            PlayerPrefs.SetInt("LastSceneIndex", nextSceneIndex); // Save scene index instead of name
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
        if (PlayerPrefs.HasKey("LastSceneIndex")) // Check if scene index is saved
        {
            int lastSceneIndex = PlayerPrefs.GetInt("LastSceneIndex");
            SceneManager.LoadScene(lastSceneIndex); // Load scene by index
        }
        else
        {
            Debug.LogWarning("No last scene found.");
        }
    }
}
