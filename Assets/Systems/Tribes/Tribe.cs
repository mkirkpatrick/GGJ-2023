using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tribe Data", menuName = "ScriptableObjects/Tribe")]
public class Tribe : ScriptableObject
{
    public string tribeName;
    public string skinColor;
    public string bodyType;
    public string hairType;
    public string eyeColor;

    public Tribe()
    {
        
    }
}

