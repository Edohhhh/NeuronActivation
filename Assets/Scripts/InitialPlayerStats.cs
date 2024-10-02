using UnityEngine;

public class InitialPlayerStats : MonoBehaviour
{
    public static InitialPlayerStats instance;


    public int maxHp = 1000;
    public int currentHp = 1000;
    public int totalExperience = 0;
    public int bulletDamage = 10;


    public float explosionRadius = 1f;
    public float speed = 3f;

    public bool initialized = false;

    private void Awake()
    {
        // Verificar si ya existe una instancia de InitialPlayerStats
        if (instance == null)
        {
            instance = this; // Asignar la instancia
            DontDestroyOnLoad(gameObject); // Hacer que este GameObject no se destruya al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject); // Destruir este GameObject si ya existe una instancia
        }
    }

    public void InitializeStats(int hp, int experience, int damage, float velocidadInicial, float explosionRadiusInicial)
    {
        maxHp = hp;
        currentHp = hp;
        totalExperience = experience;
        bulletDamage = damage;
        speed = velocidadInicial;
        explosionRadius = explosionRadiusInicial;

        initialized = true;
    }

    public void IncrementarMaxHp(int cantidad)
    {
        maxHp += cantidad;
        currentHp = maxHp;  // Opcional: restaurar vida al máximo al incrementar maxHp
        Debug.Log("Max HP incrementado: " + maxHp);
    }

    public void IncrementarBulletDamage(int cantidad)
    {
        bulletDamage += cantidad;
        Debug.Log("Daño de bala incrementado: " + bulletDamage);
    }

    public void DisminuirMaxHp(int cantidad)
    {
        maxHp -= cantidad;
        if (currentHp > maxHp) currentHp = maxHp;
        Debug.Log("Max HP disminuido: " + maxHp);
    }

    public void DisminuirBulletDamage(int cantidad)
    {
        bulletDamage -= cantidad;
        Debug.Log("Daño de bala disminuido: " + bulletDamage);
    }

    public void IncrementarExplosionRadius(float cantidad)
    {
        explosionRadius += cantidad;
        Debug.Log("Radio de explosión incrementado: " + explosionRadius);
    }

    public void DisminuirExplosionRadius(float cantidad)
    {
        explosionRadius -= cantidad;
        Debug.Log("Radio de explosión disminuido: " + explosionRadius);
    }

public void IncrementarVelocidad(float cantidad)
    {
        speed += cantidad;
        Debug.Log("Velocidad incrementada: " + speed);
    }

    public void DisminuirVelocidad(float cantidad)
    {
        speed -= cantidad;
        Debug.Log("Velocidad disminuida: " + speed);
    }
}
