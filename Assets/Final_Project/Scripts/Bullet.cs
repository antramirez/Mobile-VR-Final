using UnityEngine;
using System.Collections;

namespace A08dkg3
{
    public class Bullet : MonoBehaviour
    {
        // this script detects bullet collisions with the enemies or players and
        // removes 10 points of health if an enemy or player gets hit

        void OnCollisionEnter(Collision collision)
        {
            var hit = collision.gameObject;
            var health = hit.GetComponent<Health>();
            if (health != null)
            {
                // remove 10 points of health
                health.TakeDamage(10);
            }
            // destroy the bullet after a collision
            Destroy(gameObject);
        }
    }
}