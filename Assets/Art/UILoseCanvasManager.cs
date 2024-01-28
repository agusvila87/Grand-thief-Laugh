using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILoseCanvasManager : MonoBehaviour
{
    public static UILoseCanvasManager instance;

    [SerializeField] private GameObject EndCanvas;
    [SerializeField] private Button playAgain, goMenu;

    private void Awake()
    {
        instance = this;

        EndCanvas.SetActive(false);
    }
    private void Start()
    {
        playAgain.onClick.AddListener(PlayAgain);
        goMenu.onClick.AddListener(GoMenu);
    }

    private void GoMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    private void PlayAgain()
    {
        SceneManager.LoadSceneAsync("SampleScene");
        GameStateManager.SetCurrentStatus(GameState.Playing);
        //GameManager.Instance.RestartGame();
        //EndCanvas.SetActive(false);
    }

    public void YouLose()
    {
        GameStateManager.SetCurrentStatus(GameState.Lose);
        EndCanvas.SetActive(true);
    }
}