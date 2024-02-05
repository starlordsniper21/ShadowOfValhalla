using UnityEngine;
using UnityEngine.UI;

public class ArmorBar : MonoBehaviour
{
    [SerializeField] private Armor playerArmor;
    [SerializeField] private Image totalArmorBar;
    [SerializeField] private Image currentArmorBar;

    private void Start()
    {
        if (playerArmor != null)
        {
            playerArmor.OnArmorChanged += UpdateArmorBar; // Subscribe to the OnArmorChanged event
            UpdateArmorBar(playerArmor.currentArmor > 0); // Call UpdateArmorBar initially
        }
        else
        {
            Debug.LogError("Player Armor component is not assigned to ArmorBar.");
        }
    }

    private void OnDestroy()
    {
        if (playerArmor != null)
            playerArmor.OnArmorChanged -= UpdateArmorBar; // Unsubscribe from the OnArmorChanged event
    }

    private void UpdateArmorBar(bool hasArmor)
    {
        if (hasArmor)
        {
            // Enable the UI elements when armor is present
            totalArmorBar.gameObject.SetActive(true);
            currentArmorBar.gameObject.SetActive(true);

            // Update fill amounts of the UI elements
            float maxArmor = playerArmor.maxArmor;
            float currentArmor = playerArmor.currentArmor;
            totalArmorBar.fillAmount = currentArmor / maxArmor;
            currentArmorBar.fillAmount = currentArmor / maxArmor;
        }
        else
        {
            // Disable the UI elements when armor is destroyed
            totalArmorBar.gameObject.SetActive(false);
            currentArmorBar.gameObject.SetActive(false);
        }
    }
}
