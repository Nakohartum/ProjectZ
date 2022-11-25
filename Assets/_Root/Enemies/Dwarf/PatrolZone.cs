using System;
using UnityEngine;
using UnityEngine.Events;

namespace _Root.Enemies.Dwarf
{
    public class PatrolZone : MonoBehaviour
    {
        public UnityEvent<bool, Transform> OnTriggetEnterAction = new UnityEvent<bool, Transform>();
        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponent<Game.PlayerView>();
            if (player != null)
            {
                OnTriggetEnterAction.Invoke(true, player.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggetEnterAction.Invoke(false, null);
        }
    }
}