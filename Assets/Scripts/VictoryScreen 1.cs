using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreen1 : MonoBehaviour
{
    // Asigna este botón desde el Inspector
    public Button nextLevelButton;

    void Start()
    {
        // Agrega el listener al botón para que llame a la función de cargar nivel 2
        nextLevelButton.onClick.AddListener(LoadNextLevel);
    }

    // Función que carga el nivel 2
    void LoadNextLevel()
    {
        // Asegúrate de que el nivel 2 esté agregado en la Build Settings
        SceneManager.LoadScene("Level2");
    }
}

