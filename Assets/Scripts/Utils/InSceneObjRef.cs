using UnityEngine;

namespace ThisGame.Utils {
    [DefaultExecutionOrder(-10)]
    public class InSceneObjRef : SingletonManager<InSceneObjRef> {
        [SerializeField] private Transform player;
        [SerializeField] private Camera mainCamera;

        public Transform Player => player;
        public Camera MainCamera => mainCamera;

        private void SuppressUnityWarnings() {
            player = null;
            mainCamera = null;
        }
    }
}
