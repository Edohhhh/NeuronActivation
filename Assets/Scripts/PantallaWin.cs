using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaWin : MonoBehaviour
{
    public void irAlMenu() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

}
