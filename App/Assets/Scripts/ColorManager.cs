using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ColorManagerScriptableObject", order = 2)]
public class ColorManagerScriptableObject : ScriptableObject
{
    public Color[] primaryColorCodes;
    public Color[] secondaryColorCodes;
}
