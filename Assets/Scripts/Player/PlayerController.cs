using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private int speed;

    Rigidbody2D rb2d => GetComponent<Rigidbody2D>();
    Animator animator => GetComponent<Animator>();

    public Animator animatorPiernas;


    public AudioSource audioShoot;

    GunCooldown gunCoold;
    private void Awake()
    {
        instance = this;

        //animatorPiernas = GetComponentInChildren<Animator>();
        gunCoold= GetComponentInChildren<GunCooldown>();
    }

    public void Move(Vector2 inputMovement)
    {
        Vector2 movement = inputMovement * speed;

        rb2d.velocity = movement;

        Vector3 vector3;

        if (inputMovement.x > 0)
        {
            vector3 = Vector3.zero;
            transform.rotation = Quaternion.Euler(vector3);
        }
        if (inputMovement.x < 0)
        {
            vector3 = new Vector3(0, -180, 0);
            transform.rotation = Quaternion.Euler(vector3);
        }


        animator.SetBool("IsWalking", inputMovement.magnitude != 0f);
        animatorPiernas.SetBool("IsMoving", animator.GetBool("IsWalking"));
    }

    public void Shoot()
    {
        //Debug.Log(gunCoold.canShoot);

        animator.SetTrigger("ShootT");
        MainCamera.instance.ShakeCamera();
        audioShoot.Play();

        if (gunCoold.canShoot)
        {
            
        }
    }
    void ShootOff()
    {
        animator.SetBool("Shoot", false);
    }
}
