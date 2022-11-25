using UnityEngine;
using UnityEngine.Events;

namespace _Root.Enemies.Anvil
{
    public class TrapButton : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<Game.PlayerView> OnButtonPushed = new UnityEvent<Game.PlayerView>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnButtonPushed.Invoke(other.GetComponent<Game.PlayerView>());
            gameObject.SetActive(false);
        }
    }
}