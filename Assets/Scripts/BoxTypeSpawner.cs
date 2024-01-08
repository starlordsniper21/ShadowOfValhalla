using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTypeSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;
    public float spawnInterval = 120f;
    public Vector2 spawnAreaSize = new Vector2(5f, 5f);

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
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
            Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f),
            0f
        );

        Instantiate(ItemPrefab, transform.position + randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0f));
    }
}
