using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public float velocidad; // Ajusta la velocidad según tus necesidades
    public Vector3 direccion = Vector3.forward; // Dirección en la que se mueve el objeto

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Calcula el desplazamiento basado en la dirección y la velocidad
        Vector3 desplazamiento = direccion.normalized * velocidad * Time.deltaTime;

        // Aplica el desplazamiento al Rigidbody
        rb.velocity = new Vector3(desplazamiento.x, rb.velocity.y, desplazamiento.z);
    }


}
