using System.Collections.Generic;
using ThisGame.Weapon;
using UnityEngine;

namespace ThisGame.Bullet {
    public interface IBulletMovable {
        void OnShoot(Vector2 forward, float speed, WeaponDescription weapon);
        void SetBulletModifiers(IReadOnlyCollection<BulletModifier> modifiers);
    }

    // todo: BulletMoveStraight, BulletMoveFollow, etc
    public class BulletMove : MonoBehaviour, IBulletMovable {
        public BulletHit bulletHit;
        public SpriteRenderer bulletSprite;

        private Rigidbody2D rb;
        private bool hasShot;
        private HashSet<BulletModifier> bms;

        public void SetBulletModifiers(IReadOnlyCollection<BulletModifier> modifiers) {
            bms = modifiers.CopyValue();
            bulletHit.SetBulletModifiers(bms);
        }

        public void OnShoot(Vector2 forward, float speed, WeaponDescription weapon) {
            // suppress unity warnings
            // todo: reserve for other use
            if(hasShot)
                return;
            hasShot = true;

            if(forward.sqrMagnitude < .001f)
                return;

            forward.Normalize();
            // local right is pointing at forward(param)
            rb.AddForce(forward * speed, ForceMode2D.Impulse);
            // todo: set ui rotation

            // todo: use SO
            if(bms.Remove(BulletModifier.Xiandan)) {
                const int shotnum = 5;
                const float spreadDeg = 15;
                for(var i = 0; i < shotnum; ++i) {
                    var rot = Quaternion.AngleAxis(Random.Range(-spreadDeg, spreadDeg), Vector3.forward);
                    BulletUtils.ShootBullet(gameObject,
                                            transform,
                                            rot * forward,
                                            weapon,
                                            bms);
                }
            }
        }

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
            hasShot = false;
        }
    }
}
