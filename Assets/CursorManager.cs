using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // La textura que se usará como cursor
    [SerializeField] private Texture2D cursorTexture;

    // Punto caliente, es decir, el punto exacto del cursor que estará alineado con la posición del mouse (normalmente en el centro o esquina superior izquierda)
    private Vector2 cursorHotspot;

    void Start()
    {
        // El punto caliente será el centro de la imagen del cursor
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);

        // Establecer la textura del cursor con el hotspot
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }

    // Método para ocultar el cursor si lo deseas
    public void HideCursor()
    {
        Cursor.visible = false;
    }

    // Método para mostrar el cursor si lo ocultas
    public void ShowCursor()
    {
        Cursor.visible = true;
    }
}
