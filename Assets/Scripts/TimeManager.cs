using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir esta línea para trabajar con UI

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false; // Estado de pausa
    public GameObject pauseMenu; // Referencia al panel de pausa
    public GameObject rotatePoint; // Referencia al GameObject RotatePoint

    void Start()
    {
        // Asegúrate de que el menú de pausa y el RotatePoint estén activados al inicio
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        // Detectar si se presiona la tecla Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause(); // Alternar el estado de pausa
        }
    }

    // Método para alternar la pausa
    void TogglePause()
    {
        isPaused = !isPaused; // Cambiar el estado de pausa

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausar el juego
            pauseMenu.SetActive(true); // Mostrar el menú de pausa
            rotatePoint.SetActive(false); // Desactivar RotatePoint
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el juego
            pauseMenu.SetActive(false); // Ocultar el menú de pausa
            rotatePoint.SetActive(true); // Reactivar RotatePoint
        }
    }

    // Método para volver al juego (llamado por el botón)
    public void ResumeGame()
    {
        TogglePause(); // Alternar el estado de pausa
    }
}