using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NpcMovement : MonoBehaviour
{
    public float velocidad; // Ajusta la velocidad según tus necesidades

    private Rigidbody2D rb2d => GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        // Calcula el desplazamiento basado en la dirección y la velocidad
        Vector3 desplazamiento = -transform.right * velocidad * Time.fixedDeltaTime;

        // Aplica el desplazamiento al Rigidbody
        rb2d.velocity = new Vector3(desplazamiento.x, rb2d.velocity.y, desplazamiento.z);
    }
}
