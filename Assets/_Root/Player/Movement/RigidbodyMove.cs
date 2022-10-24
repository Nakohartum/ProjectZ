using UnityEngine;
using UnityEngine.InputSystem;

namespace _Root.Player.Movement
{
    public class RigidbodyMove : IMove
    {
        public float Speed { get; }
        public float JumpForce { get; }
        private Rigidbody2D _rigidbody;
        private Vector2 _moveVector;
        

        public RigidbodyMove(Rigidbody2D rigidbody, float speed, float jumpForce)
        {
            _rigidbody = rigidbody;
            Speed = speed;
            JumpForce = jumpForce;
        }
        
        public void Move(Vector2 direction, float deltaTime)
        {
            var speed = Speed * deltaTime;
            _moveVector = direction * speed;
            _moveVector.y = _rigidbody.velocity.y;
            _rigidbody.velocity = _moveVector;
        }

        public void Jump(InputAction.CallbackContext obj)
        {
            Debug.Log("Perfomed");
            _moveVector.y = Mathf.Sqrt(JumpForce * -2 * -9.8f);
        }
    }
}