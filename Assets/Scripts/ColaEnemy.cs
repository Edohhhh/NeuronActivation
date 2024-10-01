using System.Collections.Generic;
using UnityEngine;

public class ColaEnemy : MonoBehaviour
{
    public GameObject[] prefabs;  // Los prefabs que se spawnear�n en orden
    public Transform spawnPoint;  // El punto donde spawnear�n los prefabs
    private int enemyKillCount = 0;  // Conteo de enemigos muertos
    private int currentIndex = 0;  // �ndice del prefab actual

    private GameObject currentPrefab;  // Referencia al prefab actual instanciado

    // M�todo que se llamar� cada vez que se mate a un enemigo
    public void OnEnemyKilled()
    {
        enemyKillCount++;
        if (enemyKillCount % 3 == 0)  // Cada 3 enemigos muertos
        {
            SpawnNextPrefab();
        }
    }

    // M�todo para spawnear el siguiente prefab en la lista
    private void SpawnNextPrefab()
    {
        // Si hay un prefab activo, destr�yelo antes de spawnear el siguiente
        if (currentPrefab != null)
        {
            Destroy(currentPrefab);
        }

        // Spawnea el siguiente prefab exactamente en la posici�n del spawnPoint
        currentPrefab = Instantiate(prefabs[currentIndex], spawnPoint.position, Quaternion.identity);

        // Avanza al siguiente prefab en la lista
        currentIndex = (currentIndex + 1) % prefabs.Length;  // Ciclo circular en la lista de prefabs
    }
}

