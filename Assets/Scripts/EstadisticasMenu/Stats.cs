using UnityEngine;

public class Stats : MonoBehaviour
{
    // Variables de estad�sticas que se ver�n en el Inspector
    public int vida = 100;          // Valor inicial de vida
    public int explosionBala = 1;   // Valor inicial de explosi�n de bala
    public int velocidad = 5;       // Valor inicial de velocidad

    // M�todos para incrementar las estad�sticas
    public void IncrementarVida(int cantidad)
    {
        vida += cantidad;
        Debug.Log("Vida incrementada: " + vida);
    }

    public void IncrementarExplosionBala(int cantidad)
    {
        explosionBala += cantidad;
        Debug.Log("Explosi�n de Bala incrementada: " + explosionBala);
    }

    public void IncrementarVelocidad(int cantidad)
    {
        velocidad += cantidad;
        Debug.Log("Velocidad incrementada: " + velocidad);
    }

    // M�todos para disminuir las estad�sticas
    public void DisminuirVida(int cantidad)
    {
        vida -= cantidad;
        Debug.Log("Vida disminuida: " + vida);
    }

    public void DisminuirExplosionBala(int cantidad)
    {
        explosionBala -= cantidad;
        Debug.Log("Explosi�n de Bala disminuida: " + explosionBala);
    }

    public void DisminuirVelocidad(int cantidad)
    {
        velocidad -= cantidad;
        Debug.Log("Velocidad disminuida: " + velocidad);
    }
}
