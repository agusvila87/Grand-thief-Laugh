using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanchukeScript : MonoBehaviour
{
    public Transform playerTransform;
    

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.x > gameObject.transform.position.x)
        {
            if (gameObject.transform.rotation != Quaternion.Euler(0, 0, 0))
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

        }
        else 
        {
            if (gameObject.transform.rotation != Quaternion.Euler(0, 180, 0))
            {
                gameObject.transform.rotation = Quaternion.Euler(0,180, 0);
            }
        }
    }
}
