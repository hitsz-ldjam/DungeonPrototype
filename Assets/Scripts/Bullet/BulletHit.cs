using UnityEngine;

namespace ThisGame.Bullet {
    public class BulletHit : MonoBehaviour {
        private BulletDescription desc;

        private void OnTriggerEnter2D(Collider2D other) {
            var go = other.gameObject;

            if(go.CompareTag("Enemy")) {
                if(desc.hitEmeny)
                    // todo: hit enemy
                    Destroy(gameObject);
            }

            else if(go.CompareTag("Wall")) {
                if(!desc.passWall)
                    Destroy(gameObject);
            }

            else if(go.CompareTag("Bound"))
                Destroy(gameObject);

            else if(go.CompareTag("Bullet")) {
                // todo
            }

            else if(go.CompareTag("Player")) {
                if(desc.hitPlayer)
                    // todo: hit enemy
                    Destroy(gameObject);
            }

            else
                // todo
                Destroy(gameObject);
        }

        private void Start() {
            desc = GetComponent<BulletDescriptionHolder>().Desc;
        }
    }
}
