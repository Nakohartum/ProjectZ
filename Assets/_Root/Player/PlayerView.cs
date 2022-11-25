using System;
using System.Collections;
using System.Collections.Generic;
using _Root.Player.Movement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

namespace Game
{
    public class PlayerView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        public IPlayerModel PlayerModel { get; private set; }

        public void Init(IPlayerModel playerModel)
        {
            PlayerModel = playerModel;
        }
    }
}
