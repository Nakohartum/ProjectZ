using UnityEngine;

namespace _Root.Extensions
{
    public static class PhysicsHelper
    {
        public static void ApplyForceToReachVelocity(Rigidbody2D rigidbody2D, Vector3 velocity, float fixedDeltaTime, float acceleration = 1,
            ForceMode2D forceMode2D = ForceMode2D.Force)
        {
            if (acceleration == 0 || velocity.magnitude == 0)
            {
                return;
            }

            velocity = velocity + velocity.normalized * 0.2f * rigidbody2D.drag;
            var accelerationClamps = rigidbody2D.mass / fixedDeltaTime;
            acceleration = Mathf.Clamp(acceleration, -accelerationClamps, accelerationClamps);
            if (rigidbody2D.velocity.magnitude == 0)
            {
                rigidbody2D.AddForce(velocity * acceleration, forceMode2D);
            }
            else
            {
                var velocityProjectedToTarget = (velocity.normalized * Vector3.Dot(velocity, rigidbody2D.velocity) /
                                                 velocity.magnitude);
                rigidbody2D.AddForce((velocity - velocityProjectedToTarget) * acceleration, forceMode2D);
            }
        }
    }
}