using UnityEngine;

public class ArmorCollect : MonoBehaviour
{
    [SerializeField] private float armorValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Armor>().RepairArmor(armorValue);
            gameObject.SetActive(false);
        }
    }
}
