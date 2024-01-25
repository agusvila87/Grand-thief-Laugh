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
    private bool isRight;
    bool isSpriteActive;
    NpcMovement npcMovement;
    float originalSpeed;

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

        originalSpeed = npcMovement.velocidad;

        sprite.SetActive(false);
        Invoke("Spawn", Random.Range(0, 1.5f));

    }


    public void Spawn() 
    {
        if (!isSpriteActive) 
        {
            isSpriteActive = true;
            sprite.SetActive(true);
        }

        if (isRight)
        {

            transform.position = new Vector3(spawnLeft, Random.Range(minY, maxY));
            if (npcMovement != null)
            {
                npcMovement.velocidad = Random.Range(originalSpeed - 15f, originalSpeed + 10f);
                npcMovement.velocidad = Mathf.Abs(npcMovement.velocidad); // Valor positivo
            }
            sprite.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            transform.position = new Vector3(spawnRight, Random.Range(minY, maxY));
            if (npcMovement != null)
            {
                npcMovement.velocidad = Random.Range(originalSpeed - 15f, originalSpeed + 10f);
                npcMovement.velocidad = -Mathf.Abs(npcMovement.velocidad); // Valor negativo
            }
            sprite.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
