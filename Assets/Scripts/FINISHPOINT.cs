using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnlockNewLevel();
            SceneController.instance.NextLevel();

            if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name == "LeaderBoardPanel")
            {
                if (SceneController.instance.timer != null)
                {
                    SceneController.instance.timer.StopTimer();
                    Debug.Log("Timer paused");
                }
            }
        }
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }


}