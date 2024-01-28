using System.Collections;
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

    public int PlimPlamLife = 3;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameStateManager.Initialize();

        if (currentEvent == null)
        {
            currentEvent = new UnityEvent<CurrentAudience>();

        }
        ChangeCurrentAudience();

    }

    public void ChangeCurrentAudience()
    {
        currentAudience = currentAudiences[Random.Range(0, currentAudiences.Length)];
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

    public void ReduceLife()
    {
        PlimPlamLife--;
        if (PlimPlamLife <= 0)
        {
            UILoseCanvasManager.instance.YouLose();
        }
    }

    public void RestartGame()
    {
        PlimPlamLife = 3;
        ScoreManager.Instance.RestartScore();
    }
}

public static class GameStateManager
{
    public static GameState currentState;
    public static UnityEvent<GameState> currentStateEvent;

    public static void Initialize()
    {
        currentState = GameState.Playing;
        if (currentStateEvent == null)
        {
            currentStateEvent = new UnityEvent<GameState>();
        }
        currentStateEvent.Invoke(currentState);

    }
    public static void SetCurrentStatus(GameState state)
    {
        currentState = state;
        currentStateEvent.Invoke(currentState);

    }
}