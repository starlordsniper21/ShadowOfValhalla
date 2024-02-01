using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private HealthPotionManager healthPotionManager;

    private void Start()
    {
        healthPotionManager = FindObjectOfType<HealthPotionManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            healthPotionManager.CollectHealthPotion(); 
            Destroy(gameObject);
        }
    }
}
