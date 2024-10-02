using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsMenu : MonoBehaviour
{
    public InitialPlayerStats playerStats;

    // Variables para las estadísticas
    public TextMeshProUGUI[] statTexts; // Referencias a los textos de estadísticas en la UI (TextMeshPro)
    public TextMeshProUGUI remainingPointsText; // Texto para mostrar puntos restantes (TextMeshPro)

    private int[] stats; // Array de estadísticas (ejemplo: 3 estadísticas)
    public int totalPoints; // Inicialmente 5 puntos, puede ser modificado según el progreso del jugador

    // Pilas para deshacer y rehacer acciones
    private Stack<int> undoStack;
    private Stack<int> redoStack;

    void Start()
    {
        stats = new int[statTexts.Length];
        undoStack = new Stack<int>();
        redoStack = new Stack<int>();
        UpdateUI(); // Actualiza la interfaz al inicio
    }

    // Método para añadir puntos a una estadística
    public void AddPoint(int statIndex)
    {
        if (totalPoints > 0) // Solo permite agregar si hay puntos disponibles
        {
            if (statIndex == 0) // Vida
                playerStats.IncrementarMaxHp(10);
            else if (statIndex == 1)
                playerStats.IncrementarBulletDamage(1);
            else if (statIndex == 2) // Velocidad
                playerStats.IncrementarVelocidad(1);
            else if (statIndex == 3) // Velocidad
                playerStats.IncrementarExplosionRadius(1);


            //stats[statIndex]++; // Incrementa la estadística
            totalPoints--; // Decrementa los puntos disponibles
            undoStack.Push(statIndex); // Guarda la acción en la pila de deshacer
            redoStack.Clear(); // Limpia la pila de rehacer después de una nueva acción
            UpdateUI();
        }
    }


    // Método para deshacer la última acción
    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            int lastAction = undoStack.Pop();

            if (lastAction == 0)
                playerStats.DisminuirMaxHp(10);
            else if (lastAction == 1)
                playerStats.DisminuirBulletDamage(1);
            else if (lastAction == 2)
                playerStats.DisminuirVelocidad(1);
            else if (lastAction == 3)
                playerStats.DisminuirExplosionRadius(1);

            totalPoints++;
            redoStack.Push(lastAction); // Mueve la acción a la pila de rehacer
            UpdateUI();
        }

    }

    // Método para rehacer la última acción deshecha
    public void Redo()
    {
        if (redoStack.Count > 0 && totalPoints > 0)
        {
            int lastUndone = redoStack.Pop();

            if (lastUndone == 0)
                playerStats.IncrementarMaxHp(10);
            else if (lastUndone == 1)
                playerStats.IncrementarBulletDamage (1);
            else if (lastUndone == 2)
                playerStats.IncrementarVelocidad(1);
            else if (lastUndone == 3)
                playerStats.IncrementarExplosionRadius(1);

            totalPoints--;
            undoStack.Push(lastUndone); // Mueve la acción a la pila de deshacer
            UpdateUI();
        }
    }

    // Actualiza los textos de la UI
    void UpdateUI()
    {
        statTexts[0].text = "Vida: " + playerStats.currentHp;
        statTexts[1].text = "Daño de Bala: " + playerStats.bulletDamage;
        statTexts[2].text = "Velocidad: " + playerStats.speed;
        statTexts[3].text = "Explosión de Bala: " + playerStats.explosionRadius;

        remainingPointsText.text = "Puntos Restantes: " + totalPoints;
    }

    // Método para ganar más puntos (por ejemplo al subir de nivel)
    public void GainPoints(int points)
    {
        totalPoints += points; // Incrementa los puntos totales disponibles
        UpdateUI(); // Actualiza la UI después de ganar puntos
    }
}


