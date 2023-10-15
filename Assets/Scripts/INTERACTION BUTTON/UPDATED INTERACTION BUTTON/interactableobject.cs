using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public void Interact()
    {
      
        Debug.Log("Interacting with " + gameObject.name);
    }
}
