using ThisGame.Bullet;
using UnityEngine;

namespace ThisGame.Weapon {
    public class WeaponShoot : MonoBehaviour {
        public GameObject bulletPrefab;
        public Transform bulletGenPoint;

        private WeaponRotate weaponRotate;

        private void Update() {
            // todo: get input in same update & distribute event
            if(Input.GetMouseButtonDown(0)) {
                var bullet = Instantiate(bulletPrefab, bulletGenPoint.position, bulletGenPoint.rotation);
                bullet.GetComponent<BulletMove>().OnShoot(weaponRotate.Forward, 10);
            }
        }

        private void Awake() {
            weaponRotate = GetComponent<WeaponRotate>();
        }
    }
}
