using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightPatrolWalkBehavior : IWalkable
{
    private Rigidbody _rigidbody;
    private Transform _transform;
    private Vector3 _position;
    private float _YRotationAngle;
    private float _speed;
    private float _patrolDistance;
    private float _rotationSpeed;

    private bool _isRotate = false;
    private Vector3 _forward;
    private float initialYRotation;

    public StraightPatrolWalkBehavior(Rigidbody rigidbody, Transform transform, Vector3 position, float YRotationAngle, float patrolDistance, float speed, float rotationSpeed)
    {
        _rigidbody = rigidbody;
        _transform = transform;
        _position = position;
        _YRotationAngle = YRotationAngle;
        _patrolDistance = patrolDistance;
        _speed = speed;
        _rotationSpeed = rotationSpeed;
    }

    public void SetStartWalkPoint()
    {
        _transform.position = _position;
        _transform.eulerAngles = new Vector3(0, _YRotationAngle, 0);

        _forward = _transform.forward;
        Debug.Log(_forward);
        initialYRotation = _transform.eulerAngles.y;
    }

    public void Walk()
    {
        //if (!_isRotate)
        //_forward = _transform.forward;
        //Debug.Log(_transform.forward);
        Vector2 startPoint = new Vector2(_transform.position.x, _transform.position.z);
        Vector2 endPoint = new Vector2(_position.x, _position.z) + new Vector2(_forward.x, _forward.z) * _patrolDistance;

        float distance = Vector2.Distance(startPoint, endPoint);
        //Debug.Log(distance);
        //if (Vector3.Distance(_transform.position, _forward * _patrolDistance) > 0.5f && !_isRotate)

        if (distance > 0.1f && !_isRotate)
        {
            //Vector3 directionToTarget = (_position + _forward * _patrolDistance) - _transform.position;
            //Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            //_transform.rotation = Quaternion.FromToRotation(_transform.position, directionToTarget);
            //_transform.LookAt(new Vector3(endPoint.x, 0, endPoint.y));//(_position + _transform.forward * _patrolDistance, Vector3.up);

            //_transform.LookAt(_transform.position + Quaternion.LookRotation((_position + _forward * _patrolDistance) - _transform.position).eulerAngles, Vector3.up);

            //Vector3 direction = (_position + _forward * _patrolDistance) - _transform.position;
            //direction.y = 0f;
            //Quaternion rotation = Quaternion.LookRotation(direction);
            //_transform.rotation = rotation;

            //float currentRotationAngleY = Mathf.Atan2(transform.forward.x, transform.forward.z) * Mathf.Rad2Deg;

            //_transform.rotation = Quaternion.Euler(targetRotation.x, _transform.rotation.y, targetRotation.z);


            // Calculate the direction from the object to the target point
            //Vector3 targetDirection = (_position + _forward * _patrolDistance) - _transform.position;

            // Remove the y-component to only consider rotation around the y-axis
            //targetDirection.y = 0f;

            // Calculate the desired rotation based on the target direction
            //Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            // Calculate the rotation velocity needed to reach the target rotation
            //Vector3 targetAngularVelocity = targetRotation.eulerAngles - _transform.rotation.eulerAngles;
            //targetAngularVelocity /= Time.fixedDeltaTime;

            // Apply the rotation velocity to the Rigidbody
            //Rigidbody rigidbody = GetComponent<Rigidbody>();
            //_rigidbody.angularVelocity = targetAngularVelocity;

            //initialRotation = _transform.rotation;

            Vector3 direction = (_position + _forward * _patrolDistance) - _transform.position;

            // вычисляем угол между текущей осью y объекта и направлением к точке
            //float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            float currentAngleY = _transform.rotation.eulerAngles.y;
            float targetAngleY = targetRotation.eulerAngles.y;

            // Вычисление разницы углов
            float angle = targetAngleY - currentAngleY;



            // создаем новый Quaternion с вращением только вокруг оси y
            Quaternion rotation = Quaternion.Euler(0f, angle, 0f);

            // устанавливаем вращение объекта, учитывая только ось y и сохраняя остальные оси такими, какими они были изначально
            _transform.rotation = _transform.rotation * rotation;



            _rigidbody.MovePosition(_transform.position + (_transform.forward * _speed * Time.fixedDeltaTime));

            initialYRotation = _transform.eulerAngles.y;
        }
        else
        {
            // Вычисляем текущий угол поворота объекта
            float currentRotation = _transform.eulerAngles.y;

            // Плавно поворачиваем объект на определенное количество градусов
            float newRotation = Mathf.LerpAngle(currentRotation, initialYRotation + 180f, _rotationSpeed * Time.fixedDeltaTime);

            // Устанавливаем новый угол поворота объекта
            _transform.eulerAngles = new Vector3(_transform.eulerAngles.x, newRotation, _transform.eulerAngles.z);


            Debug.Log("kkk");
            _isRotate = true;
            //_transform.forward = Vector3.Lerp(_transform.forward, -_forward, _rotationSpeed);
            float angleDifference = Mathf.DeltaAngle(currentRotation, initialYRotation + 180f);

            Debug.Log(angleDifference);
            //Debug.Log(currentRotation + "  " + (initialYRotation - 180) + "  " + newRotation);

            if (angleDifference > -0.05f && angleDifference < 0.05f)//(currentRotation == initialYRotation + 180f)//(_transform.forward.y == -_forward.y)
            {
                _position = _transform.position;
                _forward = _transform.forward;
                _isRotate = false;
            }
        }

        
        //if (_transform.position > _position + new Vector3())
    }
}
