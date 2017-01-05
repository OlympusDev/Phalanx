using UnityEngine;
using System.Collections;

namespace Olympus.Phalanx.Entity
{
    public delegate void Success(bool success);
    public struct AttackInfo
    {
        public int attackRolls { get; private set; }
        public int baseAttack { get; private set; }
        public int originHeight { get; private set; }
        public int attackType { get; private set; }
        public Success attacker { get; private set; }
        public AttackInfo(int attackRoll,int attackBase,int originHeight,int attackType,Success callback)
        {
            attackRolls = attackRoll;
            baseAttack = attackBase;
            this.originHeight = originHeight;
            this.attackType = attackType;
            attacker = callback;
        }
    }
}
