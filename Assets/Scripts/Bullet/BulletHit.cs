using System.Collections.Generic;
using UnityEngine;

namespace ThisGame.Bullet {
    public class BulletHit : MonoBehaviour {
        public LayerMask wallMask;

        private BulletDescription desc;
        private HashSet<BulletModifier> bms;

        public void SetBulletModifiers(HashSet<BulletModifier> modifiers) => bms = modifiers;


        private void StickOn(GameObject other) {
            var collider2d = GetComponent<Collider2D>();
            collider2d.isTrigger = true;
            var rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            rb.isKinematic = true;
            rb.simulated = false;
            transform.SetParent(other.transform);
        }


        private void OnTriggerEnter2D(Collider2D other) {
            var go = other.gameObject;

            //Debug.Log($"{gameObject.name}: OnTriggerEnter2D with {go.name}");

            if(go.CompareTag("Enemy")) {
                if(desc.hitEmeny) {
                    if(bms.Contains(BulletModifier.Nianxing)) {
                        StickOn(go);
                    }
                    else {
                        // todo: hit enemy
                        Destroy(gameObject);
                    }
                }
            }

            else if(go.CompareTag("Wall")) {
                if(bms.Contains(BulletModifier.Fantan)) {
                    const float maxDis = 1f;
                    // magic: local right is forward
                    var d = (Vector2)transform.right;
                    var hit = Physics2D.Raycast(transform.position, d, maxDis, wallMask);
                    if(hit.collider != null) {
                        var n = hit.normal;
                        var r = d - 2 * Vector2.Dot(d, n) * n;
                        //Debug.Log($"{d}; {n}; {r}");
                        var rb = GetComponent<Rigidbody2D>();
                        transform.rotation = Quaternion.FromToRotation(d, r) * transform.rotation;
                        rb.velocity = r * rb.velocity.magnitude;
                    }
                }
                else if(bms.Contains(BulletModifier.Nianxing)) {
                    StickOn(go);
                }
                else {
                    Destroy(gameObject);
                }
            }

            else if(go.CompareTag("Bullet")) {
                // todo
            }

            else if(go.CompareTag("Player")) {
                if(desc.hitPlayer)
                    // todo: hit player
                    Destroy(gameObject);
            }

            //else
            //    // todo
            //    Destroy(gameObject);
        }


        private void Start() {
            desc = GetComponent<BulletDescriptionHolder>().Desc;
        }
    }
}
