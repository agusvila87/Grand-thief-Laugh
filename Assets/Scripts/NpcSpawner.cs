using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> listNpcs = new List<GameObject>();
    private List<NpcActions> listNpcActions = new List<NpcActions>();
    void Start()
    {
        for (int i = 0; i < listNpcs.Count; i++) 
        {
            NpcActions npcActions = listNpcs[i].GetComponent<NpcActions>();
            if (npcActions != null)
            {
                listNpcActions.Add(npcActions);
            }
            else 
            {
                return;
            }

        }
    }

}
