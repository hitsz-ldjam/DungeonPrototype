using UnityEngine;

namespace ThisGame.Status {
    // todo: inherit
    public class StatusDescriptionHolder : MonoBehaviour {
        [SerializeField] private StatusDescription desc;

        public StatusDescription Desc { get; set; }

        public int ReqCount { get; set; }

        private void Awake() {
            Desc = desc == null ? null : desc;
            ReqCount = 0;
        }

        private void SuppressUnityWarnings() {
            desc = null;
        }
    }
}
