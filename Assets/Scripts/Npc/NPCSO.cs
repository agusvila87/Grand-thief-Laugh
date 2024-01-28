using UnityEngine;

[CreateAssetMenu(fileName = "NPCSO", menuName = "Nuevo Npc")]
public class NPCSO : ScriptableObject
{
    public Sprite sprite;
    public TypeOfNPC typeOfNPC;
    public RuntimeAnimatorController animatorController;
    public bool isEnemy;
    public MovementLogic movementLogic;
    [Range(0, 100),
        Tooltip("Asigna un peso al objeto. " +
        "Siendo 0 = 0% de probabilidades y 100 = (100/xCantidadDeObjetos)% de probabilidades máximas.")]
    public int weight;
    [Range(0.1f, 2f)]public float speedMultiplier = 1f;


    public void Initialize()
    {
        movementLogic = isEnemy ? new PoliceLogic() : new NPCLogic();
    }
}