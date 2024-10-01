using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaLose : MonoBehaviour
{
    public void irAlMenu() => SceneManager.LoadScene("MenuInicial");

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
