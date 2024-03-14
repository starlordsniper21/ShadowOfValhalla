using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthPotionManager : MonoBehaviour
{
    public TextMeshProUGUI healthPotionCountText;
    public Button healthPotionButton;
    public int initialHealthPotionCount = 0;

    [SerializeField] private float healthRestoreAmount = 20.0f;

    public int healthPotionCount; 

    public Health healthSystem;

    private void Start()
    {
        // HEALTHPOTIONS SAVING LOGIC NATIN BOSS
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            healthSystem = player.GetComponent<Health>();
        }
        else
        {
            Debug.LogError("Player object not found or does not have a Health script.");
        }

        
        if (FindObjectOfType<TimeManager>() != null && FindObjectOfType<SceneController>() != null)
        {
            
            if (PlayerPrefs.HasKey("RemainingHealthPotionCount"))
            {
                healthPotionCount = PlayerPrefs.GetInt("RemainingHealthPotionCount");
                UpdateHealthPotionUI();
            }
            else
            {
                healthPotionCount = initialHealthPotionCount;
                UpdateHealthPotionUI();
            }
        }
        else
        {
            
            healthPotionCount = initialHealthPotionCount;
            UpdateHealthPotionUI();
        }
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

    public void UpdateHealthPotionUI() 
    {
        healthPotionCountText.text = "" + healthPotionCount;
        healthPotionButton.gameObject.SetActive(healthPotionCount > 0);
    }

    public void SaveRemainingHealthPotionCount()
    {
        PlayerPrefs.SetInt("RemainingHealthPotionCount", healthPotionCount);
    }

  
    public void LoadRemainingHealthPotionCount()
    {
        if (PlayerPrefs.HasKey("RemainingHealthPotionCount"))
        {
            healthPotionCount = PlayerPrefs.GetInt("RemainingHealthPotionCount");
            UpdateHealthPotionUI();
        }
    }
}
