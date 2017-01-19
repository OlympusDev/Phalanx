using UnityEngine;
using System.Collections;

namespace Olympus.Phalanx.Entity
{
    public delegate void Success(bool success);
    public struct AttackInfo
    {
        public int attackRoll { get; private set; }
        public int attackBase { get; private set; }
        public int originHeight { get; private set; }
        public int attackType { get; private set; }
        public Success attacker { get; private set; }

        public AttackInfo(int attackRoll,int attackBase,int originHeight,int attackType,Success callback)
        {
            this.attackRoll = attackRoll;
            this.attackBase = attackBase;
            this.originHeight = originHeight;
            this.attackType = attackType;
            attacker = callback;
        }
    }
}
