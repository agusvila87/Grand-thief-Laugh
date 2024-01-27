using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICurrentTargetAudience : MonoBehaviour
{
    private Image spriteAudience => GetComponent<Image>();

    public static UICurrentTargetAudience Instance;

    private CurrentAudience currentAudience => GameManager.Instance._currentAudience;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameManager.Instance.currentEvent.AddListener(ChangeNewAudience);
    }

    private void ChangeNewAudience(CurrentAudience currentAudience)
    {
        spriteAudience.sprite = currentAudience.audienceSprites.idleAudience;
    }

    public void ChangeTargetSprite(NPCSO nPCSO)
    {
        spriteAudience.sprite = CurrentTargetAudience.Instance.IsCorrectTarget(nPCSO.typeOfNPC) ? //si es el target correcto...
            currentAudience.audienceSprites.happyAudience : //entonce va a ser feliz
            currentAudience.audienceSprites.angryAudience; //si no, enojao
    }
}
