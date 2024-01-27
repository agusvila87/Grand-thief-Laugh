using ObjectPoolingPattern;
using System.Collections;
using UnityEngine;

public class CakePool : MonoBehaviour
{
    [SerializeField] private GameObject cakeGO;

    public static CakePool instance;

    private WaitForSeconds wait;

    [SerializeField] private int seconds;
    private void Awake()
    {
        wait = new WaitForSeconds(seconds);
        instance = this;
    }
    private void Start()
    {
        ObjectPooling.PreLoad(cakeGO, 3);
    }

    public GameObject GetCake() 
    {
        return ObjectPooling.GetObject(cakeGO);
    }

    public void DestroyCake(GameObject cake)
    {
        StartCoroutine(RecicleCake(cake));
    }
    public void DestroyCakeInmediatly(GameObject cake)
    {
        StopCoroutine(RecicleCake(cake));
        ObjectPooling.RecicleObject(cakeGO, cake);
    }

    private IEnumerator RecicleCake(GameObject cake)
    {
        yield return wait;

        ObjectPooling.RecicleObject(cakeGO, cake);
    }
}