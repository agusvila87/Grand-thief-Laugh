using System;
using UnityEngine;

public class JokesCooldown : MonoBehaviour
{
    public bool canTellAJoke { get; private set; }

    private float timer;

    [SerializeField, Range(2, 10f)] private float cooldown = 2f;

    private Action timerAction;

    public static JokesCooldown instance;

    private void Awake()
    {
        instance = this;
        canTellAJoke = true;
    }

    private void PauseTimer(GameState gameState)
    {
        if (gameState != GameState.Lose) return;

        timerAction = null;
    }

    private void Update()
    {
        timerAction?.Invoke();
    }

    private void Timer()
    {
        timer += Time.deltaTime;

        if (timer > cooldown && !canTellAJoke)
        {
            canTellAJoke = true;
            EndTimer();
        }
    }

    public void RestartTimer()
    {
        PauseTimer();
        timerAction = Timer;
    }

    public void PauseTimer()
    {
        canTellAJoke = false;
        timer = 0;
    }
    public void EndTimer()
    {
        timerAction = null;
    }
}