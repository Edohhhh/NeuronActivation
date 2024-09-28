using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    public int ExperienceValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisión detectada con: " + collision.name);

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Colisionó con el jugador");
            Character player = collision.GetComponent<Character>();
            if (player != null)
            {
                Debug.Log("Jugador encontrado, sumando experiencia");
                player.AddExperience(ExperienceValue);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("El jugador no tiene el script Player");

            }
        }
    }
}