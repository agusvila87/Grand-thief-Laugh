using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonQr : MonoBehaviour
{

    public GameObject[] myQr;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PublicQr(GameObject qr)
    {
        for (int i = 0; i < myQr.Length; i++)
        {
            myQr[i].gameObject.SetActive(false);
        }
        qr.SetActive(true);
    }
}
