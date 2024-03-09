using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timePaused : MonoBehaviour
{
  
    public TimerUI timerUI;


    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "LeaderBoardPanel")
        {
            Time.timeScale = 0f;
        }
    }
    public void resetTimer()
    {
       
        PlayerPrefs.DeleteAll();

       
        SceneManager.LoadScene("Main Menu");

      
        Time.timeScale = 1;

      
        TimeManager timeManager = FindObjectOfType<TimeManager>();
        if (timeManager != null)
        {
            timeManager.ResetTimer();
        }
        else
        {
            Debug.LogWarning("TimeManager not found!");
        }
    }
}
