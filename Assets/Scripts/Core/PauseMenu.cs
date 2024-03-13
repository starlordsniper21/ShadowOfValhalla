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
        TimeManager timeManager = FindObjectOfType<TimeManager>();
        SceneController sceneController = FindObjectOfType<SceneController>();

        // Check if both TimeManager and SceneController are present if wala wont save
        if (timeManager != null && sceneController != null)
        {
            // Save the timer value and last played scene if wala wont save
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            float timerValue = timer.GetTime();

            PlayerPrefs.SetInt("LastSceneIndex", currentSceneIndex);
            PlayerPrefs.SetFloat("TimerValue", timerValue);
        }

        // Load the Main Menu scene
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
