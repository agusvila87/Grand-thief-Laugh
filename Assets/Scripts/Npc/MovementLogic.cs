using UnityEngine;

[System.Serializable]
public abstract class MovementLogic
{
    public float speed;

    public Rigidbody2D rb2d;

    public abstract void Move(Transform transform, Collider2D targetCollider=null);
    public abstract void OnTrigger(string tag, GameObject thisGameObject);
}
