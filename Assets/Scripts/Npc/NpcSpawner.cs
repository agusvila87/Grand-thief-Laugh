using UnityEngine;
using ObjectPoolingPattern;
using Random = UnityEngine.Random;
using System;
using System.Collections;

public class NpcSpawner : MonoBehaviour
{
    [SerializeField] private float minY, maxY;
    [SerializeField] private float spawnLeft, spawnRight;
    [SerializeField] private float minSpeed, maxSpeed;
    [SerializeField] private int spawnAmount;
    [SerializeField] private GameObject npcGO;

    public static NpcSpawner Instance;

    private WaitForSeconds wait = new WaitForSeconds(1f);

    [SerializeField] private NPCSO[] npcSos;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ObjectPooling.PreLoad(npcGO, spawnAmount);

        for (int i = 0; i < spawnAmount; i++)
        {
            SpawnNPC();
        }
    }

    private void SpawnNPC()
    {
        GameObject npc = ObjectPooling.GetObject(npcGO);
        npc.GetComponent<NpcActions>().SetNPC(GetNPCValues(), GetNPCSO());
    }

    private NPCSO GetNPCSO()
    {
        return npcSos[Random.Range(0, npcSos.Length)];
    }

    private NPCValues GetNPCValues()
    {
        float spawn = Random.value > 0.5f ? spawnLeft : spawnRight;

        Vector2 vector = new Vector2(spawn, Random.Range(minY, maxY));
        float velocity = Random.Range(minSpeed, maxSpeed);
        Quaternion rotation = spawn == spawnRight ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);

        return new NPCValues(vector, velocity, rotation);
    }

    public void DeleteNpc(GameObject npc)
    {
        ObjectPooling.RecicleObject(npcGO, npc);
        StartCoroutine(SpawnNewNPC());
    }
    private IEnumerator SpawnNewNPC()
    {
        yield return wait;
        SpawnNPC();
    }
}
public enum TypeOfNPC
{
    Tipo1, Tipo2, Tipo3, Tipo4
}
public class NPCValues
{
    public Vector2 spawnPos;
    public float velocity;
    public Quaternion rotation;

    public NPCValues(Vector2 spawnPos, float velocity, Quaternion rotation)
    {
        this.spawnPos = spawnPos;
        this.velocity = velocity;
        this.rotation = rotation;
    }
}