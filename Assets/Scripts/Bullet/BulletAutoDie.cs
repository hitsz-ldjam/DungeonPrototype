using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThisGame.Bullet {
    public class BulletAutoDie : MonoBehaviour {
        public readonly float dieTime = 2f;

        private void Start() {
            Destroy(gameObject, dieTime);
        }
    }
}
