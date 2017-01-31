using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympus.Phalanx.Map
{
    public class TargetingInfo
    {

        public int moves { get; private set; }
        public MoveType type { get; private set; }
        public TargetingInfo from { get; private set; }
        public Tile tile { get; private set; }

        public TargetingInfo(int moves, MoveType type,Tile tile)
        {
            this.moves = moves;
            this.type = type;
            this.tile = tile;
            from = this; //If origin
        }

        public TargetingInfo(int moves, MoveType type,Tile tile,TargetingInfo parent)
        {
            this.moves = moves;
            this.type = type;
            this.tile = tile;
            from =  parent; //remember who its moving from
        }

        public TargetingInfo Move(Tile destination)
        {
            return Move(destination, 1);
        }

        public TargetingInfo Move(Tile destination,int moveUsage)
        {
            return new TargetingInfo(moves - moveUsage, type, destination, this);
        }

        public bool better(TargetingInfo info)
        {
            //TODO
            //Comparison
            //true if more moves left in this than info
            //Posibly add 
            return this.moves>info.moves;
        }
    }
    public enum MoveType
    {
        Normal = 0x0000,
        Tank = 0x0001,

        //Combat Targeting
        Attack = 0x0100,
        Friendly = 0x0101
    }
}
