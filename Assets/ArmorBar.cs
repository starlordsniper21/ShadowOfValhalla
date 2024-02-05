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
            playerArmor.OnArmorChanged += UpdateArmorBar;
            UpdateArmorBar(playerArmor.currentArmor > 0);
        }
        else
        {
            Debug.LogError("Player Armor component is not assigned to ArmorBar.");
        }
    }

    private void OnDestroy()
    {
        if (playerArmor != null)
            playerArmor.OnArmorChanged -= UpdateArmorBar;
    }

    private void UpdateArmorBar(bool hasArmor)
    {
        if (hasArmor)
        {
            totalArmorBar.gameObject.SetActive(true);
            currentArmorBar.gameObject.SetActive(true);
            float maxArmor = playerArmor.maxArmor;
            float currentArmor = playerArmor.currentArmor;
            totalArmorBar.fillAmount = currentArmor / maxArmor;
            currentArmorBar.fillAmount = currentArmor / maxArmor;
        }
        else
        {
            totalArmorBar.gameObject.SetActive(false);
            currentArmorBar.gameObject.SetActive(false);
        }
    }
}
