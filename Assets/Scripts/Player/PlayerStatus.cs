using System;
using ThisGame.Status;
using UnityEngine;

namespace ThisGame.Player {
    public class PlayerStatus : MonoBehaviour {
        public StatusBarControl sbCtrl;

        private PlayerMove playerMove;


        public void AddStatus(StatusDescription desc, bool continuous = true) {
            sbCtrl.AddStatus(desc, continuous);
        }

        public bool RemoveStatus(StatusDescription desc, bool rmall = false) {
            return sbCtrl.RemoveStatus(desc, rmall);
        }


        // todo: set FX in SO
        private void OnStatusAdded(StatusDescription desc) {
            switch(desc.statusType) {
                case StatusType.SpeedUp:
                    playerMove.moveSpeed += 3;
                    break;
                case StatusType.SpeedDown:
                    playerMove.moveSpeed -= 2;
                    break;
                default:
                    break;
            }
        }


        // todo: set FX in SO
        private void OnStatusRemoved(StatusDescription desc) {
            switch(desc.statusType) {
                case StatusType.SpeedUp:
                    playerMove.moveSpeed -= 3;
                    break;
                case StatusType.SpeedDown:
                    playerMove.moveSpeed += 2;
                    break;
                default:
                    break;
            }
        }


        private void Awake() {
            playerMove = GetComponent<PlayerMove>();

            sbCtrl.OnStatusAdded = OnStatusAdded;
            sbCtrl.OnStatusRemoved = OnStatusRemoved;
        }
    }
}
