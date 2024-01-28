using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIScoreManager : MonoBehaviour
{
    private TextMeshProUGUI viewers => GetComponent<TextMeshProUGUI>();
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        ScoreManager.Instance.updateScoreEvent.AddListener(UpdateText);
    }

    private void UpdateText(int score)
    {
        viewers.text = $"{score}";
        animator.SetTrigger("SizeScore");
    }
}
