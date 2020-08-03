using UnityEngine;

namespace ThisGame.Bullet {
    public class BulletDescriptionHolder : MonoBehaviour {
        [SerializeField] private BulletDescription desc;

        public BulletDescription Desc { get; set; }

        private void Awake() {
            Desc = desc == null ? null : desc;
        }

        private void SuppressUnityWarnings() {
            desc = null;
        }
    }
}
