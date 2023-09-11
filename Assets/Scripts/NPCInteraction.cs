using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public Dialogue dialogueManager; // Reference to the Dialogue script.

    private bool playerIsClose = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            dialogueManager.playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            dialogueManager.playerIsClose = false;
        }
    }
}
