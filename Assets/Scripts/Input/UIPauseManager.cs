using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseManager : MonoBehaviour
{
    public static UIPauseManager instance;
    
    [SerializeField] private GameObject pauseCanvas;
    private bool isPaused;

    private void Awake()
    {
        instance = this;
        isPaused = false;
    }

    public void PauseGame()
    {
        Debug.Log(isPaused);

        if(!isPaused)
        {
            GameStateManager.SetCurrentStatus(GameState.Pause);
            pauseCanvas.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
            GameStateManager.SetCurrentStatus(GameState.Playing);
            pauseCanvas.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
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