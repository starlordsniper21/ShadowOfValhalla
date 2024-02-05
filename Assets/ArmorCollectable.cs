using UnityEngine;

public class ArmorCollect : MonoBehaviour
{
    [SerializeField] private float armorValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Armor>().RestoreArmor(armorValue); // Restore armor instead of repairing
            gameObject.SetActive(false); // Disable the collectible object
        }
    }
}
