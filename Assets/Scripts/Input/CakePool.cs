using UnityEngine;

public class CakePool : MonoBehaviour
{
    [SerializeField] private GameObject cake;

    public static CakePool instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ObjectPoolingPattern.ObjectPooling.PreLoad(cake, 3);
    }

    public GameObject GetCake() 
    {
        return ObjectPoolingPattern.ObjectPooling.GetObject(cake);
    }
}