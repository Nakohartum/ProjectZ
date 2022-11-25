using System;
using UnityEngine;

namespace _Root.Enemies.Cannon
{
    public class CannonView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Bullet {get; private set;}
        [field: SerializeField] public Transform Target {get; private set;}
        [field: SerializeField] public ICannonModel CannonModel { get; private set; }

        public void Init(Transform target, ICannonModel cannonModel)
        {
            Target = target;
            CannonModel = cannonModel;
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, CannonModel.DistanceBetweenObjects);
        }
#endif
    }
}
