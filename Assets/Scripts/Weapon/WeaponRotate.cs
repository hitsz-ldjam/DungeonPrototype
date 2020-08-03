using ThisGame.Utils;
using UnityEngine;

namespace ThisGame.Weapon {
    /// <summary> add to WeaponHolder </summary>
    public class WeaponRotate : MonoBehaviour {
        public Vector2 Forward => -transform.right;

        private void Update() {
            var lookat = InSceneObjRef.Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            var lookdir = lookat - transform.position;
            lookdir.z = 0;
            if(lookdir.sqrMagnitude < .001f)
                return;
            var quat = Quaternion.FromToRotation(Forward, lookdir);
            transform.rotation = quat * transform.rotation;
        }
    }
}
