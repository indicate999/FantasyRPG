using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target; 
    [SerializeField] private float zoomScale = 1.5f;
    [SerializeField] private float offsetY = 1f;
    [SerializeField] private float startDistance = 6.0f;
    [SerializeField] private float minDistance = 3.0f;
    [SerializeField] private float maxDistance = 17.0f;
    [SerializeField] private float sensitivity = 2.0f; 
    [SerializeField] private float minYAngle = -20.0f;
    [SerializeField] private float maxYAngle = 80.0f; 

    private float _distance;
    private float currentX = 0.0f; 
    private float currentY = 0.0f; 

    private void Start()
    {
        _distance = startDistance;
    }

    private void Update()
    {
        AttachToTarget();
    }

    private void AttachToTarget()
    {
        transform.position = target.position + new Vector3(0, offsetY, 0) - transform.forward * _distance;
    }

    private void OnRotate(InputValue value)
    {
        
        Vector2 rotationValue = value.Get<Vector2>();

        float mouseX = rotationValue.x * sensitivity;
        float mouseY = rotationValue.y * sensitivity;

        currentX += mouseX;
        currentY -= mouseY;

        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);

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
        
        _distance = _distance + (zoomValue * zoomScale);

        _distance = Mathf.Clamp(_distance, minDistance, maxDistance);
    }

}

