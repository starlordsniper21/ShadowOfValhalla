using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToLevel2 : MonoBehaviour
{
    public float changeTime;
    public string sceneName;

    private bool countdownStarted = false;

    private void Update()
    {
        if (countdownStarted)
        {
            changeTime -= Time.deltaTime;
            if (changeTime <= 0)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !countdownStarted)
        {
            countdownStarted = true;
        }
    }
}
