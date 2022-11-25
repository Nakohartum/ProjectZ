using Game;
using UnityEngine;

namespace _Root.Enemies.Cannon
{
    public class CannonFactory
    {
        public CannonView CannonView { get; private set; }
        public ICannonModel CannonModel { get; private set; }
        public CannonController CannonController { get; private set; }
        private Transform _target;
        private CannonConfiguration _cannonConfiguration;
        private ExecutableController _executableController;

        public CannonFactory(Transform target, CannonConfiguration cannonConfiguration, ExecutableController executableController)
        {
            _target = target;
            _cannonConfiguration = cannonConfiguration;
            _executableController = executableController;
        }
        
        public CannonController CreateCannon()
        {
            CannonModel = new CannonModel(_cannonConfiguration.Power, _cannonConfiguration.DistanceBetweenObjects,
                _cannonConfiguration.Cooldown);
            CannonView = Object.Instantiate(_cannonConfiguration.CannonPrefab);
            CannonView.Init(_target, CannonModel);
            CannonController = new CannonController(CannonView, CannonModel, _executableController);
            return CannonController;
        }
    }
}