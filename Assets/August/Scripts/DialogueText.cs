using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueText : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] sentences;

}
