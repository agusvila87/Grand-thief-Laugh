using UnityEngine;


[RequireComponent(typeof(NpcMovement), typeof(NpcColliders), typeof(SpriteRenderer))]
public class NpcActions : MonoBehaviour
{
    private SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    private NpcMovement npcMovement => GetComponent<NpcMovement>();
    private Animator animator => GetComponent<Animator>();

    private NPCSO nPCSO;
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
        SetVelocity(nPCValues.velocity);
        nPCSO = npcSO;
        animator.runtimeAnimatorController = npcSO.animatorController;
    }

    private void SetVelocity(float velocity)
    {
        npcMovement.velocidad = velocity;
    }

    private void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
