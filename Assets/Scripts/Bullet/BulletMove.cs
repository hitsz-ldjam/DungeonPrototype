using UnityEngine;

namespace ThisGame.Bullet {
    public interface IBulletMovable {
        void OnShoot(Vector2 forward, float speed);
    }

    // todo: BulletMoveStraight, BulletMoveFollow, etc
    public class BulletMove : MonoBehaviour, IBulletMovable {
        public void OnShoot(Vector2 forward, float speed) {
            if(forward.sqrMagnitude < .001f)
                return;
            var rb = GetComponentInChildren<Rigidbody2D>();
            forward.Normalize();
            rb.AddForce(forward * speed, ForceMode2D.Impulse);
            // todo: set bullet rotation
        }
    }
}
