using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    public int maxMana = 20;
    public int startingMana = 20;
    public int currentMana;

    private void Awake()
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
            SaveMana();
        }
    }

    public void RestoreMana(int amount)
    {
        currentMana = Mathf.Min(currentMana + amount, maxMana);
        SaveMana();
    }

  

    public void SaveMana()
    {
        PlayerPrefs.SetInt("PlayerMana", currentMana);
    }
}
