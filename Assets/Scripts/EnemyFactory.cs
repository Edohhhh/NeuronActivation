using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject vampirePrefab;
    [SerializeField] private GameObject ghostPrefab;

    [Range(0, 100)] public int zombieSpawnChance = 50;
    [Range(0, 100)] public int vampireSpawnChance = 30;
    [Range(0, 100)] public int ghostSpawnChance = 20;

    private void Start()
    {

        int totalChance = zombieSpawnChance + vampireSpawnChance + ghostSpawnChance;
        if (totalChance != 100)
        {
            float factor = 100f / totalChance;
            zombieSpawnChance = Mathf.RoundToInt(zombieSpawnChance * factor);
            vampireSpawnChance = Mathf.RoundToInt(vampireSpawnChance * factor);
            ghostSpawnChance = Mathf.RoundToInt(ghostSpawnChance * factor);
        }
    }

    public Enemy CreateEnemy()
    {
        int randomValue = Random.Range(0, 100);

        if (randomValue < zombieSpawnChance)
        {
            return Instantiate(zombiePrefab).GetComponent<Enemy>();
        }
        else if (randomValue < zombieSpawnChance + vampireSpawnChance)
        {
            return Instantiate(vampirePrefab).GetComponent<Enemy>();
        }
        else
        {
            return Instantiate(ghostPrefab).GetComponent<Enemy>();
        }
    }
}