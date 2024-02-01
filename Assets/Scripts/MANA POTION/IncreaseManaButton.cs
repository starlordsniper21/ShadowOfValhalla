using UnityEngine;
using UnityEngine.UI;

public class IncreaseManaButton : MonoBehaviour
{
    // Reference to the button in your UI
    public Button increaseManaButton;

    // Reference to the ManaSystem script on the player
    private ManaSystem manaSystem;

    private void Start()
    {
        // Find the player object using a suitable method (e.g., by tag)
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Check if the player object has a ManaSystem script
        if (player != null)
        {
            manaSystem = player.GetComponent<ManaSystem>();

            // Attach the method to the button click event
            increaseManaButton.onClick.AddListener(OnIncreaseManaButtonClicked);
        }
        else
        {
            Debug.LogError("Player object not found or does not have a ManaSystem script.");
        }
    }

    // Method to be called when the increase mana button is clicked
    private void OnIncreaseManaButtonClicked()
    {
        if (manaSystem != null)
        {
            // Increase mana by a certain amount
            int manaIncreaseAmount = 5; // You can adjust this value
            manaSystem.RestoreMana(manaIncreaseAmount);
        }
    }
}
