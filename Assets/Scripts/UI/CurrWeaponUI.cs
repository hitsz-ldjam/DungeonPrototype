using ThisGame.Weapon;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class CurrWeaponUI : MonoBehaviour {
        public Image weaponImage;
        public WeaponChange weaponChange;

        private void UpdateImage(WeaponDescription desc) {
            weaponImage.sprite = desc.onHandSprite;
        }

        private void OnEnable() => weaponChange.OnWeaponChanged += UpdateImage;
        private void OnDisable() => weaponChange.OnWeaponChanged -= UpdateImage;
    }
}
