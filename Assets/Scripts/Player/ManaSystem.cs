using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    public int maxMana = 20;
    public int currentMana;

    void Start()
    {
        
    }

    public void SetDefaultMana()
    {
        currentMana = maxMana; 
    }

    public bool CanCastSpell()
    {
        return currentMana > 0;
    }

    public void UseMana()
    {
        if (CanCastSpell())
        {
            currentMana--;
        }
    }

    public void RestoreMana(int amount)
    {
        currentMana = Mathf.Min(currentMana + amount, maxMana);
    }

    
    public void SaveMana()
    {
        PlayerPrefs.SetInt("PlayerMana", currentMana);
    }
}
