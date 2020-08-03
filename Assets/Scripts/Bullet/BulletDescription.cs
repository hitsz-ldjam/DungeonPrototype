using UnityEngine;

namespace ThisGame.Bullet {
    [CreateAssetMenu(fileName = "BulletDescription", menuName = "Bullet/Bullet Description")]
    public class BulletDescription : ScriptableObject {
        public bool hitEmeny, hitPlayer, passWall;
    }
}
