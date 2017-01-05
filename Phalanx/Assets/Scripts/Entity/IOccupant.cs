using UnityEngine;
using System.Collections;

namespace Olympus.Phalanx.Entity
{
    public interface IOccupant
    {
        GameObject gameObject { get; }

        Map.Tile tile
        {
            get;
            //Deprecated, use move instead
            set;
        }
        void move(System.Collections.Generic.IList<Map.Tile> path);

        AttackInfo attack { get; }
        int team { get; }

        Skill this[int index] { get; }
        Skill[] getSkills();

        void damage(AttackInfo info);
        void addEffect();

        //UI can get info about 
        OccupantInfo info { get; }
    }

    public class OccupantInfo
    {
        public int Health { get; private set; }
        public int Team { get; private set; }

    }
}
