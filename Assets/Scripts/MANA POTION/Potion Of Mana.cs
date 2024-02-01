using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    public int manaRestoreAmount = 5;

    private ManaPotionManager manaPotionManager;

    private void Start()
    {
        manaPotionManager = FindObjectOfType<ManaPotionManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ManaSystem manaSystem = other.GetComponent<ManaSystem>();
            if (manaSystem != null)
            {
                manaPotionManager.CollectManaPotion(manaRestoreAmount); 
                Destroy(gameObject);
            }
        }
    }
}
