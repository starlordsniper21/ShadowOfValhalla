using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerBasedManagement : MonoBehaviour
{
    public float totalTime = 60f;
    private float currentTime = 0f;
    private bool isTimerRunning = false;
    private bool isGameActive = true;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning && isGameActive)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                StopTimer();
                Debug.Log("Time's up!");
                // Update LeaderBoard Api
                UpdatePlayerData();
            }
        }
    }

    public void StartTimer()
    {
        currentTime = totalTime;
        isTimerRunning = true;
        isGameActive = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void PlayerDied()
    {
        if (isTimerRunning)
        {
            currentTime = totalTime;
        }
    }

    public void QuitGame()
    {
        if (isTimerRunning)
        {
            StopTimer();
            isGameActive = false;
        }
    }

    private void UpdatePlayerData()
    {
        // LeaderBoard Api Call
    }
}
