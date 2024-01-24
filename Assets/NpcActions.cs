using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcActions : MonoBehaviour
{
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float spawnLeft;
    [SerializeField] private float spawnRight;
    [SerializeField] GameObject sprite;
    public bool isRight;

    NpcMovement npcMovement;

    void Start()
    {
        int randomValue = Random.Range(0, 2);

        // Convierte el número a un booleano (0 será false, 1 será true)
        isRight = (randomValue == 1);

        // Imprime el valor para verificar
        Debug.Log("Valor de miBool: " + isRight);

        npcMovement = GetComponent<NpcMovement>();
        if (npcMovement == null) 
        {
            return;
        }

        Spawn();


    }


    public void Spawn() 
    {
        if (isRight)
        {
            transform.position = new Vector3(spawnLeft, Random.Range(minY, maxY));
            if (npcMovement != null)
            {
                npcMovement.velocidad = Mathf.Abs(npcMovement.velocidad); // Valor positivo
            }
            sprite.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            transform.position = new Vector3(spawnRight, Random.Range(minY, maxY));
            if (npcMovement != null)
            {
                npcMovement.velocidad = -Mathf.Abs(npcMovement.velocidad); // Valor negativo
            }
            sprite.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
