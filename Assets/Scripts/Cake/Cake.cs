using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Cake : MonoBehaviour
{
    Rigidbody2D rb2d => GetComponent<Rigidbody2D>();

    public ParticleSystem vxfCake;
    public void Move(Vector2 playerVelocity)
    {
        rb2d.velocity = playerVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimiteCake"))
        {
            CakePool.instance.DestroyCakeInmediatly(gameObject);
            return;
        }
        if (collision.TryGetComponent(out NpcActions action))
        {
            //Debug.Log("detecto al npc");
            action.Caked();
            CakePool.instance.DestroyCakeInmediatly(gameObject);
        }
    }
}