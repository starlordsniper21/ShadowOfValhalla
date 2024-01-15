using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    public int maxMana = 10;
    public int currentMana;

    void Start()
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
            // Code to spawn a fireball or perform the spell
        }
    }

    public void RestoreMana(int amount)
    {
        currentMana = Mathf.Min(currentMana + amount, maxMana);
    }
}
