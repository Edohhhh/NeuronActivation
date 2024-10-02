using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySelectedObjects : MonoBehaviour
{
    // Array de GameObjects que no quieres destruir entre escenas
    public GameObject[] objectsToPreserve;

    void Awake()
    {
        foreach (GameObject obj in objectsToPreserve)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true); // Activar el objeto si está desactivado
            }
            DontDestroyOnLoad(obj); // Asegurarse de que no se destruya al cambiar de escena
        }
    }
}
