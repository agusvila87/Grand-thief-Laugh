using UnityEngine;


[RequireComponent(typeof(NpcMovement), typeof(NpcColliders), typeof(SpriteRenderer))]
public class NpcActions : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private NpcMovement npcMovement;
    private Animator animator;

    private NPCSO nPCSO;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        npcMovement = GetComponent<NpcMovement>();
        animator = GetComponent<Animator>();
    }
    public void Caked()
    {
        //animator.SetTrigger("isCaked");
        GameManager.Instance.NPCHitted(nPCSO);
        NpcSpawner.Instance.DeleteNpc(gameObject);
    }

    public void SetNPC(NPCValues nPCValues, NPCSO npcSO)
    {
        transform.SetPositionAndRotation(nPCValues.spawnPos, nPCValues.rotation);
        SetSprite(npcSO.sprite);
        SetMovement(npcSO.movementLogic, nPCValues.velocity * npcSO.speedMultiplier);
        nPCSO = npcSO;
        animator.runtimeAnimatorController = npcSO.animatorController;
    }

    private void SetMovement(MovementLogic movementLogic, float velocity)
    {
        npcMovement.SetLogic(movementLogic, velocity);
    }

    private void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
