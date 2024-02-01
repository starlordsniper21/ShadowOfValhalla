using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthPotionManager : MonoBehaviour
{
    public TextMeshProUGUI healthPotionCountText;
    public Button healthPotionButton;
    public int initialHealthPotionCount = 0;

    [SerializeField] private float healthRestoreAmount = 20.0f; 

    private int healthPotionCount;
    private Health healthSystem;  

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            healthSystem = player.GetComponent<Health>();
        }
        else
        {
            Debug.LogError("Player object not found or does not have a Health script.");
        }

        healthPotionCount = initialHealthPotionCount;
        UpdateHealthPotionUI();
    }

    public void CollectHealthPotion()
    {
        healthPotionCount++;
        UpdateHealthPotionUI();
    }

    public void UseHealthPotion()
    {
        if (healthPotionCount > 0 && healthSystem != null)
        {
            healthPotionCount--;
            healthSystem.RestoreHealth(healthRestoreAmount); 
            UpdateHealthPotionUI();
        }
    }

    private void UpdateHealthPotionUI()
    {
        healthPotionCountText.text = "" + healthPotionCount;
        healthPotionButton.gameObject.SetActive(healthPotionCount > 0);
    }
}
