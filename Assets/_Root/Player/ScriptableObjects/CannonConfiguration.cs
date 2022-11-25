using _Root.Enemies.Cannon;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = nameof(CannonConfiguration), menuName = "Configs/"+nameof(CannonConfiguration))]
    public class CannonConfiguration : ScriptableObject
    {
        [field: SerializeField] public CannonView CannonPrefab { get; private set; }
        [field: SerializeField] public float Power { get; private set; }
        [field: SerializeField] public float DistanceBetweenObjects { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
    }
}