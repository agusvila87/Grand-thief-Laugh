using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Cake : MonoBehaviour
{
    Rigidbody2D rb2d => GetComponent<Rigidbody2D>();
    public void Move(Vector2 playerVelocity)
    {
        rb2d.velocity = playerVelocity;
      //  rb2d.AddForce(playerVelocity);
    }
}