using ThisGame.Bullet;
using UnityEngine;

namespace ThisGame.Weapon {
    public class WeaponShoot : MonoBehaviour {
        public GameObject bulletPrefab;
        public Transform bulletGenPoint;

        private WeaponRotate weaponRotate;
        private WeaponChange weaponChange;

        private void Update() {
            // todo: get input in same update & distribute event
            if(Input.GetMouseButtonDown(0)) {
                BulletUtils.ShootBullet(bulletPrefab,
                                        bulletGenPoint,
                                        weaponRotate.Forward,
                                        weaponChange.GetCurrWeapon);
            }
        }

        private void Awake() {
            weaponRotate = GetComponent<WeaponRotate>();
            weaponChange = GetComponent<WeaponChange>();
        }
    }
}
