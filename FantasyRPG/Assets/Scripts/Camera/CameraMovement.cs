using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private CameraData cameraData; 

    private float _distance;
    private float currentX = 0.0f; 
    private float currentY = 0.0f; 

    private void Start()
    {
        _distance = cameraData.StartDistance;
    }

    private void LateUpdate()
    {
        AttachToTarget();
    }

    private void AttachToTarget()
    {
        transform.position = target.position + new Vector3(0, cameraData.OffsetY, 0) - transform.forward * _distance;
    }

    private void OnRotate(InputValue value)
    {
        
        Vector2 rotationValue = value.Get<Vector2>();

        float mouseX = rotationValue.x * cameraData.Sensitivity;
        float mouseY = rotationValue.y * cameraData.Sensitivity;

        currentX += mouseX;
        currentY -= mouseY;

        currentY = Mathf.Clamp(currentY, cameraData.MinYAngle, cameraData.MaxYAngle);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.rotation = rotation;

        RotateTarget();
    }

    private void RotateTarget()
    {
        target.forward = new Vector3(transform.forward.x, target.forward.y, transform.forward.z);
    }

    private void OnChangeZoom(InputValue value)
    {
        float zoomValue = value.Get<float>();
        
        _distance = _distance + (zoomValue * cameraData.ZoomScale);

        _distance = Mathf.Clamp(_distance, cameraData.MinDistance, cameraData.MaxDistance);
    }

}

