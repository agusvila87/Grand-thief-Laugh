﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private CurrentAudience[] currentAudiences;
    private CurrentAudience currentAudience;

    public CurrentAudience _currentAudience => currentAudience;

    public UnityEvent<CurrentAudience> currentEvent;

    private WaitForSeconds wait = new WaitForSeconds(2);

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (currentEvent == null)
        {
            currentEvent = new UnityEvent<CurrentAudience>();
        }
        ChangeCurrentAudience();
    }

    public void ChangeCurrentAudience()
    {
        currentAudience = currentAudiences[Random.Range(0, currentAudiences.Length - 1)];
        currentEvent.Invoke(currentAudience);
    }

    public void NPCHitted(NPCSO nPCSO)
    {
        ScoreManager.Instance.AddScore(nPCSO);
        UICurrentTargetAudience.Instance.ChangeTargetSprite(nPCSO);
        StartCoroutine(ChangeAudience());
    }
    private IEnumerator ChangeAudience()
    {
        yield return wait;
        ChangeCurrentAudience();
    }
}