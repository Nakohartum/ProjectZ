using _Root;
using _Root.Player.Movement;
using Game.ScriptableObjects;
using UnityEngine;

namespace Game.PlayerFactory
{
    public class PlayerFactory
    {
        private PlayerConfiguration _playerConfiguration;
        private readonly PlayerInput.PlayerMovementActions _playerMovementActions;
        private readonly ExecutableController _executableController;
        public PlayerView PlayerView { get; private set; }
        public IPlayerModel PlayerModel { get; private set; }
        private PlayerController _playerController;

        public PlayerFactory(PlayerConfiguration playerConfiguration, 
            PlayerInput.PlayerMovementActions playerMovementActions, ExecutableController executableController)
        {
            this._playerConfiguration = playerConfiguration;
            _playerMovementActions = playerMovementActions;
            _executableController = executableController;
        }

        public PlayerController CreatePlayer()
        {
            PlayerView = Object.Instantiate(_playerConfiguration.PlayerPrefab);
            PlayerModel = new PlayerModel(_playerConfiguration.Speed, _playerConfiguration.Acceleration,
                _playerConfiguration.JumpForce);
            PlayerView.Init(PlayerModel);
            var move = new RigidbodyMove(PlayerView.Rigidbody, PlayerModel.Speed, PlayerModel.JumpForce,
                PlayerModel.Acceleration);
            _playerController = new PlayerController(PlayerModel, PlayerView, move, _playerMovementActions, _executableController);
            return _playerController;
        }
    }
}