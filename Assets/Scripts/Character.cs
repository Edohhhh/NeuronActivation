using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public int totalExperience;
    public TMPro.TextMeshProUGUI experienceText;
    public HealthBar healthBar;
    public int bulletDamage;
    [HideInInspector] public Coins coins;

    private void Awake()
    {
        coins = GetComponent<Coins>();
        // Cargar las estadísticas desde InitialPlayerStats
        LoadStatsFromInitialPlayerStats();
    }

    private void Start()
    {
        healthBar.SetMaxHealth(maxHp);
        healthBar.SetHealth(currentHp);
        UpdateExperienceUI();
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        healthBar.SetHealth(currentHp);
        if (currentHp <= 0)
        {
            currentHp = 0;
            Debug.Log("Muerte");
            SceneManager.LoadScene("Lose");
        }
        else
        {
            Debug.Log("Daño recibido: " + damage + ", HP restante: " + currentHp);
        }
    }

    public void Heal(int amount)
    {
        if (currentHp <= 0) return;

        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        healthBar.SetHealth(currentHp);
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

    private void LoadStatsFromInitialPlayerStats()
    {
        if (InitialPlayerStats.instance != null && InitialPlayerStats.instance.initialized)
        {
            maxHp = InitialPlayerStats.instance.maxHp;
            currentHp = InitialPlayerStats.instance.currentHp;
            totalExperience = InitialPlayerStats.instance.totalExperience;
            bulletDamage = InitialPlayerStats.instance.bulletDamage;
        }
        else
        {
            Debug.LogError("InitialPlayerStats no ha sido inicializado o no existe.");
        }
    }
}

