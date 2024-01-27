﻿using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCSO", menuName = "Nuevo Npc")]
public class NPCSO : ScriptableObject
{
    public Sprite sprite;
    public TypeOfNPC typeOfNPC;
    public AnimatorController animatorController;
}
