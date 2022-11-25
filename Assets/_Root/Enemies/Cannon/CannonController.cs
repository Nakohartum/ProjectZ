using System;
using _Root.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Root.Enemies.Cannon
{
    public class CannonController : IExecutable, IDisposable
    {
        private CannonView _cannonView;
        private ICannonModel _cannonModel;
        private ExecutableController _executableController;
        public CannonController(CannonView cannonView, ICannonModel cannonModel, ExecutableController executableController)
        {
            _cannonView = cannonView;
            _cannonModel = cannonModel;
            _executableController = executableController;
            _executableController.AddExecutable(this);
        }

        public void Execute(float deltaTime)
        {
            var objectOnDistance = Vector3.Dot(_cannonView.transform.right, _cannonView.Target.right);
            if (Vector3.Distance(_cannonView.transform.position, _cannonView.Target.position) < _cannonModel.DistanceBetweenObjects)
            {
                var dir = _cannonView.transform.position - _cannonView.Target.position;
                var angle = Vector3.Angle(Vector3.down, dir);
                var axis = Vector3.Cross(Vector3.down, dir);
                _cannonView.transform.rotation = Quaternion.AngleAxis(angle, axis);
                if (_cannonModel.Cooldown <= 0 && objectOnDistance < 0.2f && objectOnDistance > -0.2f)
                {
                    var go = Object.Instantiate(_cannonView.Bullet);
                    Throw(go, _cannonView.transform.position, _cannonView.transform.up * _cannonModel.Power);
                    _cannonModel.SetCooldown(3.0f);
                    Object.Destroy(go.gameObject, 3f);
                }
            }
            else
            {
                _cannonModel.SetCooldown(_cannonModel.Cooldown - Time.deltaTime);
            }
            
        }
        
        private void Throw(Rigidbody2D bullet, Vector3 position, Vector3 velocity)
        {
            bullet.transform.position = position;
            bullet.AddForce(velocity, ForceMode2D.Impulse);
        }

        public void Dispose()
        {
            _executableController.RemoveExecutable(this);
        }
    }
}