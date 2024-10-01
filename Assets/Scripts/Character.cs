using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    public int totalExperience = 0;
    public TMPro.TextMeshProUGUI experienceText;
    public HealthBar healthBar;

    public int bulletDamage = 10;


    [HideInInspector] public Coins coins;


    private void Awake()
    {
        coins = GetComponent<Coins>();
    }
    private void Start()
    {
        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);
    }
    public void TakeDamage(int damage)
    {
        currentHp -= damage; // Resta el daño recibido de la vida actual
        healthBar.SetHealth(currentHp);
        if (currentHp <= 0)
        {
            currentHp = 0; // Evita que la vida sea negativa
            Debug.Log("Muerte");
            SceneManager.LoadScene("Lose");
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
    public void IncreaseHealth(int amount)
    {
        currentHp += amount;
        Debug.Log("Nueva salud: " + currentHp);
    }
    public void AddExperience(int amount)
    {
        totalExperience += amount;
        UpdateExperienceUI();
    }

    void UpdateExperienceUI()
    {
        experienceText.text = "EXP: " + totalExperience;
    }
}