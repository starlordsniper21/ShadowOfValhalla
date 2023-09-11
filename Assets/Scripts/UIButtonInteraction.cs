using UnityEngine;

public class UIButtonInteraction : MonoBehaviour
{
    public Dialogue dialogueManager; // Reference to the Dialogue script.

    public void OnUIButtonClick()
    {
        dialogueManager.ToggleDialogue();
    }
}
