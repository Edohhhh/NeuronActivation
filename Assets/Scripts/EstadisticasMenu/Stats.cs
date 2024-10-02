using UnityEngine;

public class Stats : MonoBehaviour
{
    // Variables de estadísticas que se verán en el Inspector
    public int vida = 100;          // Valor inicial de vida
    public int explosionBala = 1;   // Valor inicial de explosión de bala
    public int velocidad = 5;       // Valor inicial de velocidad

    // Métodos para incrementar las estadísticas
    public void IncrementarVida(int cantidad)
    {
        vida += cantidad;
        Debug.Log("Vida incrementada: " + vida);
    }

    public void IncrementarExplosionBala(int cantidad)
    {
        explosionBala += cantidad;
        Debug.Log("Explosión de Bala incrementada: " + explosionBala);
    }

    public void IncrementarVelocidad(int cantidad)
    {
        velocidad += cantidad;
        Debug.Log("Velocidad incrementada: " + velocidad);
    }

    // Métodos para disminuir las estadísticas
    public void DisminuirVida(int cantidad)
    {
        vida -= cantidad;
        Debug.Log("Vida disminuida: " + vida);
    }

    public void DisminuirExplosionBala(int cantidad)
    {
        explosionBala -= cantidad;
        Debug.Log("Explosión de Bala disminuida: " + explosionBala);
    }

    public void DisminuirVelocidad(int cantidad)
    {
        velocidad -= cantidad;
        Debug.Log("Velocidad disminuida: " + velocidad);
    }
}
