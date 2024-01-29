using UnityEngine;

public class Armor : MonoBehaviour
{
    [SerializeField] private float startingArmor;
    public float currentArmor { get; private set; }
    public float maxArmor { get { return startingArmor; } }
    private bool broken;

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
        }
    }

    public void RepairArmor(float _value)
    {
        if (broken)
        {
            currentArmor = Mathf.Clamp(currentArmor + _value, 0, startingArmor);
            if (currentArmor == startingArmor)
            {
                broken = false;
                Debug.Log("Armor Repaired!");
            }
        }
    }
}
