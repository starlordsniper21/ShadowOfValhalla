using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManaPotionManager : MonoBehaviour
{

    // MANAPOTIONS SAVING LOGIC NATIN BOSS
    public TextMeshProUGUI manaPotionCountText;
    public Button manaPotionButton;
    public int initialManaPotionCount = 0;

    public int manaPotionCount;

    private ManaSystem manaSystem;  

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

       
        if (player != null)
        {
            manaSystem = player.GetComponent<ManaSystem>();
        }
        else
        {
            Debug.LogError("Player object not found or does not have a ManaSystem script.");
        }

      
        if (FindObjectOfType<TimeManager>() != null && FindObjectOfType<SceneController>() != null)
        {
          
            if (PlayerPrefs.HasKey("RemainingManaPotionCount"))
            {
                manaPotionCount = PlayerPrefs.GetInt("RemainingManaPotionCount");
                UpdateManaPotionUI();
            }
            else
            {
                manaPotionCount = initialManaPotionCount;
                UpdateManaPotionUI();
            }
        }
        else
        {
            manaPotionCount = initialManaPotionCount;
            UpdateManaPotionUI();
        }
    }

    public void CollectManaPotion(int amount)
    {
        
        manaPotionCount++;
        UpdateManaPotionUI();
    }

    public void UseManaPotion()
    {
        
        if (manaPotionCount > 0 && manaSystem != null)
        {
            manaPotionCount--;
            manaSystem.RestoreMana(5); 
            UpdateManaPotionUI();
        }
    }


    public void UpdateManaPotionUI()
    {
        manaPotionCountText.text = "" + manaPotionCount;
        manaPotionButton.gameObject.SetActive(manaPotionCount > 0);
    }


    public void SaveRemainingManaPotionCount()
    {
        PlayerPrefs.SetInt("RemainingManaPotionCount", manaPotionCount);
    }

  
    public void LoadRemainingManaPotionCount()
    {
        if (PlayerPrefs.HasKey("RemainingManaPotionCount"))
        {
            manaPotionCount = PlayerPrefs.GetInt("RemainingManaPotionCount");
            UpdateManaPotionUI();
        }
    }
}
