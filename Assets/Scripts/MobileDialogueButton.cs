using UnityEngine;

public class MobileDialogueButton : MonoBehaviour
{
    public Dialogue dialogueManager; // Reference to your Dialogue script.

    public void OnMobileButtonClick()
    {
        // Call the dialogueManager's method to start or continue the dialogue.
        dialogueManager.ToggleDialogue();
    }
}
