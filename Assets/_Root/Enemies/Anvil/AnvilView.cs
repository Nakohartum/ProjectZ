using System;
using UnityEngine;

namespace _Root.Enemies.Anvil
{
    public class AnvilView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private TrapButton _trapButton;
        private Game.PlayerView _target;
        private void Start()
        {
            _rigidbody.isKinematic = true;
            _trapButton.OnButtonPushed.AddListener(ActivateTrap);
        }

        private void ActivateTrap(Game.PlayerView arg0)
        {
            _target = arg0;
            if (_target != null)
            {
                _rigidbody.isKinematic = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(_target.gameObject);
        }
    }
}