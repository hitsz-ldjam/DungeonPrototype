using ThisGame.Player;
using ThisGame.Status;
using UnityEngine;

namespace ThisGame.EleRegion {
    public class OnEnterEleRegion : MonoBehaviour {
        // todo: set icon in script
        public StatusDescription statusDesc;

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.CompareTag("Player")) {
                var ps = other.gameObject.GetComponent<PlayerStatus>();
                ps.AddStatus(statusDesc);
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if(other.gameObject.CompareTag("Player")) {
                var ps = other.gameObject.GetComponent<PlayerStatus>();
                ps.RemoveStatus(statusDesc);
            }
        }
    }
}
