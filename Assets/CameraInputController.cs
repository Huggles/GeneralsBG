using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInputController : MonoBehaviour
{
    [SerializeField]
    int cameraKeyboardMovementSpeed = 10;

    [SerializeField]
    int cameraMouseMovementSpeed = 20;

    [SerializeField]
    int cameraZoomSpeed = 3;

    Camera componentCamera;
    // Start is called before the first frame update
    void Start()
    {
        componentCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateKeyboardMovement();
        UpdateMouseMovement();
        UpdateZoom();
    }
    void UpdateKeyboardMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        UpdateCameraPosition(horizontalInput * cameraKeyboardMovementSpeed, verticalInput * cameraKeyboardMovementSpeed);
    }
    void UpdateMouseMovement()
    {
        if (Input.GetMouseButton(0))
        {
            float horizontalInput = Input.GetAxis("Mouse X");
            float verticalInput = Input.GetAxis("Mouse Y");
            if (horizontalInput > 0) horizontalInput = 1f;
            if (horizontalInput < 0) horizontalInput = -1f;
            if (verticalInput > 0) verticalInput = 1f;
            if (verticalInput < 0) verticalInput = -1f;
            UpdateCameraPosition(-horizontalInput * cameraMouseMovementSpeed, -verticalInput * cameraMouseMovementSpeed);
        }
    }
    void UpdateCameraPosition(float deltaX, float deltaY)
    {
        Bounds boundaries = World.Instance.WorldBoundaries();
        componentCamera.transform.position += (new Vector3(deltaX, deltaY, 0) * Time.deltaTime);
        componentCamera.transform.position = new Vector3(
            Mathf.Clamp(componentCamera.transform.position.x, boundaries.min.x, boundaries.max.x),
            Mathf.Clamp(componentCamera.transform.position.y, boundaries.min.y, boundaries.max.y),
            componentCamera.transform.position.z
            );
    }
    void UpdateZoom()
    {
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        componentCamera.orthographicSize += zoomInput * cameraZoomSpeed;
    }
}

