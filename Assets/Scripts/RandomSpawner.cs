using System.Collections;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] ItemPrefab;
    public float radius = 1;
    public int spawnInterval = 15;
    

    void Start()
    {
        StartCoroutine(SpawnItemsRoutine());
    }

    IEnumerator SpawnItemsRoutine()
    {
        while (true)
        {
            SpawnObjectAtRandom();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObjectAtRandom()
    {
        if (ItemPrefab.Length == 0)
        {
            Debug.LogWarning("ItemPrefab array is empty. Please assign GameObjects to it in the inspector.");
            return;
        }

        GameObject randomItem = ItemPrefab[Random.Range(0, ItemPrefab.Length)];
        Vector3 randomPos = Random.insideUnitCircle.normalized * radius;
        Instantiate(randomItem, transform.position + randomPos, Quaternion.identity);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
