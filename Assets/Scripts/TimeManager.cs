using UnityEngine;
using UnityEngine.UI; // Aseg�rate de incluir esta l�nea para trabajar con UI

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false; // Estado de pausa
    public GameObject pauseMenu; // Referencia al panel de pausa
    public GameObject rotatePoint; // Referencia al GameObject RotatePoint

    void Start()
    {
        // Aseg�rate de que el men� de pausa y el RotatePoint est�n activados al inicio
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

    // M�todo para alternar la pausa
    void TogglePause()
    {
        isPaused = !isPaused; // Cambiar el estado de pausa

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausar el juego
            pauseMenu.SetActive(true); // Mostrar el men� de pausa
            rotatePoint.SetActive(false); // Desactivar RotatePoint
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el juego
            pauseMenu.SetActive(false); // Ocultar el men� de pausa
            rotatePoint.SetActive(true); // Reactivar RotatePoint
        }
    }

    // M�todo para volver al juego (llamado por el bot�n)
    public void ResumeGame()
    {
        TogglePause(); // Alternar el estado de pausa
    }
}