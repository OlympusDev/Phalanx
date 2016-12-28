using UnityEngine;
using System.Collections;

namespace Olympus.Phalanx.Entity
{
    public interface IOccupant
    {
        GameObject gameObject { get; }

        Map.Tile tile { get; set; }
        AttackInfo attack { get; }

        int team { get; }

        Skill this[int index] { get; }

        Skill[] getSkills();
        void damage(AttackInfo info);
        void addEffect();

    }
}
