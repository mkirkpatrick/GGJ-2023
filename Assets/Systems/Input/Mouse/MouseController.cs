using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    public static MouseController instance;
    [SerializeField]
    private CameraController cameraController;
    private CursorController cursorController;
    //public TargetingController targetingController;
    private Camera mainCamera;

    public bool isActive;

    public float mouseScrollScale = 2;

    private void Awake()
    {
        instance = this;
        cursorController = GetComponent<CursorController>();
        mainCamera = cameraController.mainCamera;
    }

    void Update()
    {
        if (!isActive)
            return;
        
        //Mouse Scroll
        if (Input.mouseScrollDelta.y != 0)
        {
            cameraController.targetZoom -= Input.mouseScrollDelta.y * mouseScrollScale;
        }
    }
}
