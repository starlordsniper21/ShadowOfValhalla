using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public int health = 3; // Health of the vase
    public GameObject[] dropItems; // Array of items to drop when the vase breaks
    public AudioClip breakSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = breakSound;
    }

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
        audioSource.Play();
        GameObject itemToDrop = dropItems[Random.Range(0, dropItems.Length)];
        Instantiate(itemToDrop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
