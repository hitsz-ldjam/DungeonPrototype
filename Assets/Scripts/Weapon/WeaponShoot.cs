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
                var bullet = Instantiate(bulletPrefab, bulletGenPoint.position, bulletGenPoint.rotation);
                bullet.GetComponent<BulletMove>().OnShoot(weaponRotate.Forward, 10);

                var currWeapon = weaponChange.GetCurrWeapon;
                bullet.transform.GetChild(0).GetComponent<SpriteRenderer>().color = currWeapon.bulletTint;
            }
        }

        private void Awake() {
            weaponRotate = GetComponent<WeaponRotate>();
            weaponChange = GetComponent<WeaponChange>();
        }
    }
}
