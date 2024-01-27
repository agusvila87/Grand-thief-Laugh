using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTargetAudience : MonoBehaviour
{
    public static CurrentTargetAudience Instance;

    private CurrentAudience currentAudience => GameManager.Instance._currentAudience;


    private void Awake()
    {
        Instance = this;
    }
    public bool IsCorrectTarget(TypeOfNPC caked)
    {
        return caked == currentAudience.typeObjective;
    }
    public int GetCurrentScore(TypeOfNPC caked)
    {
        return IsCorrectTarget(caked) ?
            currentAudience.scoreGiven :
            currentAudience.scoreTaken;
    }
}
