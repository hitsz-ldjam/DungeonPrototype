using UnityEngine;

namespace ThisGame.Bullet {
    public class BulletAutoDie : MonoBehaviour {
        public readonly float dieTime = 2.5f;

        private void Start() {
            Destroy(gameObject, dieTime);
        }
    }
}
