using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;
    [SerializeField] private Transform playerTransform; // El transform del jugador que los enemigos seguirán
    [SerializeField] private List<Transform> spawnAreas;
    public float spawnInterval = 5f;
    public int maxEnemiesPerSpawn = 3;
    public int totalEnemiesAllowed = 10;

    private int currentEnemyCount = 0;
    private List<Enemy> activeEnemies = new List<Enemy>();

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), 0f, spawnInterval);
    }

    private void SpawnEnemies()
    {
        if (currentEnemyCount >= totalEnemiesAllowed) return;

        int enemiesToSpawn = Mathf.Min(maxEnemiesPerSpawn, totalEnemiesAllowed - currentEnemyCount);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Enemy newEnemy = enemyFactory.CreateEnemy();
            newEnemy.transform.position = GetRandomSpawnPosition();

            // Configura el transform del jugador como destino para el nuevo enemigo
            newEnemy.SetTarget(playerTransform);

            activeEnemies.Add(newEnemy);
            currentEnemyCount++;
        }
    }

    private Vector2 GetRandomSpawnPosition()
    {
        if (spawnAreas.Count == 0)
        {
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);
            return new Vector2(x, y);
        }

        int randomIndex = Random.Range(0, spawnAreas.Count);
        return spawnAreas[randomIndex].position;
    }

    public void EnemyDied(Enemy enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
            currentEnemyCount--;
        }
    }
}
