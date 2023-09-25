using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    public float interactionDistance = 2f;
    public Button interactionButton; // Reference to the UI Button
    public Dialogue dialogueScript; // Reference to the Dialogue script on the NPC GameObject.

    private void Start()
    {
        // Register a callback for the button click event
        if (interactionButton != null)
        {
            interactionButton.onClick.AddListener(Interact);
        }
    }

    public void Interact()
    {
        // Create a ray from the camera to the front of the player
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        // Check if the ray hits an interactable object
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("InteractableObject"))
            {
                InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
                if (interactableObject != null)
                {
                    interactableObject.Interact();
                }
                else
                {
                    Debug.LogWarning("InteractableObject script missing on the interactable object.");
                }
            }
            else if (hit.collider.CompareTag("NPC"))
            {
                // Check if the Dialogue script on the NPC is not active
                if (dialogueScript != null && !dialogueScript.IsDialogueActive())
                {
                    // Start the dialogue
                    dialogueScript.StartDialogue();
                }
            }
        }
    }
}
