using ThisGame.Utils;
using UnityEngine;

namespace ThisGame.Enemy {
    // todo: temp code
    public class EnemyMove : MonoBehaviour {
        public float minMoveSpeed = .5f, maxMoveSpeed = 2f;
       
        private Transform playerTrans;


        private void Update() {
            var delta = playerTrans.position - transform.position;
            if(delta.sqrMagnitude < 5.3f)
                return;
            // todo: smooth move
            //delta = Quaternion.AngleAxis(Random.Range(-45f, 45f), Vector3.forward) * delta;
            delta.Normalize();
            delta *= Random.Range(minMoveSpeed, maxMoveSpeed) * Time.deltaTime;
            transform.position += delta;
        }


        private void Awake() {
            playerTrans = InSceneObjRef.Instance.Player;
        }
    }
}
