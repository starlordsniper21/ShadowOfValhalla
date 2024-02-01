using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManaPotionManager : MonoBehaviour
{
    public TextMeshProUGUI manaPotionCountText;
    public Button manaPotionButton;
    public int initialManaPotionCount = 0;

    private int manaPotionCount;
    private ManaSystem manaSystem;  // Reference to the ManaSystem script on the player

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Check if the player object has a ManaSystem script
        if (player != null)
        {
            manaSystem = player.GetComponent<ManaSystem>();
        }
        else
        {
            Debug.LogError("Player object not found or does not have a ManaSystem script.");
        }

        manaPotionCount = initialManaPotionCount;
        UpdateManaPotionUI();
    }

    public void CollectManaPotion(int amount)
    {
        // Called when you collect a mana potion
        manaPotionCount++;
        UpdateManaPotionUI();
    }

    public void UseManaPotion()
    {
        // Called when you use a mana potion
        if (manaPotionCount > 0 && manaSystem != null)
        {
            manaPotionCount--;
            manaSystem.RestoreMana(5); // You can adjust the amount here
            UpdateManaPotionUI();
        }
    }

    private void UpdateManaPotionUI()
    {
       
        manaPotionCountText.text = "" + manaPotionCount;

    
        manaPotionButton.gameObject.SetActive(manaPotionCount > 0);
    }
}
