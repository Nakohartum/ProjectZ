using System.Collections;
using System.Collections.Generic;
using _Root.Player.Movement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Vector2 _moveVector;
    private IMove _move;
    private PlayerInput.PlayerMovementActions _playerMovement;
    
    void Start()
    {
        var playerInput = new PlayerInput();
        _move = new RigidbodyMove(_rigidbody, _speed, _jumpForce);
        _playerMovement = playerInput.PlayerMovement;
        _playerMovement.Enable();
        _playerMovement.Jump.performed += _move.Jump;
    }

   
    void Update()
    {
        _move.Move(_playerMovement.Movement.ReadValue<Vector2>(), Time.fixedDeltaTime);
    }
}
