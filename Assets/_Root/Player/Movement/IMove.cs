using UnityEngine;
using UnityEngine.InputSystem;

namespace _Root.Player.Movement
{
    public interface IMove
    {
        float Speed { get; }
        float JumpForce { get; }
        void Move(Vector2 direction, float deltaTime);
        void Jump(InputAction.CallbackContext obj);
    }
}