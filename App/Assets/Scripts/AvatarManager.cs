using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AvatarManagerScriptableObject", order = 1)]
public class AvatarManagerScriptableObject : ScriptableObject
{
    public Sprite[] avatars;
}
