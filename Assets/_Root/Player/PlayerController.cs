using _Root;
using _Root.Interfaces;
using _Root.Player.Movement;
using UnityEngine;

namespace Game
{
    public class PlayerController : IExecutable, IFixedExecutable
    {
        private PlayerView _playerView;
        private IPlayerModel _playerModel;
        private Vector2 _moveVector;
        private IMove _move;
        private PlayerInput.PlayerMovementActions _playerMovement;
        private ExecutableController _executableController;
        public PlayerController(IPlayerModel playerModel, PlayerView playerView, IMove move, 
            PlayerInput.PlayerMovementActions playerMovement, ExecutableController executableController)
        {
            this._playerModel = playerModel;
            this._playerView = playerView;
            this._move = move;
            this._playerMovement = playerMovement;
            this._executableController = executableController;
            _playerMovement.Enable();
            _playerMovement.Jump.performed += _move.Jump;
            _executableController.AddExecutable(this);
            _executableController.AddFixedExecutable(this);
        }
        public void Execute(float deltaTime)
        {
            _moveVector = _playerMovement.Movement.ReadValue<Vector2>() * _playerModel.Speed;
        }

        public void FixedExecute(float fixedTime)
        {
            _move.Move(_moveVector, fixedTime);
        }
    }
}