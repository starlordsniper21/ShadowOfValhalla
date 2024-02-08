using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public int currentHealth;
    public int currentMana;
    public int currentArrows;
    public string[] inventoryItems;

    private bool isGameQuitting = false;

    private void Start()
    {
        LoadGameState();
    }

    private void OnApplicationQuit()
    {
        isGameQuitting = true;
        SaveGameState();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus && !isGameQuitting)
        {
            SaveGameState();
        }
    }


    public void SaveGameState()
    {
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.SetInt("Mana", currentMana);
        PlayerPrefs.SetInt("Arrows", currentArrows);

        // Save inventory items
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            PlayerPrefs.SetString("Item" + i.ToString(), inventoryItems[i]);
        }

        PlayerPrefs.Save();
    }


    public void LoadGameState()
    {
        currentHealth = PlayerPrefs.GetInt("Health", 100);
        currentMana = PlayerPrefs.GetInt("Mana", 50);
        currentArrows = PlayerPrefs.GetInt("Arrows", 20);

        // Load inventory items
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            inventoryItems[i] = PlayerPrefs.GetString("Item" + i.ToString(), "Empty");
        }
    }
}
