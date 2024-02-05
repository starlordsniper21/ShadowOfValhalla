using System;
using UnityEngine;

public class Armor : MonoBehaviour
{
    [SerializeField] private float startingArmor;
    public float currentArmor { get; private set; }
    public float maxArmor { get { return startingArmor; } }
    private bool broken;
    public event Action<bool> OnArmorChanged;

    private void Awake()
    {
        currentArmor = startingArmor;
    }

    public void TakeDamage(float _damage)
    {
        if (!broken)
        {
            currentArmor = Mathf.Clamp(currentArmor - _damage, 0, startingArmor);

            if (currentArmor <= 0)
            {
                broken = true;
                Debug.Log("Armor Broken!");
                ArmorBarManager.instance.DisableAllArmorBars();
            }

            if (OnArmorChanged != null)
                OnArmorChanged(currentArmor > 0);

        }
    }

    public void RestoreArmor(float _value)
    {
        if (broken || currentArmor < startingArmor) // Allow restoration even if armor is broken or not full
        {
            currentArmor = Mathf.Clamp(currentArmor + _value, 0, startingArmor);
            if (currentArmor == startingArmor)
            {
                broken = false;
                Debug.Log("Armor Repaired!");
                EnableArmorBars();
                
            }

            // Trigger the event when the armor status changes
            if (OnArmorChanged != null)
                OnArmorChanged(currentArmor > 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ArmorCollectible"))
        {
            RestoreArmor(startingArmor); // Restore armor to full when picking up collectible
            Destroy(other.gameObject); // Destroy the collectible object
        }
    }

    private void EnableArmorBars()
    {
        ArmorBar[] armorBars = FindObjectsOfType<ArmorBar>();
        foreach (ArmorBar armorBar in armorBars)
        {
            armorBar.gameObject.SetActive(true);
        }
    }

}
