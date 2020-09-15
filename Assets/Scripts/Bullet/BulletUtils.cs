using System.Collections.Generic;
using ThisGame.Weapon;
using UI;
using UnityEngine;

namespace ThisGame.Bullet {
    public static class BulletUtils {
        public static BulletMove ShootBullet(GameObject bulletPrefab,
                                             Transform bulletGenPoint,
                                             Vector2 forward,
                                             WeaponDescription currWeapon,
                                             HashSet<BulletModifier> overrideModifiers = null) {
            var bullet = GameObject.Instantiate(bulletPrefab, bulletGenPoint.position, bulletGenPoint.rotation);
            SetDebugTint(bullet, currWeapon.bulletTint);

            var bulletMove = bullet.GetComponent<BulletMove>();
            bulletMove.SetBulletModifiers(overrideModifiers ?? BulletModifierUI.Instance.BulletModifiers);
            bulletMove.OnShoot(forward, 10, currWeapon);

            return bulletMove;
        }

        public static void SetDebugTint(GameObject bullet, Color color) {
            bullet.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
        }
    }
}
