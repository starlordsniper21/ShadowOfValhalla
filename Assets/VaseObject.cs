using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    public GameObject[] itemPrefabs;
    private bool hasSpawnedItem = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AttackArea"))
        {
            BreakObject();
        }
    }

    private void BreakObject()
    {
        if (!hasSpawnedItem && itemPrefabs.Length > 0)
        {
            SpawnItems();
            PlayBreakSound();
            hasSpawnedItem = true; //Added boolean flag para di magmutiple spawn ng items or prefabs
        }
        Destroy(gameObject);
    }

    private void SpawnItems()
    {
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        Instantiate(itemPrefabs[randomIndex], transform.position, Quaternion.identity);
    }

    private void PlayBreakSound()
    {
        if (breakSound != null)
        {
            SoundManager.instance.PlaySound(breakSound);
        }
    }
}
