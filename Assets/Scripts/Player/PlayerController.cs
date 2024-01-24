using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private int speed;

    Rigidbody2D rb2d => GetComponent<Rigidbody2D>();

    private void Awake()
    {
        instance = this;
    }

    public void Move(Vector2 inputMovement)
    {
        Vector2 movement = inputMovement * speed;
       
        rb2d.velocity = movement;
    }
}
