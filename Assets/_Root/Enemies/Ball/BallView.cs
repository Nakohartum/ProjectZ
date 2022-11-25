using System;
using UnityEngine;

namespace _Root.Enemies.Ball
{
    public class BallView : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.gameObject.GetComponent<Game.PlayerView>();
            if (player != null)
            {
                Destroy(player.gameObject);
            }
        }
    }
}