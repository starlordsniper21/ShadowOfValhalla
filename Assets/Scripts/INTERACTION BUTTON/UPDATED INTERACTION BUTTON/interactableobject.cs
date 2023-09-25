using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public void Interact()
    {
        // Define the interaction behavior for this object
        // For example, you can display a message or perform an action.
        Debug.Log("Interacting with " + gameObject.name);
    }
}
