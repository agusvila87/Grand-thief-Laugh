using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Cake : MonoBehaviour
{
    Rigidbody2D rb2d => GetComponent<Rigidbody2D>();
    public void Move(Vector2 playerVelocity)
    {
        rb2d.velocity = playerVelocity + Vector2.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<NpcActions>()) 
        {
            NpcActions action = collision.GetComponent<NpcActions>();

            if (action != null) 
            {
                string npcCode = action.npcCode;
            }

            gameObject.SetActive(false);

        }
    }
}