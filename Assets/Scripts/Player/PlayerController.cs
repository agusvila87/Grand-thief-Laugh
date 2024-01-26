using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private int speed;

    Rigidbody2D rb2d => GetComponent<Rigidbody2D>();
    Animator animator => GetComponent<Animator>();


    private void Awake()
    {
        instance = this;
    }

    public void Move(Vector2 inputMovement)
    {
        Vector2 movement = inputMovement * speed;

        rb2d.velocity = movement;
        if(inputMovement.x < 0)
        {
            Vector3 vector3 = new Vector3(0, -180, 0);
            Quaternion rotation = Quaternion.Euler(vector3);
            transform.rotation = rotation;
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(Vector3.zero);
            transform.rotation = rotation;
        }
        animator.SetBool("IsWalking", inputMovement.magnitude != 0f);
    }
}
