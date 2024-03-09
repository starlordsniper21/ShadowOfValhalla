using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private Timer timer;
    private float startTimeValue; 

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
        if (timer == null)
        {
            Debug.LogWarning("Timer not found!");
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;


        if (timer != null)
        {
            timer.PauseTimer();
        }
    }

    public void Home()
    {
        
        SceneController sceneController = FindObjectOfType<SceneController>();
        TimeManager timeManager = FindObjectOfType<TimeManager>();

        if (sceneController != null && timeManager != null)
        {
            
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("LastSceneIndex", currentSceneIndex);
            PlayerPrefs.SetFloat("StartTimeValue", startTimeValue);
        }

       
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

       
        if (timer != null)
        {
            timer.StartTimer();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void SetStartTimeValue(float value)
    {
        startTimeValue = value;
    }
}
