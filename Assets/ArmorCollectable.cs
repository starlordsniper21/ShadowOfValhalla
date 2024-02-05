using UnityEngine;

public class ArmorCollectible : MonoBehaviour
{
    [SerializeField] private float armorValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Armor armorComponent = collision.GetComponent<Armor>();
            if (armorComponent != null)
            {
                armorComponent.RestoreArmor(armorValue);
                EnableArmorBars();
                gameObject.SetActive(false);
            }
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
