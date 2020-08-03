using UnityEngine;

namespace ThisGame.Player {
    public class PlayerMove : MonoBehaviour {
        public float moveSpeed = 5f;


        private void Update() {
            // todo: get input in same update & distribute event
            var movm = new Vector2();
            movm.x = Input.GetAxisRaw("Horizontal");
            movm.y = Input.GetAxisRaw("Vertical");
            movm.Normalize();
            movm *= Time.deltaTime * moveSpeed;
            transform.Translate(movm);
        }
    }
}
