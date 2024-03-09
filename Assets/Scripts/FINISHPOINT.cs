using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // medyyo pinalitan ko dito yung logic na nagawa mo boss para tumugma siya doon sa chapter select natin
            // explain ko sayo kung bakit ko pinalitan pag G ka.
            SceneController sceneController = FindObjectOfType<SceneController>();
            TimeManager timeManager = FindObjectOfType<TimeManager>();

            if (sceneController != null && timeManager != null)
            {
              
                sceneController.NextLevel();
            }
            else
            {
            
                SceneManager.LoadScene("Main Menu");
            }
        }
    }

    void UnlockNewLevel()
    {
       
    }
}
