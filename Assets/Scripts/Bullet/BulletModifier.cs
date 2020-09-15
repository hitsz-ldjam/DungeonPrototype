using System.Collections.Generic;

namespace ThisGame.Bullet {
    // todo: as bitmask
    // todo: rename
    public enum BulletModifier {
        None, Daodan, Xiandan, Zhuizong, Jiguang, Fantan, Fenlie,
        Changbian, Dixingpohuai, Zhaohuanwu, Liansuo, Nianxing, Huixuan, Xuli
    }


    public static class BulletModifierExt {
        public static string ToDisplayString(this BulletModifier bm) {
            switch(bm) {
                case BulletModifier.None:
                    return "[空]";
                case BulletModifier.Daodan:
                    return "导弹";
                case BulletModifier.Xiandan:
                    return "霰弹";
                case BulletModifier.Zhuizong:
                    return "[没做]追踪";
                case BulletModifier.Jiguang:
                    return "[没做]激光";
                case BulletModifier.Fantan:
                    return "反弹";
                case BulletModifier.Fenlie:
                    return "[没做]分裂";
                case BulletModifier.Changbian:
                    return "[没做]长鞭";
                case BulletModifier.Dixingpohuai:
                    return "[不存在的]地形破坏";
                case BulletModifier.Zhaohuanwu:
                    return "[没做]召唤物";
                case BulletModifier.Liansuo:
                    return "[没做]连锁";
                case BulletModifier.Nianxing:
                    return "粘性";
                case BulletModifier.Huixuan:
                    return "[没做]回旋";
                case BulletModifier.Xuli:
                    return "[没做]蓄力";
                default:
                    return "[没做]";
            }
        }


        public static HashSet<BulletModifier> CopyValue(this IEnumerable<BulletModifier> modifiers)
            => modifiers is null ? null : new HashSet<BulletModifier>(modifiers);
    }
}
