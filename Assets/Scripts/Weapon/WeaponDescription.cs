using ThisGame.Utils;
using UnityEngine;

namespace ThisGame.Weapon {
    [CreateAssetMenu(fileName = "WeaponDescription", menuName = "Weapon/Weapon Description")]
    public class WeaponDescription : ScriptableObject {
        public Sprite onHandSprite;
        public ElementType type;

        // debug code
        public Color bulletTint;

        // todo: id, nameid, name, inventorySprite;
    }
}
