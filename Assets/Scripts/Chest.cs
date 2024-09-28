using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool playerInRange = false;
    public int expRequired = 10;

    public GameObject flamethrower; // Referencia al GameObject Flamethrower
    public float activationProbability = 0.2f; // Probabilidad de activar el Flamethrower (50%)

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Character player = GameObject.FindWithTag("Player").GetComponent<Character>();

            if (player.totalExperience >= expRequired)
            {
                player.AddExperience(-expRequired);

                int randomStat = Random.Range(0, 2);

                if (randomStat == 0)
                {
                    player.IncreaseHealth(20);
                    Debug.Log("Vida aumentada en 20 puntos");
                }
                else
                {
                    player.bulletDamage += 5;
                    Debug.Log("Daño de bala aumentado en 5 puntos");
                }

                // Activar el Flamethrower con probabilidad
                if (flamethrower != null && Random.value <= activationProbability)
                {
                    flamethrower.SetActive(true); // Activar el Flamethrower
                    Debug.Log("Flamethrower activado por probabilidad");
                }
                else
                {
                    Debug.Log("Flamethrower no activado");
                }
            }
            else
            {
                Debug.Log("No tienes suficiente experiencia");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Jugador dentro del rango del cofre");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Jugador salió del rango del cofre");
        }
    }
}


