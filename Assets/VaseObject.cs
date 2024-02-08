using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public int health = 3; // Health of the vase
    public GameObject[] dropItems; // Array of items to drop when the vase breaks

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(1); // Decrease the vase's health by 1 when hit by the player
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Break();
        }
    }

    private void Break()
    {
        // Randomly select one item from dropItems
        GameObject itemToDrop = dropItems[Random.Range(0, dropItems.Length)];

        // Drop the selected item
        Instantiate(itemToDrop, transform.position, Quaternion.identity);

        // Destroy the vase
        Destroy(gameObject);
    }
}
