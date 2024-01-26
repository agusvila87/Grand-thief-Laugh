using System;
using UnityEngine;

public class CurrentTargetAudience : MonoBehaviour
{
    public static CurrentTargetAudience Instance;

    private CurrentAudience currentAudience;
    private void Awake()
    {
        Instance = this;
    }

    public int GetCurrentScore(TypeOfNPC caked)
    {
        CurrentAudience current = currentAudience;
        if(current == null)
        {
            return 1;
        }
        if (caked == current.typeObjective)
        {
            return current.scoreGiven;
        }
        else
        {
            return current.scoreTaken;
        }
    }
}
