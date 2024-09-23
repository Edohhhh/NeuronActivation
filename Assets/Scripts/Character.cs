using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;


    [HideInInspector] public Coins coins;




    private void Awake()
    {
        coins = GetComponent<Coins>();
    }
    private void Start()
    {
        
    }
    public void TakeDamage(int damage)
    {
        currentHp -= damage; // Resta el daño recibido de la vida actual

        if (currentHp <= 0)
        {
            currentHp = 0; // Evita que la vida sea negativa
            Debug.Log("Muerte");
            // Aquí puedes añadir más lógica, como destruir el objeto:
            // Destroy(gameObject);
        }
        else
        {
            Debug.Log("Daño recibido: " + damage + ", HP restante: " + currentHp);
        }
    }

    public void Heal(int amount)
    {
        if (currentHp <= 0) { return; }

        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }
}