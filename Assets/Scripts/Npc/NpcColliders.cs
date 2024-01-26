using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class NpcColliders : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limites"))
        {
            NpcSpawner.Instance.DeleteNpc(gameObject);
        }
    }
}
