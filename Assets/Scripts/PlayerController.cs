using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private int speed;

    private void Awake()
    {
        instance = this;
    }

    public void Move(Vector2 inputMovement)
    {
        Vector2 movement = inputMovement * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
