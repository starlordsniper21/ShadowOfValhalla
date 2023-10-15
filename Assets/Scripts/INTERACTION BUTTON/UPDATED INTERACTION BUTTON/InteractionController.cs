using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    public float interactionDistance = 2f;
    public Button interactionButton; 
    public Dialogue dialogueScript;

    private void Start()
    {
       
        if (interactionButton != null)
        {
            interactionButton.onClick.AddListener(Interact);
        }
    }

    public void Interact()
    {
       
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

       
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
                
                if (dialogueScript != null && !dialogueScript.IsDialogueActive())
                {
                    // Start the dialogue
                    dialogueScript.StartDialogue();
                }
            }
        }
    }
}
