using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clan Data", menuName = "ScriptableObjects/Clan")]
[System.Serializable]
public class Clan : ScriptableObject
{
    public string clanName;
    [TextArea(12,12)]
    public string description;
}
