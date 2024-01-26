using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcColliders : MonoBehaviour
{
    NpcActions npcActions;

    private void Start()
    {
        npcActions = GetComponent<NpcActions>();
        if (npcActions == null) 
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limites"))
        {

            if (npcActions != null) 
            {
                npcActions.Spawn();
            }

        }

        if (collision.CompareTag("Proyectil")) 
        {
            npcActions.Caked();
            Debug.Log("Se disparo al player");
        }
    }
}
