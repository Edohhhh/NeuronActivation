using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsMenu : MonoBehaviour
{
    public InitialPlayerStats playerStats;

    // Variables para las estad�sticas
    public TextMeshProUGUI[] statTexts; // Referencias a los textos de estad�sticas en la UI (TextMeshPro)
    public TextMeshProUGUI remainingPointsText; // Texto para mostrar puntos restantes (TextMeshPro)

    private int[] stats; // Array de estad�sticas (ejemplo: 3 estad�sticas)
    public int totalPoints; // Inicialmente 5 puntos, puede ser modificado seg�n el progreso del jugador

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

    // M�todo para a�adir puntos a una estad�stica
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


            //stats[statIndex]++; // Incrementa la estad�stica
            totalPoints--; // Decrementa los puntos disponibles
            undoStack.Push(statIndex); // Guarda la acci�n en la pila de deshacer
            redoStack.Clear(); // Limpia la pila de rehacer despu�s de una nueva acci�n
            UpdateUI();
        }
    }


    // M�todo para deshacer la �ltima acci�n
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
            redoStack.Push(lastAction); // Mueve la acci�n a la pila de rehacer
            UpdateUI();
        }

    }

    // M�todo para rehacer la �ltima acci�n deshecha
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
            undoStack.Push(lastUndone); // Mueve la acci�n a la pila de deshacer
            UpdateUI();
        }
    }

    // Actualiza los textos de la UI
    void UpdateUI()
    {
        statTexts[0].text = "Vida: " + playerStats.currentHp;
        statTexts[1].text = "Da�o de Bala: " + playerStats.bulletDamage;
        statTexts[2].text = "Velocidad: " + playerStats.speed;
        statTexts[3].text = "Explosi�n de Bala: " + playerStats.explosionRadius;

        remainingPointsText.text = "Puntos Restantes: " + totalPoints;
    }

    // M�todo para ganar m�s puntos (por ejemplo al subir de nivel)
    public void GainPoints(int points)
    {
        totalPoints += points; // Incrementa los puntos totales disponibles
        UpdateUI(); // Actualiza la UI despu�s de ganar puntos
    }
}


