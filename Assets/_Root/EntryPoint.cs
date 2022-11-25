using System;
using _Root.Enemies.Cannon;
using Game;
using Game.ScriptableObjects;
using UnityEngine;

namespace _Root
{
    public class EntryPoint : MonoBehaviour
    {
        private ExecutableController _executableController;
        private InitializeController _initializeController;
        [field: SerializeField] public CannonConfiguration CannonConfiguration {get; private set; }
        [field: SerializeField] public PlayerConfiguration PlayerConfiguration { get; private set; }

        private void Awake()
        {
            _executableController = new ExecutableController();
            _initializeController = new InitializeController(this, _executableController);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _executableController.Execute(deltaTime);
        }

        private void FixedUpdate()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            _executableController.FixedExecute(fixedDeltaTime);
        }
    }
}