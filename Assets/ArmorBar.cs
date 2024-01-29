using UnityEngine;
using UnityEngine.UI;

public class ArmorBar : MonoBehaviour
{
    [SerializeField] private Armor playerArmor;
    [SerializeField] private Image totalArmorBar;
    [SerializeField] private Image currentArmorBar;

    private void Start()
    {
        UpdateArmorBar();
    }

    private void Update()
    {
        UpdateArmorBar();
    }

    private void UpdateArmorBar()
    {
        float maxArmor = playerArmor.maxArmor;
        float currentArmor = playerArmor.currentArmor;

        if (maxArmor > 0)
        {
            totalArmorBar.fillAmount = currentArmor / maxArmor;
            currentArmorBar.fillAmount = currentArmor / maxArmor;

            if (currentArmor <= 0)
            {
                totalArmorBar.gameObject.SetActive(false);
                currentArmorBar.gameObject.SetActive(false);
            }
            else
            {
                totalArmorBar.gameObject.SetActive(true);
                currentArmorBar.gameObject.SetActive(true);
            }
        }
        else
        {
            totalArmorBar.fillAmount = 0f;
            currentArmorBar.fillAmount = 0f;
            totalArmorBar.gameObject.SetActive(true);
            currentArmorBar.gameObject.SetActive(true);
        }
    }
}
