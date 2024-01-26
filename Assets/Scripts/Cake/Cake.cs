using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Cake : MonoBehaviour
{
    Rigidbody2D rb2d => GetComponent<Rigidbody2D>();
    public void Move(Vector2 playerVelocity)
    {
        rb2d.velocity = playerVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out NpcActions action))
        {
            action.Caked();
            CakePool.instance.DestroyCakeInmediatly(gameObject);
        }
    }
}