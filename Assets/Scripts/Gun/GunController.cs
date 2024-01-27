using UnityEngine;

[RequireComponent(typeof(GunCooldown))]
public class GunController : MonoBehaviour
{
    public static GunController instance;
    [SerializeField] private Transform bead;

    [SerializeField, Range(10f, 100f)] private int velocity = 50;

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
        gunCooldown.RestartTimer();
    }

    private void SetCake(GameObject cakeGO)
    {
        cakeGO.transform.SetPositionAndRotation(bead.transform.position, bead.transform.rotation);
        cakeGO.GetComponent<Cake>().Move(bead.right * velocity);
    }
}

public enum GameState
{
    Menu, Playing, Lose
}