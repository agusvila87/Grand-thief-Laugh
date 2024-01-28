using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NpcMovement : MonoBehaviour
{
    private MovementLogic logic;
    Collider2D target;
    public void SetLogic(MovementLogic logic, float speed)
    {
        this.logic = logic;
        this.logic.speed = speed;
        logic.rb2d = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        target = PlayerController.instance.gameObject.GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        logic.Move(transform, target);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"ENTRA ALGO: {collision.gameObject.tag}");
        logic.OnTrigger(collision.gameObject.tag, gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"ENTRA ALGO: {collision.gameObject.tag}");
        logic.OnTrigger(collision.gameObject.tag, gameObject);

    }
}