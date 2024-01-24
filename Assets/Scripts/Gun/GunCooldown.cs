using System;
using UnityEngine;

public class GunCooldown : MonoBehaviour
{
    public bool canShoot { get; private set; }

    private float timer;

    [SerializeField] private float cooldown;

    private Action timerAction;

    private void Awake()
    {
        canShoot = true;
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

        if (timer > cooldown && !canShoot)
        {
            canShoot = true;
            EndTimer();
        }
    }

    public void RestartTimer()
    {
        canShoot = false;
        timer = 0;
        timerAction = Timer;
    }

    public void EndTimer()
    {
        timerAction = null;
    }
}
