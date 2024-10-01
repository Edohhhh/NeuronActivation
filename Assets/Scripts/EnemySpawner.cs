using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private List<Transform> spawnAreas;
    [SerializeField] private float spawnInterval = 2f; // Intervalo entre spawns de enemigos dentro de una horda
    [SerializeField] private float waveInterval = 5f; // Tiempo de descanso entre hordas
    [SerializeField] private int enemiesPerWave = 10; // Cantidad de enemigos por horda
    [SerializeField] private int maxEnemiesPerSpawn = 3; // Cantidad máxima de enemigos por spawn
    [SerializeField] private int totalWaves = 5; // Total de hordas
    private int currentWave = 0; // Contador de hordas
    private int currentEnemyCount = 0;
    private List<Enemy> activeEnemies = new List<Enemy>();

    private void Start()
    {
        StartCoroutine(StartWaveSystem());
    }

    // Corrutina que controla el sistema de hordas
    private IEnumerator StartWaveSystem()
    {
        while (currentWave < totalWaves)
        {
            currentWave++;
            Debug.Log($"Iniciando Horda {currentWave}");
            yield return StartCoroutine(SpawnEnemiesForWave());

            // Espera después de la horda
            Debug.Log("Esperando el siguiente descanso...");
            yield return new WaitForSeconds(waveInterval);
        }

        Debug.Log("¡Todas las hordas completadas! Victoria.");
        ShowVictoryScreen();
    }

    // Corrutina que genera los enemigos progresivamente durante una horda
    private IEnumerator SpawnEnemiesForWave()
    {
        currentEnemyCount = 0;
        int enemiesToSpawn = enemiesPerWave;

        while (enemiesToSpawn > 0)
        {
            int spawnCount = Mathf.Min(maxEnemiesPerSpawn, enemiesToSpawn);
            for (int i = 0; i < spawnCount; i++)
            {
                Enemy newEnemy = enemyFactory.CreateEnemy();
                newEnemy.transform.position = GetRandomSpawnPosition();
                newEnemy.SetTarget(playerTransform);
                activeEnemies.Add(newEnemy);
                currentEnemyCount++;
            }

            enemiesToSpawn -= spawnCount;

            yield return new WaitForSeconds(spawnInterval); // Intervalo entre spawns
        }

        // Espera a que todos los enemigos de la horda sean derrotados
        yield return new WaitUntil(() => activeEnemies.Count == 0);
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

    private void ShowVictoryScreen()
    {
        // Obtiene el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Verifica el índice de la escena actual y carga la pantalla de victoria correspondiente
        if (currentSceneIndex == 1) // Supongamos que el nivel 1 tiene el índice 1
        {
            Debug.Log("Pantalla de victoria para el Nivel 1.");
            SceneManager.LoadScene("Win");
        }
        else if (currentSceneIndex == 2) // Supongamos que el nivel 2 tiene el índice 2
        {
            Debug.Log("Pantalla de victoria para el Nivel 2.");
            SceneManager.LoadScene("Win2");
        }
        else
        {
            Debug.LogError("No se encontró una pantalla de victoria para este nivel.");
        }
    }
}




