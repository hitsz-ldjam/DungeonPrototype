using UnityEngine;

namespace ThisGame.Status {
    public enum StatusType { SpeedUp, SpeedDown, Vulnerable, AtkdmgUp }

    [CreateAssetMenu(fileName = "StatusDescription", menuName = "Status/Status Description")]
    public class StatusDescription : ScriptableObject {
        public Sprite statusSprite;
        public StatusType statusType;
    }
}
