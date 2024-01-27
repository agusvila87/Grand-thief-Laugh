using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIScoreManager : MonoBehaviour
{
    private TextMeshProUGUI viewers => GetComponent<TextMeshProUGUI>();

    private void Start()
    {
        ScoreManager.Instance.updateScoreEvent.AddListener(UpdateText);
    }

    private void UpdateText(int score)
    {
        viewers.text = $"{score}";
    }
}
