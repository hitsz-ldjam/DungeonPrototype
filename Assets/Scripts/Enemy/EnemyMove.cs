using ThisGame.Utils;
using UnityEngine;

namespace ThisGame.Enemy {
    // todo: temp code
    public class EnemyMove : MonoBehaviour {
        public float minMoveSpeed = .8f, maxMoveSpeed = 3f;

        private Transform playerTrans;
        private Rigidbody2D rb;


        //private void Update() {
        //    var delta = playerTrans.position - transform.position;
        //    if(delta.sqrMagnitude < 5.3f)
        //        return;
        //    // todo: smooth move
        //    //delta = Quaternion.AngleAxis(Random.Range(-45f, 45f), Vector3.forward) * delta;
        //    delta.Normalize();
        //    delta *= Random.Range(minMoveSpeed, maxMoveSpeed) * Time.deltaTime;
        //    transform.position += delta;
        //}

        private void FixedUpdate() {
            var delta = (Vector2)playerTrans.position - rb.position;
            if(delta.sqrMagnitude < 4.3f)
                return;
            // todo: smooth move
            //delta = Quaternion.AngleAxis(Random.Range(-45f, 45f), Vector3.forward) * delta;
            delta.Normalize();
            delta *= Random.Range(minMoveSpeed, maxMoveSpeed) * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + delta);
        }


        private void Awake() {
            playerTrans = InSceneObjRef.Instance.Player;
            rb = GetComponent<Rigidbody2D>();
        }
    }
}
