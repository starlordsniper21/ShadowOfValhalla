using UnityEngine;
using UnityEngine.UI;

public class IncreaseHealthButton : MonoBehaviour
{
    public Button increaseHealthButton;

    private Health healthSystem;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            healthSystem = player.GetComponent<Health>();

            increaseHealthButton.onClick.AddListener(OnIncreaseHealthButtonClicked);
        }
        else
        {
            Debug.LogError("Player object not found or does not have a Health script.");
        }
    }

    private void OnIncreaseHealthButtonClicked()
    {
        if (healthSystem != null)
        {
            healthSystem.RestoreHealth(20.0f); // Adjust the amount as needed
        }
    }
}