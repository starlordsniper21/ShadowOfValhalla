using System;
using UnityEngine;
using System.Collections;

public class Armor : MonoBehaviour
{
    [SerializeField] private float startingArmor;
    public float currentArmor { get; private set; }
    public float maxArmor { get { return startingArmor; } }
    private bool broken;
    private bool invulnerable = false;
    public float invulnerabilityDuration = 2f;
    private float invulnerabilityEndTime;
    public event Action<bool> OnArmorChanged;

    private void Awake()
    {
        currentArmor = startingArmor;
    }

    public void TakeDamage(float _damage)
    {
        if (!broken && !invulnerable)
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

            StartCoroutine(StartInvulnerabilityCooldown());
        }
    }

    IEnumerator StartInvulnerabilityCooldown()
    {
        invulnerable = true;
        invulnerabilityEndTime = Time.time + invulnerabilityDuration;
        yield return new WaitForSeconds(invulnerabilityDuration);
        invulnerable = false;
    }

    public void RestoreArmor(float _value)
    {
        if (broken || currentArmor < startingArmor)
        {
            currentArmor = Mathf.Clamp(currentArmor + _value, 0, startingArmor);
            if (currentArmor == startingArmor)
            {
                broken = false;
                EnableArmorBars();
                Debug.Log("Armor Repaired!");
                ArmorBarManager.instance.EnableAllArmorBars();
            }

            if (OnArmorChanged != null)
                OnArmorChanged(currentArmor > 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ArmorCollectible"))
        {
            RestoreArmor(startingArmor);
            EnableArmorBars();
            Destroy(other.gameObject);
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
