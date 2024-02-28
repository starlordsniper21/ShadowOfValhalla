using UnityEngine;
using UnityEngine.UI;

public class TriggerScript : MonoBehaviour
{
    public GameObject panel;
    public GameObject[] otherUIs; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Time.timeScale = 0f; 
            panel.SetActive(true); 

           
            foreach (GameObject ui in otherUIs)
            {
                ui.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Time.timeScale = 1f; 
            panel.SetActive(false); 

            foreach (GameObject ui in otherUIs)
            {
                ui.SetActive(true);
            }
        }
    }
}
