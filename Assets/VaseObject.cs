using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    public GameObject[] itemPrefabs;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BreakObject();
        }
    }

    private void BreakObject()
    {
        SpawnItems();
        PlayBreakSound();
        Destroy(gameObject);
    }

    private void SpawnItems()
    {
        foreach (GameObject itemPrefab in itemPrefabs)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
    }

    private void PlayBreakSound()
    {
        if (breakSound != null)
        {
            SoundManager.instance.PlaySound(breakSound);
        }
    }
}
