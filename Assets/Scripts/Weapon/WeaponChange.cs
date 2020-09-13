﻿using ThisGame.Player;
using ThisGame.Status;
using ThisGame.Utils;
using UnityEngine;

namespace ThisGame.Weapon {
    public class WeaponChange : MonoBehaviour {
        // todo: read from inventory
        public WeaponDescription[] weaponDescs;
        public SpriteRenderer spriteRenderer;

        // todo: use direct obj ref
        public StatusDescription speedUpStatus;
        private PlayerStatus playerStatus;

        private int weaponIdx;


        public WeaponDescription GetCurrWeapon => weaponDescs[weaponIdx];

        private void SetCurrWeapon(int idx) {
            if(idx != weaponIdx)
                OnWeaponChanged(weaponDescs[idx]);
            weaponIdx = idx;
            spriteRenderer.sprite = weaponDescs[idx].onHandSprite;
        }


        // todo: make this a callback
        // todo: set FX in SO
        private void OnWeaponChanged(WeaponDescription desc) {
            if(desc.type == ElementType.Light)
                playerStatus.AddStatus(speedUpStatus);
            else
                playerStatus.RemoveStatus(speedUpStatus);
        }

        private void Awake() {
            weaponIdx = -1;
        }

        private void Start() {
            playerStatus = GetComponentInParent<PlayerStatus>();
            SetCurrWeapon(0);
        }

        private void Update() {
            var d = Input.mouseScrollDelta.y;
            var len = weaponDescs.Length;
            if(d > .5f) {
                SetCurrWeapon((len + weaponIdx + 1) % len);
            }
            else if(d < -.5f) {
                SetCurrWeapon((len + weaponIdx - 1) % len);
            }
        }
    }
}
