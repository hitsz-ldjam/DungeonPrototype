using UnityEngine;

namespace ThisGame.Utils {
    [DefaultExecutionOrder(-10)]
    public class InSceneObjRef : SingletonManager<InSceneObjRef> {
        [SerializeField] private Transform player;
        [SerializeField] private Camera mainCamera;

        // todo: proxy through EnemyManager
        [SerializeField] private Transform closestEnemy;

        public Transform Player => player;
        public Camera MainCamera => mainCamera;
        public Transform ClosestEnemy => closestEnemy;

        private void SuppressUnityWarnings() {
            player = null;
            mainCamera = null;
            closestEnemy = null;
        }
    }
}
