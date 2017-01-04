using UnityEngine;
using System.Collections;

namespace Olympus.Phalanx.Entity
{
    public delegate void Success(bool success);
    public struct AttackInfo
    {
        public int attackRolls;
        public int baseAttack;
        public int originHeight;
        public int attackType;
        public Success attacker;
    }
}
