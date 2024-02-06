using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CelularMode : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();

    public void Change() 
    {

        for (int i = 0; i < gameObjects.Count; i++) 
        {
            gameObjects[i].SetActive(!gameObjects[i].activeSelf);
        }

    }
}
