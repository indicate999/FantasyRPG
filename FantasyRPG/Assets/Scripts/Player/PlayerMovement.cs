using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerAnimatorController animatorController;
    [SerializeField] private float speedRotation;
    [SerializeField] private float speed = 5;
    [SerializeField] private float gravity = -9.18f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private Vector3 _direction;
    private Vector2 _vector;
    private float _velocity;
    private bool _isGrounded;

    private void Update()
    {
        _isGrounded = isOnTheGround();

        Move();
        DoGravity();
    }

    private void OnMove(InputValue value)
    {
        _vector = value.Get<Vector2>();

        if (_vector == Vector2.zero)
            animatorController.SetAnimation("Idle");
        else if (_vector.y == 1)
            animatorController.SetAnimation("RunForward");
        else if (_vector.y < 0)
            animatorController.SetAnimation("RunBackward");
        else if(_vector.x > 0.5)
            animatorController.SetAnimation("RunRight");
        else if (_vector.x < 0.5)
            animatorController.SetAnimation("RunLeft");
        
    }

    private void Move()
    {
        if (_vector != Vector2.zero)
        {
            var moveVector = transform.right * _vector.x + transform.forward * _vector.y;
            _direction = moveVector * speed;
            
            characterController.Move(_direction * Time.deltaTime);
        }
    }

    private bool isOnTheGround()
    {
        bool result = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        return result;
    }

    private void DoGravity()
    {
        if (!_isGrounded)
            _velocity += gravity * Time.deltaTime;

        characterController.Move(Vector3.up * _velocity * Time.deltaTime);
    }

    private void OnJump()
    {
        if (_isGrounded)
        {
            _velocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }      
    }
}
