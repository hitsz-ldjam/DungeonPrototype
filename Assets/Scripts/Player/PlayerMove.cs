using UnityEngine;

namespace ThisGame.Player {
    public class PlayerMove : MonoBehaviour {
        public float moveSpeed = 5f;

        private Rigidbody2D rb;

        //private void Update() {
        //    // todo: get input in same update & distribute event
        //    var movm = new Vector2 {x = Input.GetAxisRaw("Horizontal"), y = Input.GetAxisRaw("Vertical")};
        //    movm.Normalize();
        //    movm *= Time.deltaTime * moveSpeed;
        //    transform.Translate(movm);
        //}

        private void FixedUpdate() {
            // todo: get input in same update & distribute event
            var movm = new Vector2 { x = Input.GetAxisRaw("Horizontal"), y = Input.GetAxisRaw("Vertical") };
            movm.Normalize();
            movm *= Time.fixedDeltaTime * moveSpeed;
            rb.MovePosition(rb.position + movm);
        }

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
        }
    }
}
