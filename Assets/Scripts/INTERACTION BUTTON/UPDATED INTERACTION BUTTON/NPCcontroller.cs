using System;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Dialogue dialogueScript; // Reference to the Dialogue script on the same NPC GameObject.

    private bool canInteract = false;

    internal void Interact()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            // Check if the Dialogue script is attached and active
            if (dialogueScript != null && !dialogueScript.IsDialogueActive())
            {
                dialogueScript.StartDialogue();
            }
        }
    }
}
