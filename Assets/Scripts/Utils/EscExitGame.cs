using UnityEngine;

namespace ThisGame.Utils {
    public class EscExitGame : MonoBehaviour {
        private void Update() {
            if(Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
}
