using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaEnemy : MonoBehaviour
{
    public GameObject[] prefabs;
    private Queue<GameObject> prefabQueue= new Queue<GameObject>();
    private int enemykillcount = 0;
    public int killstoSpawnPrefabs = 3;

    private void Start()
    {
        foreach (GameObject prefab in prefabs)
        {
            prefabQueue.Enqueue(prefab);
        }
    }
    public void OnEnemyKilled()
    {
        enemykillcount++;

        if(enemykillcount >= killstoSpawnPrefabs && prefabQueue.Count > 0 )
        {
            SpawnPrefab();
            enemykillcount = 0;
        }

    }
    private void SpawnPrefab()
    {
        if (prefabQueue.Count > 0)
        {
            GameObject prefabToSpawn = prefabQueue.Dequeue();
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
    }
}
