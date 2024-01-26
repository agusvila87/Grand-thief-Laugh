using UnityEngine;

[CreateAssetMenu(fileName = "Audience", menuName = "Nueva audiencia")]
public class CurrentAudience : ScriptableObject
{
    public Sprite sprite;
    public TypeOfNPC typeObjective;
    public int scoreGiven;
    public int scoreTaken;
}