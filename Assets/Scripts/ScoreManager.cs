using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int currentScore;
    public int _currentScore => currentScore;

    [HideInInspector] public UnityEvent<int> updateScoreEvent { get; private set; }

    private void Awake()
    {
        Instance = this;
        updateScoreEvent = new UnityEvent<int>();
    }

    private void Start()
    {
        currentScore = 0;
    }


    public void RestartScore()
    {
        currentScore = 0;
        updateScoreEvent.Invoke(currentScore);
    }

    public void AddScore(NPCSO nPCSO)
    {

        currentScore += CurrentTargetAudience.Instance.GetCurrentScore(nPCSO.typeOfNPC);

        updateScoreEvent.Invoke(currentScore);
    }
}
