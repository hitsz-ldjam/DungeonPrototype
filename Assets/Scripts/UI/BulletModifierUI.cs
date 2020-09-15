using System.Collections.Generic;
using System.Text;
using ThisGame.Bullet;
using ThisGame.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    // todo: separate ui from manager
    public class BulletModifierUI : SingletonManager<BulletModifierUI> {
        private Text displayText;
        private HashSet<BulletModifier> bulletModifiers;

        public IReadOnlyCollection<BulletModifier> BulletModifiers => bulletModifiers;

        private void UpdateDisplayText() {
            const char emsp = '　';
            var sb = new StringBuilder();
            foreach(var modifier in bulletModifiers) {
                sb.Append(modifier.ToDisplayString());
                sb.Append(emsp);
            }
            displayText.text = sb.ToString();
        }


        private BulletModifier KeyCodeToBulletModifier(KeyCode kc) {
            // hack: Alpha0 = 48, Alpha1 = 49
            // Keypad0 = 256, Keypad1 = 257
            var no = kc - KeyCode.Alpha0;
            if(no > 9 || no < 0) {
                no = kc - KeyCode.Keypad0;
                if(no > 9 || no < 0)
                    return BulletModifier.None;
            }
            // wtf???
            switch(no) {
                case 1:
                    return BulletModifier.Daodan;
                case 2:
                    return BulletModifier.Xiandan;
                case 3:
                    return BulletModifier.Zhuizong;
                case 4:
                    return BulletModifier.Fantan;
                case 5:
                    return BulletModifier.Fenlie;
                case 6:
                    return BulletModifier.Nianxing;
                case 7:
                    return BulletModifier.Huixuan;
                case 8:
                    return BulletModifier.Xuli;
                case 9:
                case 0:
                default:
                    return BulletModifier.None;
            }
        }


        protected override void OnInstanceAwake() {
            base.OnInstanceAwake();
            displayText = GetComponent<Text>();
            bulletModifiers = new HashSet<BulletModifier>();
        }


        private void Update() {
            for(var offset = 0; offset < 10; ++offset) {
                var alpha = KeyCode.Alpha0 + offset;
                var keypad = KeyCode.Keypad0 + offset;
                var alphaFlag = Input.GetKeyDown(alpha);
                var keypadFlag = Input.GetKeyDown(keypad);
                var bm = BulletModifier.None;
                if(alphaFlag)
                    bm = KeyCodeToBulletModifier(alpha);
                else if(keypadFlag)
                    bm = KeyCodeToBulletModifier(keypad);
                else
                    continue;
                var _ = bulletModifiers.Contains(bm) ? bulletModifiers.Remove(bm) : bulletModifiers.Add(bm);
                UpdateDisplayText();
                break;
            }
        }
    }
}
