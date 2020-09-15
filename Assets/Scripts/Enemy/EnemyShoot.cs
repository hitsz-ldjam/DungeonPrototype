using System.Collections;
using ThisGame.Bullet;
using ThisGame.Utils;
using UnityEngine;

namespace ThisGame.Enemy {
    // todo: temp code
    public class EnemyShoot : MonoBehaviour {
        public float fireColdDown = 1f;
        public GameObject bulletPrefab;

        private Transform playerTrans;

        // todo

        //private IEnumerator OnFire() {
        //    while(true) {
        //        yield return new WaitForSeconds(fireColdDown);
        //        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        //        bullet.GetComponent<BulletMove>().OnShoot(playerTrans.position - transform.position, 7);
        //    }
        //}


        //private void Start() {
        //    StartCoroutine(OnFire());
        //}


        //private void Awake() {
        //    playerTrans = InSceneObjRef.Instance.Player;
        //}
    }
}
