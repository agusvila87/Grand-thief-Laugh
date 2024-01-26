using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;
    private Vector2 offSet;

    private Material material;

    private Rigidbody2D playerRigid; 

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        playerRigid = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        if(playerRigid == null) 
        {
            return;
        }
    }

    private void Update()
    {
        if (playerRigid != null) 
        {
            offSet = (playerRigid.velocity.x * 0.1f) * velocidadMovimiento * Time.deltaTime; ;
            material.mainTextureOffset += offSet;
        }
        
    }
}
