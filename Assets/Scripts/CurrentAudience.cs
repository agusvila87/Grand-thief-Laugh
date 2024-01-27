using UnityEngine;

[CreateAssetMenu(fileName = "Audience", menuName = "Nueva audiencia")]
public class CurrentAudience : ScriptableObject
{
    [System.Serializable]
    public class AudienceSprites
    {
        public Sprite idleAudience;
        public Sprite happyAudience;
        public Sprite angryAudience;
    }
    
    public AudienceSprites audienceSprites;

    public TypeOfNPC typeObjective;

    public int scoreGiven;
    public int scoreTaken;
}