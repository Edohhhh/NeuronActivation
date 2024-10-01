using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreen1 : MonoBehaviour
{
    // Asigna este bot�n desde el Inspector
    public Button nextLevelButton;

    void Start()
    {
        // Agrega el listener al bot�n para que llame a la funci�n de cargar nivel 2
        nextLevelButton.onClick.AddListener(LoadNextLevel);
    }

    // Funci�n que carga el nivel 2
    void LoadNextLevel()
    {
        // Aseg�rate de que el nivel 2 est� agregado en la Build Settings
        SceneManager.LoadScene("Level2");
    }
}

