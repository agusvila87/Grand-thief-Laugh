using System;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public static GunController instance;

    private CakePool cakePool;

    private void Awake()
    {
        instance = this;
    }
    public void Fire()
    {
        var cake = CakePool.instance.GetCake();

        SetCake(cake);
        //GetCake smth
    }

    private void SetCake(GameObject cake)
    {
        //darle velocidad y esas weas
    }
}
