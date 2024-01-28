using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PuaseInput : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    private bool isPaused = false;

    void Update()
    {
        // Verificar si se ha presionado la tecla Escape
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            // Cambiar el estado de pausa
            TogglePause();
            Debug.Log("pausa");
        }

    }


    // Función para cambiar el estado de pausa
    public void TogglePause()
    {
        // Cambiar el estado de pausa
        isPaused = !isPaused;

        // Pausar o reanudar el juego según el estado
        if (isPaused)
        {
            Time.timeScale = 0f; // Pausar el tiempo en el juego
            // Aquí puedes realizar otras acciones de pausa si es necesario
            pauseCanvas.SetActive(true);
            Debug.Log("Juego pausado");
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el tiempo en el juego
            // Aquí puedes realizar otras acciones al reanudar si es necesario
            Debug.Log("Juego reanudado");
            pauseCanvas.SetActive(false);
        }
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
