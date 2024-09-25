using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{

    public void Jugar() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    //public void Controles() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

    //public void Volver() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);

    //public void Game() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
