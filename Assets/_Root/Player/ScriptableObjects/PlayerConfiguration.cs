using UnityEngine;

namespace Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(PlayerConfiguration), menuName = "Configs/"+nameof(PlayerConfiguration), order = 0)]
    public class PlayerConfiguration : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Acceleration { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
        [field: SerializeField] public PlayerView PlayerPrefab { get; private set; }
    }
}