using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CursorState { Default, Brackets }

public class CursorController : MonoBehaviour
{
    public static CursorController instance;
    
    public Texture2D defaultCursor, brackets;

    private void Awake()
    {
        instance = this;
        SetCursor(CursorState.Default);
    }

    public void SetCursor(CursorState _state) {
        switch (_state) {
            case CursorState.Default:
                Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
                return;
            case CursorState.Brackets:
                Cursor.SetCursor(brackets, new Vector2(brackets.width/2, brackets.height/2), CursorMode.Auto);
                return;
        }
            
    }
}
