using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static InputController instance;

    [SerializeField] private MouseController mouseController;
    [SerializeField] private CursorController cursorController;

    //Input Actions
    #region
    public PlayerInput playerInput;

    //Mouse
    public InputAction mouse1;
    public InputAction mouse2;
    public InputAction mouseScroll;

    #endregion

    private void Awake()
    {
        instance = this;
        playerInput = GetComponent<PlayerInput>();

        mouse1 = playerInput.actions["Mouse1"];
        mouse2 = playerInput.actions["Mouse2"];
        mouseScroll = playerInput.actions["MouseScroll"];

    }
}
