using UnityEngine;

[RequireComponent(typeof(GunCooldown))]
public class GunController : MonoBehaviour
{
    public static GunController instance;
    [SerializeField] private Transform bead;

    [SerializeField] private int velocity;
    private Vector3 cakeVelocity => PlayerController.instance.gameObject.GetComponent<Rigidbody2D>().velocity;


    GunCooldown gunCooldown => GetComponent<GunCooldown>();

    private void Awake()
    {
        instance = this;
    }
    public void Fire()
    {
        if (!gunCooldown.canShoot) return;

        GameObject cake = CakePool.instance.GetCake();

        SetCake(cake);

        CakePool.instance.DestroyCake(cake);

        gunCooldown.RestartTimer();
    }

    private void SetCake(GameObject cakeGO)
    {
        cakeGO.transform.SetPositionAndRotation(bead.position, bead.rotation);

        cakeGO.GetComponent<Cake>().Move(NormalizedVelocity() + Vector2.right * velocity);
    }

    private Vector2 NormalizedVelocity()
    {
        float x = Mathf.Max(0, cakeVelocity.x);

        Vector2 result = new Vector2(x, 0);
        return result;
    }
}

public enum GameState
{
    Menu, Playing, Lose
}