using ObjectPoolingPattern;
using System.Collections;
using UnityEngine;

public class CakePool : MonoBehaviour
{
    [SerializeField] private GameObject cakeGO;

    public static CakePool instance;

    private WaitForSeconds wait;

    [SerializeField] private float seconds;
    private void Awake()
    {
        wait = new WaitForSeconds(seconds);
        instance = this;
    }

    private void Start()
    {
        ObjectPooling.PreLoad(cakeGO, 6);
    }

    public GameObject GetCake() 
    {
        return ObjectPooling.GetObject(cakeGO);
    }
   
    public void DestroyCakeInmediatly(GameObject cake)
    {
        ObjectPooling.RecicleObject(cakeGO, cake);
        Debug.Log("SE DESACTIVA INMEDIATAMENTE");
    }
}