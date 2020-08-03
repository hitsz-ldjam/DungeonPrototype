using UnityEngine;

namespace ThisGame.Utils {
    public class SingletonManager<T> : MonoBehaviour where T : SingletonManager<T> {
        public static T Instance { get; private set; }

        protected virtual void OnInstanceAwake() { }

        private void Awake() {
            if(Instance == null) {
                Instance = (T)this;
                OnInstanceAwake();
            }
            else
                Destroy(this);
        }
    }
}
