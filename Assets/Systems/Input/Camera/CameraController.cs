using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Camera mainCamera;
    public Transform followObject;

    public bool isActive = false;
    public bool isMoving;
    public float moveSpeed = 15f;
    Vector3 movementVector;
    Vector3 targetPosition;

    //Camera Zoom
    public float minZoom;
    public float maxZoom;
    public float zoomSpeed;
    public float targetZoom;

    void Awake()
    {
        instance = this;
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (!isActive)
            return;

        //Move to target
        if (isMoving == true)
        {
            if (Vector2.Distance(mainCamera.transform.position, targetPosition) < .1f)
            {
                mainCamera.transform.position = targetPosition;
                isMoving = false;
            }
            else
            {
                movementVector = targetPosition - mainCamera.transform.position;
                mainCamera.transform.Translate(movementVector * Time.deltaTime * moveSpeed);
            }
        }
        else
        {
            mainCamera.transform.position = new Vector3(followObject.position.x, followObject.position.y, -10);
        }

        //Zoom camera
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        if (mainCamera.orthographicSize != targetZoom)
        {
            ZoomCamera();
        }
    }

    public void Activate(Transform _follow) {
        isActive = true;
        followObject = _follow;
    }

    public void CenterCamera()
    {
        MoveCameraToTarget(new Vector3(followObject.position.x, followObject.position.y, -10));
    }

    public void MoveCameraToTarget(Vector3 _targetPosition)
    {

        Vector3 newPosition = new Vector3(_targetPosition.x, _targetPosition.y, -10f);

        if (mainCamera.transform.position != newPosition)
        {
            isMoving = true;
            targetPosition = newPosition;
        }
    }

    public void ZoomCamera()
    {
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
        if (Mathf.Abs(targetZoom - mainCamera.orthographicSize) < .1f)
        {
            mainCamera.orthographicSize = targetZoom;
        }
    }
}
