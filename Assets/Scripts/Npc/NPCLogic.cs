using UnityEngine;

public class NPCLogic : MovementLogic
{

    public override void Move(Transform transform, Collider2D targetCollider=null)
    {
        Vector3 desplazamiento = -transform.right * speed * Time.fixedDeltaTime;

        rb2d.velocity = new Vector3(desplazamiento.x, rb2d.velocity.y, desplazamiento.z);
    }

    public override void OnTrigger(string tag, GameObject thisGameObject) { }
}
