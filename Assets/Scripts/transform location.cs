using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportController : MonoBehaviour
{
    public Transform destination;
    public Canvas blackScreenCanvas; 
    public float pauseTime = 5.0f; 

    private bool isTeleporting = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTeleporting)
        {
            isTeleporting = true;

            // Activate the black screen panel.
            blackScreenCanvas.gameObject.SetActive(true);

            // Pause the game by setting the time scale to 0.
            Time.timeScale = 0;

            // Start a coroutine to resume the game and teleport the player.
            StartCoroutine(ResumeAndTeleport(other.transform));
        }
    }

    private IEnumerator ResumeAndTeleport(Transform playerTransform)
    {
        
        yield return new WaitForSecondsRealtime(pauseTime);

        // Deactivate the black screen panel.
        blackScreenCanvas.gameObject.SetActive(false);

        // Resume the game by setting the time scale back to 1.
        Time.timeScale = 1;

        // Teleport the player to the destination.
        playerTransform.position = destination.position;

        // Reset the teleporting flag.
        isTeleporting = false;
    }
}
