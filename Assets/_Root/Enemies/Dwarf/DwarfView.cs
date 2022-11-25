using System;
using _Root.Player.Movement;
using UnityEngine;


namespace _Root.Enemies.Dwarf
{
    public class DwarfView : MonoBehaviour
    {
        [SerializeField] private float _acceleration;
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform[] _patrolPoints;
        [SerializeField] private PatrolZone _patrolZone;
        private Vector2 _direction;
        private IMove _physicsMove;
        private int _currentPoint;
        private bool _playerInZone;
        private Transform _playerTransform;
        private void Start()
        {
            _physicsMove = new RigidbodyMove(_rigidbody, _speed, 0.0f, _acceleration);
            _currentPoint = 0;
            _direction = (Vector2)_patrolPoints[_currentPoint].position - _rigidbody.position;
            _patrolZone.OnTriggetEnterAction.AddListener(ChasePlayer);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var player = other.gameObject.GetComponent<Game.PlayerView>();
            if (player != null)
            {
                Destroy(player.gameObject);
            }
        }

        private void ChasePlayer(bool arg0, Transform arg1)
        {
            _playerInZone = arg0;
            _playerTransform = arg1;
        }


        private void Update()
        {
            if (_playerInZone)
            {
                _direction = (Vector2)_playerTransform.position - _rigidbody.position;
            }
            else
            {
                _direction = (Vector2)_patrolPoints[_currentPoint].position - _rigidbody.position;
                if (Vector2.Distance(_rigidbody.position, _patrolPoints[_currentPoint].position) < 0.5f)
                { 
                    _currentPoint = ++_currentPoint % _patrolPoints.Length;
                    _direction = (Vector2)_patrolPoints[_currentPoint].position - _rigidbody.position;
                }
            }
            if (_direction.x < 0)
            {
                _direction.x = -1;
                _direction.y = 0;
            }
            else
            {
                _direction.x = 1;
                _direction.y = 0;
            }
            
        }

        private void FixedUpdate()
        {
            _physicsMove.Move(_direction, Time.deltaTime);
        }
    }
}