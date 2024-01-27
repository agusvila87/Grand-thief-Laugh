using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private int speed;

    Rigidbody2D rb2d => GetComponent<Rigidbody2D>();
    Animator animator => GetComponent<Animator>();

    [SerializeField] private int LifePoints;

    public AudioSource audioShoot;

    MainCamera mainCamera;
    GunCooldown gunCoold;
    private void Awake()
    {
        instance = this;
        mainCamera=FindObjectOfType<MainCamera>();
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
    }

    public void Shoot()
    {
        Debug.Log(gunCoold.canShoot);
        if (gunCoold.canShoot)
        {
            animator.SetBool("Shoot", true);
            mainCamera.ShakeCamera();
            audioShoot.Play();
        }
    }
    void ShootOff()
    {
        animator.SetBool("Shoot", false);
    }
}
