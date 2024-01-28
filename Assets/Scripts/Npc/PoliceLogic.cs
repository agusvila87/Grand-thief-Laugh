using UnityEngine;

public class PoliceLogic : MovementLogic
{
    public override void Move(Transform transform, Collider2D targetCollider)
    {
        Debug.Log("POLICIAAAAA");
        Vector3 targetPos = targetCollider.bounds.center;
        Vector3 v = (transform.position - targetPos).normalized;

        rb2d.velocity = -v * speed * Time.fixedDeltaTime;
    }

    public override void OnTrigger(string tag, GameObject thisGameObject)
    {
        if (tag == "Player")
        {
            NpcSpawner.Instance.DeleteNpc(thisGameObject);
            GameManager.Instance.ReduceLife();
            MainCamera.instance.ShakeCamera();
            //Hacer particulas
        }
    }
}